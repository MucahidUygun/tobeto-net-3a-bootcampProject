using Business.Abstract;
using Business.Constants.Messages;
using Core.CrossCuttingConcerns;
using Core.Exceptions.Types;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class BlacklistBusinessRules : BaseBusinessRules
    {
        private readonly IBlacklistRepository _repository;
        private readonly IApplicantService _applicantService;

        public BlacklistBusinessRules(IBlacklistRepository repository, IApplicantService service)
        {
            _repository = repository;
            _applicantService = service;
        }
        public async Task CheckIdIsExists(int id)
        {
            var entity = await _repository.GetAsync(x => x.Id == id);
            if (entity is null)
                throw new BusinessException(BlacklistMessages.NotExists);
        }
        public async Task CheckApplicantIdIsExists(int id)
        {
            await _applicantService.CheckIdIsExists(id);
        }
    }
}
