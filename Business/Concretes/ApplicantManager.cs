using Business.Abstract;
using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.ApplicantDtos.Response;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ApplicantManager : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        public ApplicantManager(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public async Task<List<GetAllApplicantResponse>> GetAll()
        {
            List<GetAllApplicantResponse> instructors = new List<GetAllApplicantResponse>();
            foreach (var applicant in await _applicantRepository.GetAllAsync())
            {
                GetAllApplicantResponse response = new GetAllApplicantResponse()
                {
                    UserId = applicant.Id,
                    UserName = applicant.UserName,
                    FirstName = applicant.FirstName,
                    LastName = applicant.LastName,
                    Email = applicant.Email,
                    DateOfBirth = applicant.DateOfBirth,
                    NationalIdentity = applicant.NationalIdentity,
                    Password = applicant.Password,
                    About = applicant.About,
                    CreatedDate = applicant.CreatedDate,
                    DeletedDate = applicant.DeletedDate,
                    UpdatedDate = applicant.UpdatedDate,
                };

                instructors.Add(response);
            }
            return instructors;
        }

        public async Task<GetByIdApplicantResponse> GetById(int id)
        {
            GetByIdApplicantResponse response = new();
            Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == id);
            response.UserId = applicant.Id;
            response.UserName = applicant.UserName;
            response.FirstName = applicant.FirstName;
            response.LastName = applicant.LastName;
            response.Email = applicant.Email;
            response.DateOfBirth = applicant.DateOfBirth;
            response.NationalIdentity = applicant.NationalIdentity;
            response.Password = applicant.Password;
            response.About = applicant.About;
            response.CreatedDate = applicant.CreatedDate;
            response.DeletedDate = applicant.DeletedDate;
            response.UpdatedDate = applicant.UpdatedDate;
            return response;
        }

        public async Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request)
        {
            Applicant applicant = new Applicant()
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                NationalIdentity = request.NationalIdentity,
                Password = request.Password,
                About = request.About,
            };

            await _applicantRepository.AddAsync(applicant);

            CreateApplicantResponse response = new CreateApplicantResponse()
            {
                UserId = applicant.Id,
                UserName = applicant.UserName,
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                Email = applicant.Email,
                DateOfBirth = applicant.DateOfBirth,
                NationalIdentity = applicant.NationalIdentity,
                Password = applicant.Password,
                About = applicant.About,
                CreatedDate = applicant.CreatedDate,
            };

            return response;
        }

        public async Task<DeleteApplicantResponse> DeleteAsync(DeleteApplicantRequest request)
        {
            Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == request.UserId);
            applicant.Id = request.UserId;
            await _applicantRepository.DeleteAsync(applicant);

            DeleteApplicantResponse response = new DeleteApplicantResponse()
            {
                UserId = applicant.Id,
                UserName = applicant.UserName,
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                Email = applicant.Email,
                DateOfBirth = applicant.DateOfBirth,
                NationalIdentity = applicant.NationalIdentity,
                Password = applicant.Password,
                About = applicant.About,
                CreatedDate = applicant.CreatedDate,
                DeletedDate = applicant.DeletedDate,
                UpdatedDate = applicant.UpdatedDate,
            };
            return response;
        }

        public async Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request)
        {
            Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == request.UserId);
            applicant.UserName = request.UserName;
            applicant.FirstName = request.FirstName;
            applicant.LastName = request.LastName;
            applicant.DateOfBirth = request.DateOfBirth;
            applicant.Email = request.Email;
            applicant.NationalIdentity = request.NationalIdentity;
            applicant.Password = request.Password;
            applicant.About = request.About;
            await _applicantRepository.UpdateAsync(applicant);

            UpdateApplicantResponse response = new UpdateApplicantResponse()
            {
                UserId = applicant.Id,
                UserName = applicant.UserName,
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                Email = applicant.Email,
                DateOfBirth = applicant.DateOfBirth,
                NationalIdentity = applicant.NationalIdentity,
                Password = applicant.Password,
                About = applicant.About,
                CreatedDate = applicant.CreatedDate,
                UpdatedDate = applicant.UpdatedDate,
            };
            return response;
        }
    }
}
