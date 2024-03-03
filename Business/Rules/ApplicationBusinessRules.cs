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
    public class ApplicationBusinessRules : BaseBusinessRules
    {
        private readonly IApplicationRepository _repository;
        private readonly IBlacklistService _blacklistService;
        private readonly IBootcampService _bootcampService;
        private readonly IBootcampStateService _bootcampStateService;
        private readonly IApplicantService _applicantService;

        public ApplicationBusinessRules
            (IApplicationRepository repository, IBlacklistService blacklistService, IBootcampService bootcampService, IBootcampStateService bootcampStateService, IApplicantService applicantService)
        {
            _repository = repository;
            _blacklistService = blacklistService;
            _bootcampService = bootcampService;
            _bootcampStateService = bootcampStateService;
            _applicantService = applicantService;
        }
        public async Task CheckIdIsExists(int id)
        {
            var entity = await _repository.GetAsync(x => x.Id == id);
            if (entity is null)
                throw new BusinessException(ApplicationMessages.NotExistsId);
        }

        public async Task CheckIfApplicantIsBlacklist(int applicantId)
        {
            var entity = await _blacklistService.GetByApplicantIdAsync(applicantId);
            if (entity.Data != null)
                throw new BusinessException(ApplicationMessages.IsInBlackList);

        }

        public async Task CheckIfApplicantIdIsExists(int id)
        {
            await _applicantService.CheckIdIsExists(id);
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
