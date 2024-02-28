using AutoMapper;
using Azure.Core;
using Business.Abstract;
using Business.Dtos.ApplicationStateDto.Request;
using Business.Dtos.ApplicationStateDto.Response;
using Core.Exceptions.Types;
using DataAccess.Abstract;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ApplicationStateManager : IApplicationStateService
    {
        private readonly IApplicationStateRepository _repository;
        private readonly IMapper _mapper;

        public ApplicationStateManager(IMapper mapper, IApplicationStateRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
        {
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            await _repository.AddAsync(applicationState);

            CreateApplicationStateResponse response = _mapper.Map<CreateApplicationStateResponse>(applicationState);
            return new SuccessDataResult<CreateApplicationStateResponse>(response,"Eklendi");

        }

        public async Task<IResult> DeleteAsync(DeleteApplicationStateRequest request)
        {
            await CheckIdIsExists(request.Id);
            ApplicationState applicationState = await _repository.GetAsync(x=> x.Id == request.Id);
            await _repository.DeleteAsync(applicationState);

            DeleteApplicationStateResponse response = _mapper.Map<DeleteApplicationStateResponse>(applicationState);

            return new SuccessResult("Başarıyla Silindi");

        }

        public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync()
        {
            List<ApplicationState> applicationStates = await _repository.GetAllAsync();
            List<GetAllApplicationStateResponse> responses = _mapper.Map<List<GetAllApplicationStateResponse>>(applicationStates);
            return new SuccessDataResult<List<GetAllApplicationStateResponse>>(responses, "Veriler başarıyla listelendi.");
        }

        public async Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdApplicationStateAsync(int id)
        {
            await CheckIdIsExists(id);
            ApplicationState applicationState = await _repository.GetAsync(x => x.Id == id);
            GetByIdApplicationStateResponse response = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);
            return new SuccessDataResult<GetByIdApplicationStateResponse>(response);
        }

        public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
        {
            await CheckIdIsExists(request.Id);
            ApplicationState applicationState =await _repository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request,applicationState);
            await _repository.UpdateAsync(applicationState);
            UpdateApplicationStateResponse response = _mapper.Map<UpdateApplicationStateResponse>(applicationState);
            return new SuccessDataResult<UpdateApplicationStateResponse>(response, "Güncelleme işlemi başarılı");
        }
        private async Task CheckIdIsExists(int id)
        {
            var entity = await _repository.GetAsync(x => x.Id == id);
            if (entity is null)
                throw new BusinessException("Application State already not exists");
        }
    }
}
