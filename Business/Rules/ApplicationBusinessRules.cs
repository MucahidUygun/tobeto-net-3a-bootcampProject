using Business.Abstract;
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
    public class ApplicationBusinessRules : BaseBusinessRules
    {
        private readonly IApplicantRepository _repository;
        private readonly IBlacklistService _blacklistService;
        private readonly IBootcampService _bootcampService;
        private readonly IBootcampStateService _bootcampStateService;

        public ApplicationBusinessRules
            (IApplicantRepository repository, IBlacklistService blacklistService, IBootcampService bootcampService, IBootcampStateService bootcampStateService)
        {
            _repository = repository;
            _blacklistService = blacklistService;
            _bootcampService = bootcampService;
            _bootcampStateService = bootcampStateService;
        }
        public async Task CheckIdIsExists(int id)
        {
            var entity = await _repository.GetAsync(x => x.Id == id);
            if (entity is null)
                throw new BusinessException("Application already not exists");
        }

        public async Task CheckIfApplicantIsBlacklist(int applicantId)
        {
            var entity = await _blacklistService.GetByApplicantIdAsync(applicantId);
            if (entity.Data != null)
                throw new BusinessException("Applicant is in Blacklist");

        }

        public async Task CheckIfBootcampIdExists(int id)
        {
            await _bootcampService.CheckIdIsExists(id);
        }
        public async Task CheckIfBootcampStateExitst(int id)
        {
            await _bootcampStateService.CheckIdIsExists(id);
        }
    }
}
