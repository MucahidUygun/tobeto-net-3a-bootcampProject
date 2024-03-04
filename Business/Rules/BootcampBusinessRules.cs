using Business.Abstract;
using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstract;
using DataAccess.Concretes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class BootcampBusinessRules : BaseBusinessRules
    {
        private readonly IBootcampRepository _repository;
        private readonly IInstructorService _instructorService;
        private readonly IBootcampStateService _bootcampStateService;

        public BootcampBusinessRules(IBootcampRepository repository, IInstructorService instructorService, IBootcampStateService bootcampStateService)
        {
            _repository = repository;
            _instructorService = instructorService;
            _bootcampStateService = bootcampStateService;
        }
        public async Task CheckIdIsExists(int id)
        {
            var entity = await _repository.GetAsync(x => x.Id == id);
            if (entity is null)
                throw new BusinessException(BootcampMessages.NotExists);
        }

        public async Task CheckBootcampStateIdIsExists(int id)
        {
            await _bootcampStateService.CheckIdIsExists(id);
        }

        public async Task CheckInstructorIdIsExits(int id)
        {
            await _instructorService.CheckIdIsExists(id);
        }
    }
}
