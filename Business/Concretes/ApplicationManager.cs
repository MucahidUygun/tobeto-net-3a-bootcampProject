using AutoMapper;
using Azure.Core;
using Business.Abstract;
using Business.Dtos.ApplicationDto.Request;
using Business.Dtos.ApplicationDto.Response;
using Core.DataAccess;
using Core.Exceptions.Types;
using DataAccess.Abstract;
using DataAccess.Concretes.Repository;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ApplicationManager : IApplicationService
    {
        private readonly IApplicationRepository _repository;
        private readonly IMapper _mapper;
        private readonly IBlacklistService _blacklistService;
        private readonly IBootcampService _bootcampService;
        private readonly IBootcampStateService _bootcampStateService;

        public ApplicationManager(IMapper mapper, IApplicationRepository repository, IBlacklistService blacklistService, IBootcampService bootcampService)
        {
            _mapper = mapper;
            _repository = repository;
            _blacklistService = blacklistService;
            _bootcampService = bootcampService;
        }

        public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
        {
            await CheckIfApplicantIsBlacklist(request.ApplicantId);
            await CheckIfBootcampIdExists(request.BootcampId);
            await CheckIfBootcampStateExitst(request.ApplicationStateId);
            Application application = _mapper.Map<Application>(request);
            await _repository.AddAsync(application);

            CreateApplicationResponse response = _mapper.Map<CreateApplicationResponse>(application);
            return new SuccessDataResult<CreateApplicationResponse>(response, "Başvuru ekleme başarılı.");
        }

        public async Task<IResult> DeleteAsync(DeleteApplicationRequest request)
        {
            await CheckIdIsExists(request.Id);
            Application application = await _repository.GetAsync(x => x.Id == request.Id);
            await _repository.DeleteAsync(application);
            DeleteApplicationResponse response = _mapper.Map<DeleteApplicationResponse>(application);
            return new SuccessResult("Başvuru silme başarılı.");
        }

        public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
        {
            List<Application> applications = await _repository.GetAllAsync(
                include: x => x.Include(x => x.Applicant).Include(x => x.Bootcamp).Include(x => x.ApplicationState));
            List<GetAllApplicationResponse> responses = _mapper.Map<List<GetAllApplicationResponse>>(applications);
            return new SuccessDataResult<List<GetAllApplicationResponse>>(responses, "Listeleme başarılı");
        }

        public async Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(int id)
        {
            await CheckIdIsExists(id);
            Application application = await _repository.GetAsync
                (x => x.Id == id, include: x => x.Include(x => x.Applicant).Include(x => x.Bootcamp).Include(x => x.ApplicationState));
            GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(application);

            return new SuccessDataResult<GetByIdApplicationResponse>(response);
        }

        public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
        {
            await CheckIdIsExists(request.Id);
            await CheckIfBootcampIdExists(request.BootcampId);
            await CheckIfBootcampStateExitst(request.ApplicationStateId);
            Application application = await _repository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request,application);
            await _repository.UpdateAsync(application);

            UpdateApplicationResponse response = _mapper.Map<UpdateApplicationResponse>(application);
            return new SuccessDataResult<UpdateApplicationResponse>(response, "Güncelleme başarılı");
        }

        private async Task CheckIdIsExists(int id)
        {
            var entity = await _repository.GetAsync(x => x.Id == id);
            if (entity is null)
                throw new BusinessException("Application already not exists");
        }

        private async Task CheckIfApplicantIsBlacklist(int applicantId)
        {
            var entity = await _blacklistService.GetByApplicantIdAsync(applicantId);
            if (entity.Data != null)
                throw new BusinessException("Applicant is in Blacklist");
           
        }

        private async Task CheckIfBootcampIdExists(int id)
        {
            await _bootcampService.CheckIdIsExists(id);
        }

        private async Task CheckIfBootcampStateExitst(int id)
        {
            await _bootcampStateService.CheckIdIsExists(id);
        }
    }
}
