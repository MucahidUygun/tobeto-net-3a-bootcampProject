using Business.Abstract;
using Business.Dtos.User.Request;
using Business.Dtos.User.Response;
using DataAccess.Abstract;
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

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<List<GetAllUserResponse>> GetAllAsync()
        {
            List<GetAllUserResponse> list = new List<GetAllUserResponse>();

            foreach (var user in await _userRepository.GetAllAsync())
            {
                list.Add(
                    new GetAllUserResponse 
                    {
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        DateOfBirth = user.DateOfBirth,
                        NationalIdentity = user.NationalIdentity,
                        Email = user.Email,
                        Password = user.Password,
                    }
                    );
            }
            return list;

        }

        public async Task<GetByIdResponse> GetByIdAsync(int id)
        {
            User user = await _userRepository.GetAsync(x=>x.Id==id);
            GetByIdResponse response = new GetByIdResponse 
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                NationalIdentity = user.NationalIdentity,
                Email = user.Email,
                Password = user.Password,
            };
            return response;
        }

        
    }
}
