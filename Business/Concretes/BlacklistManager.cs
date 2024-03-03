using AutoMapper;
using Azure.Core;
using Business.Abstract;
using Business.Constants.Messages;
using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.ApplicantDtos.Response;
using Business.Dtos.Blacklists.Requests;
using Business.Dtos.Blacklists.Responses;
using Business.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstract;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BlacklistManager : IBlacklistService
    {
        private readonly IBlacklistRepository _repository;
        private readonly IMapper _mapper;
        private readonly BlacklistBusinessRules _rules;

        public BlacklistManager(IMapper mapper, IBlacklistRepository repository, BlacklistBusinessRules rules)
        {
            _repository = repository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<IDataResult<CreatedBlacklistResponse>> AddAsync(CreateBlacklistRequest request)
        {
            await _rules.CheckApplicantIdIsExists(request.ApplicantId);
            Blacklist blacklist = _mapper.Map<Blacklist>(request);
            await _repository.AddAsync(blacklist);
            CreatedBlacklistResponse response = _mapper.Map<CreatedBlacklistResponse>(blacklist);
            return new SuccessDataResult<CreatedBlacklistResponse>(response,BlacklistMessages.Added);
        }

        public async Task<IResult> DeleteAsync(DeleteBlacklistRequest request)
        {
            await _rules.CheckIdIsExists(request.Id);
            Blacklist blacklist = await _repository.GetAsync(x=>x.Id == request.Id);
            await _repository.DeleteAsync(blacklist);
            return new SuccessResult(BlacklistMessages.Deleted);
        }

        public async Task<IDataResult<List<GetAllBlacklistResponse>>> GetAllAsync()
        {
            List<GetAllBlacklistResponse> responses = _mapper.Map<List<GetAllBlacklistResponse>>(await _repository.GetAllAsync(include: x => x.Include(x => x.Applicant)));
            
            return new SuccessDataResult<List<GetAllBlacklistResponse>>(responses,BlacklistMessages.GetAllListed);
        }

        public async Task<IDataResult<GetByApplicantIdResponse>> GetByApplicantIdAsync(int id)
        {
            await _rules.CheckApplicantIdIsExists(id);
            Blacklist blacklist = await _repository.GetAsync(x => x.ApplicantId == id, include: x => x.Include(x => x.Applicant));
            GetByApplicantIdResponse response = _mapper.Map<GetByApplicantIdResponse>(blacklist);

            return new SuccessDataResult<GetByApplicantIdResponse>(response, BlacklistMessages.GetByApplicantIdListed);
        }

        public async Task<IDataResult<GetByIdBlacklistResponse>> GetByIdBlacklistAsync(int id)
        {
            await _rules.CheckIdIsExists(id);
            Blacklist blacklist = await _repository.GetAsync(x => x.Id == id, include: x => x.Include(x => x.Applicant));
            GetByIdBlacklistResponse responses = _mapper.Map<GetByIdBlacklistResponse>(blacklist);

            return new SuccessDataResult<GetByIdBlacklistResponse>(responses, BlacklistMessages.GetByBlacklistIdListed);
        }

        public async Task<IDataResult<UpdatedBlacklistResponse>> UpdateAsync(UpdateBlacklistRequest request)
        {
            await _rules.CheckIdIsExists(request.Id);
            await _rules.CheckApplicantIdIsExists(request.ApplicantId);
            Blacklist blacklist = await _repository.GetAsync(x=>x.Id==request.Id);
            _mapper.Map(request,blacklist);
            await _repository.UpdateAsync(blacklist);
            UpdatedBlacklistResponse response = _mapper.Map<UpdatedBlacklistResponse>(blacklist);

            return new SuccessDataResult<UpdatedBlacklistResponse>(response,BlacklistMessages.Updated);
        }
        public async Task CheckIdIsExists(int id)
        {
            await _rules.CheckIdIsExists(id);
        }
    }
}
