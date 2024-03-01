using Business.Abstract;
using Core.CrossCuttingConcerns;
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

        public BootcampBusinessRules(IBootcampRepository repository, IInstructorService instructorService)
        {
            _repository = repository;
            _instructorService = instructorService;
        }
        public async Task CheckIdIsExists(int id)
        {
            var entity = await _repository.GetAsync(x => x.Id == id);
            if (entity is null)
                throw new BusinessException("Bootcamp already not exists");
        }

        public async Task CheckInstructorIdIsExits(int id)
        {
            await _instructorService.CheckIdIsExists(id);
        }
    }
}
