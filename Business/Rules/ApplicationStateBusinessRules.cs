using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class ApplicationStateBusinessRules : BaseBusinessRules
    {
        private readonly IApplicationStateRepository _repository;

        public ApplicationStateBusinessRules(IApplicationStateRepository repository)
        {
            _repository = repository;
        }
        public async Task CheckIdIsExists(int id)
        {
            var entity = await _repository.GetAsync(x => x.Id == id);
            if (entity is null)
                throw new BusinessException(ApplicationStateMessages.NotExists);
        }
    }
}
