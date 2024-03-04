using AutoMapper;
using Business.Abstract;
using Business.Constants.Messages;
using Business.Dtos.ApplicationDto.Request;
using Business.Dtos.ApplicationDto.Response;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using DataAccess.Abstract;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class ApplicationManager : IApplicationService
    {
        private readonly IApplicationRepository _repository;
        private readonly IMapper _mapper;
        private readonly ApplicationBusinessRules _rules;

        public ApplicationManager
            (IMapper mapper, IApplicationRepository repository, ApplicationBusinessRules rules)
        {
            _rules = rules;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
        {
            await _rules.CheckIfApplicantIdIsExists(request.ApplicantId);
            await _rules.CheckIfApplicantIsBlacklist(request.ApplicantId);
            await _rules.CheckIfBootcampIdExists(request.BootcampId);
            await _rules.CheckIfBootcampStateExitst(request.ApplicationStateId);
            Application application = _mapper.Map<Application>(request);
            await _repository.AddAsync(application);

            CreateApplicationResponse response = _mapper.Map<CreateApplicationResponse>(application);
            return new SuccessDataResult<CreateApplicationResponse>(response, ApplicationMessages.Added);
        }

        public async Task<IResult> DeleteAsync(DeleteApplicationRequest request)
        {
            await _rules.CheckIdIsExists(request.Id);
            Application application = await _repository.GetAsync(x => x.Id == request.Id);
            await _repository.DeleteAsync(application);
            DeleteApplicationResponse response = _mapper.Map<DeleteApplicationResponse>(application);
            return new SuccessResult(ApplicationMessages.Deleted);
        }
        [LogAspect(typeof(MongoDbLogger))]
        public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
        {
            List<Application> applications = await _repository.GetAllAsync(
                include: x => x.Include(x => x.Applicant).Include(x => x.Bootcamp).Include(x => x.ApplicationState));
            List<GetAllApplicationResponse> responses = _mapper.Map<List<GetAllApplicationResponse>>(applications);
            return new SuccessDataResult<List<GetAllApplicationResponse>>(responses, ApplicationMessages.GetAllListed);
        }

        public async Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(int id)
        {
            await _rules.CheckIdIsExists(id);
            Application application = await _repository.GetAsync
                (x => x.Id == id, include: x => x.Include(x => x.Applicant).Include(x => x.Bootcamp).Include(x => x.ApplicationState));
            GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(application);

            return new SuccessDataResult<GetByIdApplicationResponse>(response,ApplicationMessages.GetByIdListed);
        }

        public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
        {
            await _rules.CheckIdIsExists(request.Id);
            await _rules.CheckIfApplicantIdIsExists(request.ApplicantId);
            await _rules.CheckIfApplicantIsBlacklist(request.ApplicantId);
            await _rules.CheckIfBootcampIdExists(request.BootcampId);
            await _rules.CheckIfBootcampStateExitst(request.ApplicationStateId);
            Application application = await _repository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request,application);
            await _repository.UpdateAsync(application);

            UpdateApplicationResponse response = _mapper.Map<UpdateApplicationResponse>(application);
            return new SuccessDataResult<UpdateApplicationResponse>(response, ApplicationMessages.Updated);
        }

    }
}
