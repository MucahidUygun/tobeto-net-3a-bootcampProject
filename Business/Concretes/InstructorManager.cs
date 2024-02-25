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
        public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAll()
        {
            List<GetAllInstructorResponse> instructors = _mapper.Map<List<GetAllInstructorResponse>>(await _instructorRepository.GetAllAsync());
            return new SuccessDataResult<List<GetAllInstructorResponse>>(instructors,"Başarıyla Listelendi");
        }

        public async Task<IDataResult<GetByIdInstructorResponse>> GetById(int id)
        {

            GetByIdInstructorResponse instructor = _mapper.Map<GetByIdInstructorResponse>(await _instructorRepository.GetAsync(x => x.Id == id));
            return new SuccessDataResult<GetByIdInstructorResponse>(instructor,"Başarıyla Id'ye göre listelendi");
        }

        public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);
            await _instructorRepository.AddAsync(instructor);

            CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(instructor);
            return new SuccessDataResult<CreateInstructorResponse>(response,"Başarıyla Eklendi.");
        }

        public async Task<IDataResult<DeleteInstructorResponse>> DeleteAsync(DeleteInstructorRequest request)
        {
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == request.Id);
            await _instructorRepository.DeleteAsync(instructor);

            DeleteInstructorResponse response = _mapper.Map<DeleteInstructorResponse>(instructor);
            return new SuccessDataResult<DeleteInstructorResponse>(response,"Başarıyla silindi");
        }

        public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
        {
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request,instructor);

            UpdateInstructorResponse response = _mapper.Map<UpdateInstructorResponse>(instructor);
            return new SuccessDataResult<UpdateInstructorResponse>(response,"Başarıyla Güncellendi.");
        }
    }
}
