using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstract;
using DataAccess.Concretes.Repository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class InstructorBusinessRules : BaseBusinessRules
    {
        private readonly IInstructorRepository _repository;

        public InstructorBusinessRules(IInstructorRepository repository)
        {
            _repository = repository;
        }
        public async Task CheckIdIsExists(int id)
        {
            var entity = await _repository.GetAsync(x => x.Id == id);
            if (entity is null)
                throw new BusinessException(InstructorMessages.NotExists);
        }
    }
}
