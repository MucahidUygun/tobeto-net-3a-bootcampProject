using Business.Abstract;
using Business.Dtos.InstructorDto.Request;
using Business.Dtos.InstructorDto.Response;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public InstructorManager(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }
        public async Task<List<GetAllInstructorResponse>> GetAll()
        {
            List<GetAllInstructorResponse> instructors = new List<GetAllInstructorResponse>();
            foreach (var instructor in await _instructorRepository.GetAllAsync())
            {
                GetAllInstructorResponse response = new GetAllInstructorResponse()
                {
                    UserId = instructor.Id,
                    UserName = instructor.UserName,
                    FirstName = instructor.FirstName,
                    LastName = instructor.LastName,
                    Email = instructor.Email,
                    NationalIdentity = instructor.NationalIdentity,
                    DateOfBirth = instructor.DateOfBirth,
                    Password = instructor.Password,
                    CompanyName = instructor.CompanyName,
                    CreatedDate = instructor.CreatedDate,
                    DeletedDate = instructor.DeletedDate,
                    UpdatedDate = instructor.UpdatedDate,

                };
                instructors.Add(response);
            }
            return instructors;
        }

        public async Task<GetByIdInstructorResponse> GetById(int id)
        {

            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == id);
            GetByIdInstructorResponse response = new GetByIdInstructorResponse()
            {
                UserId = instructor.Id,
                UserName = instructor.UserName,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Email = instructor.Email,
                NationalIdentity = instructor.NationalIdentity,
                DateOfBirth = instructor.DateOfBirth,
                Password = instructor.Password,
                CompanyName = instructor.CompanyName,
                CreatedDate = instructor.CreatedDate,
                DeletedDate = instructor.DeletedDate,
                UpdatedDate = instructor.UpdatedDate,

            };
            return response;
        }

        public async Task<CreateInstructorResponse> AddAsync(CreateInstructorRequest request)
        {
            Instructor instructor = new Instructor()
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                NationalIdentity = request.NationalIdentity,
                DateOfBirth = request.DateOfBirth,
                Password = request.Password,
                CompanyName = request.CompanyName,
            };
            await _instructorRepository.AddAsync(instructor);

            CreateInstructorResponse response = new CreateInstructorResponse()
            {

                UserId = instructor.Id,
                UserName = instructor.UserName,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Email = instructor.Email,
                NationalIdentity = instructor.NationalIdentity,
                DateOfBirth = instructor.DateOfBirth,
                Password = instructor.Password,
                CompanyName = instructor.CompanyName,
                CreatedDate = instructor.CreatedDate
            };
            return response;
        }

        public async Task<DeleteInstructorResponse> DeleteAsync(DeleteInstructorRequest request)
        {
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == request.UserId);
            instructor.Id = request.UserId;
            await _instructorRepository.DeleteAsync(instructor);

            DeleteInstructorResponse response = new DeleteInstructorResponse()
            {
                UserId = instructor.Id,
                UserName = instructor.UserName,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Email = instructor.Email,
                NationalIdentity = instructor.NationalIdentity,
                DateOfBirth = instructor.DateOfBirth,
                Password = instructor.Password,
                CompanyName = instructor.CompanyName,
                CreatedDate = instructor.CreatedDate,
                DeletedDate = instructor.DeletedDate,
                UpdatedDate = instructor.UpdatedDate
            };
            return response;
        }

        public async Task<UpdateInstructorResponse> UpdateAsync(UpdateInstructorRequest request)
        {
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == request.UserId);
            instructor.UserName = request.UserName;
            instructor.FirstName = request.FirstName;
            instructor.LastName = request.LastName;
            instructor.Email = request.Email;
            instructor.NationalIdentity = request.NationalIdentity;
            instructor.DateOfBirth = request.DateOfBirth;
            instructor.Password = request.Password;
            instructor.CompanyName = request.CompanyName;
            await _instructorRepository.UpdateAsync(instructor);

            UpdateInstructorResponse response = new UpdateInstructorResponse()
            {
                UserId = instructor.Id,
                UserName = instructor.UserName,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Email = instructor.Email,
                NationalIdentity = instructor.NationalIdentity,
                DateOfBirth = instructor.DateOfBirth,
                Password = instructor.Password,
                CompanyName = instructor.CompanyName,
                CreatedDate = instructor.CreatedDate,
                UpdatedDate = instructor.UpdatedDate,
            };

            return response;
        }
    }
}
