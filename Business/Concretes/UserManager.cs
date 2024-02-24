using AutoMapper;
using Business.Abstract;
using Business.Dtos.User.Request;
using Business.Dtos.User.Response;
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
        protected readonly IMapper _mapper;

        public UserManager(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<IDataResult<List<GetAllUserResponse>>> GetAllAsync()
        {
            List<GetAllUserResponse> list = _mapper.Map<List<GetAllUserResponse>>(await _userRepository.GetAllAsync());
            return new SuccessDataResult<List<GetAllUserResponse>>(list,"Başarıyla Listelendi");

        }

        public async Task<IDataResult<GetByIdResponse>> GetByIdAsync(int id)
        {
            GetByIdResponse user = _mapper.Map<GetByIdResponse>(await _userRepository.GetAsync(x => x.Id == id));
            return new SuccessDataResult<GetByIdResponse>(user,"Başarıyla Eklendi.");
        }

        
    }
}
