using AutoMapper;
using Business.Abstract;
using Business.Constants.Messages;
using Business.Dtos.User.Request;
using Business.Dtos.User.Response;
using Business.Rules;
using DataAccess.Abstract;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        protected readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _rules;
        protected readonly IMapper _mapper;

        public UserManager(IUserRepository userRepository,IMapper mapper,UserBusinessRules rules)
        {
            _rules = rules;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<IDataResult<List<GetAllUserResponse>>> GetAllAsync()
        {
            List<GetAllUserResponse> list = _mapper.Map<List<GetAllUserResponse>>(await _userRepository.GetAllAsync());
            return new SuccessDataResult<List<GetAllUserResponse>>(list,UserMessages.GetAllListed);

        }

        public async Task<IDataResult<GetByIdResponse>> GetByIdAsync(int id)
        {
            await _rules.CheckIdIsExists(id);
            User user = await _userRepository.GetAsync(x => x.Id == id);
            GetByIdResponse response = _mapper.Map<GetByIdResponse>(user);
            return new SuccessDataResult<GetByIdResponse>(response,UserMessages.GetByIdListed);
        }

        
    }
}
