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

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync()
        {
            List<GetAllInstructorResponse> instructors = _mapper.Map<List<GetAllInstructorResponse>>(await _instructorRepository.GetAllAsync());
            return new SuccessDataResult<List<GetAllInstructorResponse>>(instructors,"Başarıyla Listelendi");
        }

        public async Task<IDataResult<GetByIdInstructorResponse>> GetByIdAsync(int id)
        {
            await CheckIdIsExists(id);
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == id);
            GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(instructor);
            return new SuccessDataResult<GetByIdInstructorResponse>(response, "Başarıyla Id'ye göre listelendi");
        }

        public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);
            await _instructorRepository.AddAsync(instructor);

            CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(instructor);
            return new SuccessDataResult<CreateInstructorResponse>(response,"Başarıyla Eklendi.");
        }

        public async Task<IResult> DeleteAsync(DeleteInstructorRequest request)
        {
            await CheckIdIsExists(request.Id);
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == request.Id);
            await _instructorRepository.DeleteAsync(instructor);

            DeleteInstructorResponse response = _mapper.Map<DeleteInstructorResponse>(instructor);
            return new SuccessResult("Başarıyla silindi");
        }

        public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
        {
            await CheckIdIsExists(request.Id);
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request,instructor);

            UpdateInstructorResponse response = _mapper.Map<UpdateInstructorResponse>(instructor);
            return new SuccessDataResult<UpdateInstructorResponse>(response,"Başarıyla Güncellendi.");
        }
        private async Task CheckIdIsExists(int id)
        {
            var entity = await _instructorRepository.GetAsync(x => x.Id == id);
            if (entity is null)
                throw new BusinessException("Instructor already not exists");
        }
    }
}
