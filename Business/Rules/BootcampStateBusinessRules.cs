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
    public class BootcampStateBusinessRules : BaseBusinessRules
    {
        private readonly IBootcampStateRepository _repository;

        public BootcampStateBusinessRules(IBootcampStateRepository repository)
        {
            _repository = repository;
        }
        public async Task CheckIdIsExists(int id)
        {
            var entity = await _repository.GetAsync(x => x.Id == id);
            if (entity is null)
                throw new BusinessException("Bootcamp State already not exists");
        }
    }
}
