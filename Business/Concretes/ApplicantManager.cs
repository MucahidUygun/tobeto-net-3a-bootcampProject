using AutoMapper;
using Business.Abstract;
using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.ApplicantDtos.Response;
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
    public class ApplicantManager : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;
        public ApplicantManager(IApplicantRepository applicantRepository,IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAll()
        {
            List<GetAllApplicantResponse> responses = _mapper.Map<List<GetAllApplicantResponse>>(await _applicantRepository.GetAllAsync());
 
            return new SuccessDataResult<List<GetAllApplicantResponse>>(responses, "Başarıyla Listelendi.");
        }

        public async Task<IDataResult<GetByIdApplicantResponse>> GetById(int id)
        {
            GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(await _applicantRepository.GetAsync(x=>x.Id==id));
            
            return new SuccessDataResult<GetByIdApplicantResponse>(response,"Id ye göre listelendi");
        }

        public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);
            await _applicantRepository.AddAsync(applicant);

            CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);

            return new SuccessDataResult<CreateApplicantResponse>(response,"Başarıyla eklendi");
        }

        public async Task<IDataResult<DeleteApplicantResponse>> DeleteAsync(DeleteApplicantRequest request)
        {
            Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == request.Id);
            await _applicantRepository.DeleteAsync(applicant);

            DeleteApplicantResponse response = _mapper.Map<DeleteApplicantResponse>(applicant);
            return new SuccessDataResult<DeleteApplicantResponse>(response,"Başarıyla Silindi");
        }

        public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
        {
            Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request,applicant);
            await _applicantRepository.UpdateAsync(applicant);

            UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(applicant);
            return new SuccessDataResult<UpdateApplicantResponse>(response,"Başarıyla Güncellendi");
        }
    }
}
