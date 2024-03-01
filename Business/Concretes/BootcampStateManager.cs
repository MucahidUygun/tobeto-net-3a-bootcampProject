using AutoMapper;
using Azure.Core;
using Business.Abstract;
using Business.Dtos.BootcampDto.Request;
using Business.Dtos.BootcampDto.Response;
using Business.Dtos.BootcampStateDto.Request;
using Business.Dtos.BootcampStateDto.Response;
using Business.Rules;
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
    public class BootcampStateManager: IBootcampStateService
    {
        private readonly IBootcampStateRepository _repository;
        private readonly BootcampBusinessRules _rules;
        private readonly IMapper _mapper;

        public BootcampStateManager(IBootcampStateRepository repository,IMapper mapper, BootcampBusinessRules rules)
        {
            _rules = rules;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
        {
            BootcampState bootcampState = _mapper.Map<BootcampState>(request);
            await _repository.AddAsync(bootcampState);
            CreateBootcampStateResponse response = _mapper.Map<CreateBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<CreateBootcampStateResponse>(response, "State Eklendi.");
        }

        public async Task<IResult> DeleteAsync(DeleteBootcampStateRequest request)
        {
            await _rules.CheckIdIsExists(request.Id);
            BootcampState bootcampState = _mapper.Map<BootcampState>(request);
            await _repository.DeleteAsync(bootcampState);
            DeleteBootcampStateResponse response = _mapper.Map<DeleteBootcampStateResponse>(bootcampState);
            return new SuccessResult("Silme Başarılı");
        }

        public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync()
        {
            List<BootcampState> bootcampStates = await _repository.GetAllAsync();
            List<GetAllBootcampStateResponse> responses = _mapper.Map<List<GetAllBootcampStateResponse>>(bootcampStates);
            return new SuccessDataResult<List<GetAllBootcampStateResponse>>(responses,"Listeleme başarılı.");
        }

        public async Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(int id)
        {
            await _rules.CheckIdIsExists(id);
            BootcampState bootcampState = await _repository.GetAsync(x=> x.Id == id);
            GetByIdBootcampStateResponse response = _mapper.Map<GetByIdBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<GetByIdBootcampStateResponse>(response,"Id' ye göre listeleme başarılı");
        }

        public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
        {
            await _rules.CheckIdIsExists(request.Id);
            BootcampState bootcampState =await _repository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request,bootcampState);
            await _repository.UpdateAsync(bootcampState);

            UpdateBootcampStateResponse response = _mapper.Map<UpdateBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<UpdateBootcampStateResponse>(response, "Güncelleme başarılı");
        }
        public async Task CheckIdIsExists(int id)
        {
            await _rules.CheckIdIsExists(id);
        }

    }
}
