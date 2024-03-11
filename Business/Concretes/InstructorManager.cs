using Business.Abstract;
using Business.Dtos.InstructorDto.Request;
using Business.Dtos.InstructorDto.Response;
using DataAccess.Abstract;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Exceptions.Types;
using DataAccess.Concretes.Repository;
using Azure.Core;
using Business.Rules;
using Business.Constants.Messages;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly InstructorBusinessRules _rules;
        private readonly IMapper _mapper;

        public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper,InstructorBusinessRules rules)
        {
            _rules = rules;
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync()
        {
            List<GetAllInstructorResponse> instructors = _mapper.Map<List<GetAllInstructorResponse>>(await _instructorRepository.GetAllAsync());
            return new SuccessDataResult<List<GetAllInstructorResponse>>(instructors, InstructorMessages.GetAllListed);
        }

        public async Task<IDataResult<GetByIdInstructorResponse>> GetByIdAsync(int id)
        {
            await _rules.CheckIdIsExists(id);
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == id);
            GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(instructor);
            return new SuccessDataResult<GetByIdInstructorResponse>(response, InstructorMessages.GetByIdListed);
        }

        public async Task<IDataResult<CreateInstructorResponse>> AddAsync(Instructor request)
        {
            //Instructor instructor = _mapper.Map<Instructor>(request);
            await _instructorRepository.AddAsync(request);

            CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(request);
            return new SuccessDataResult<CreateInstructorResponse>(response, InstructorMessages.Added);
        }

        public async Task<IResult> DeleteAsync(DeleteInstructorRequest request)
        {
            await _rules.CheckIdIsExists(request.Id);
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == request.Id);
            await _instructorRepository.DeleteAsync(instructor);

            DeleteInstructorResponse response = _mapper.Map<DeleteInstructorResponse>(instructor);
            return new SuccessResult(InstructorMessages.Deleted);
        }

        public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
        {
            await _rules.CheckIdIsExists(request.Id);
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request,instructor);

            await _instructorRepository.UpdateAsync(instructor);
            UpdateInstructorResponse response = _mapper.Map<UpdateInstructorResponse>(instructor);
            return new SuccessDataResult<UpdateInstructorResponse>(response, InstructorMessages.Updated);
        }

        public async Task CheckIdIsExists(int id)
        {
            await _rules.CheckIdIsExists(id);
        }
    }
}
