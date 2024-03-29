﻿using AutoMapper;
using Azure.Core;
using Business.Abstract;
using Business.Constants.Messages;
using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.ApplicantDtos.Response;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Exceptions.Types;
using DataAccess.Abstract;
using DataAccess.Concretes.Repository;
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
        private readonly ApplicantBusinessRules _rules;
        private readonly IMapper _mapper;
        public ApplicantManager(IApplicantRepository applicantRepository,IMapper mapper,ApplicantBusinessRules rules)
        {
            _rules = rules;
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync()
        {
            List<GetAllApplicantResponse> responses = _mapper.Map<List<GetAllApplicantResponse>>(await _applicantRepository.GetAllAsync());
 
            return new SuccessDataResult<List<GetAllApplicantResponse>>(responses, ApplicantMessages.GetAllListed);
        }

        public async Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(int id)
        {
            await _rules.CheckIdIsExists(id);
            Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == id);
            GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(applicant);
            
            return new SuccessDataResult<GetByIdApplicantResponse>(response,ApplicantMessages.GetByIdListed);
        }

        [LogAspect(typeof(MssqlLogger))]
        public async Task<IDataResult<CreateApplicantResponse>> AddAsync(Applicant request)
        {
            //Applicant applicant = _mapper.Map<Applicant>(request);
            await _applicantRepository.AddAsync(request);

            CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(request);

            return new SuccessDataResult<CreateApplicantResponse>(response,ApplicantMessages.Added);
        }

        [LogAspect(typeof(MssqlLogger))]
        public async Task<IResult> DeleteAsync(DeleteApplicantRequest request)
        {
            await _rules.CheckIdIsExists(request.Id);
            Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == request.Id);
            await _applicantRepository.DeleteAsync(applicant);

            DeleteApplicantResponse response = _mapper.Map<DeleteApplicantResponse>(applicant);
            return new SuccessResult(ApplicantMessages.Deleted);
        }

        public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
        {
            await _rules.CheckIdIsExists(request.Id);
            Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request,applicant);
            await _applicantRepository.UpdateAsync(applicant);

            UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(applicant);
            return new SuccessDataResult<UpdateApplicantResponse>(response,ApplicantMessages.Updated);
        }

        public async Task CheckIdIsExists(int id)
        {
            await _rules.CheckIdIsExists(id);
        }

    }
}
