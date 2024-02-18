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

        public async Task<AddUserResponse> Add(AddUserRequest addUserRequest)
        {
            User user = new User 
            {
                UserName = addUserRequest.UserName,
                FirstName = addUserRequest.FirstName,
                LastName = addUserRequest.LastName,
                DateOfBirth = addUserRequest.DateOfBirth,
                NationalIdentity = addUserRequest.NationalIdentity,
                Email = addUserRequest.Email,
                Password = addUserRequest.Password,
            };
            await _userRepository.Add(user);

            AddUserResponse addUserResponse = new AddUserResponse 
            {
                UserName = addUserRequest.UserName,
                FirstName = addUserRequest.FirstName,
                LastName = addUserRequest.LastName,
                DateOfBirth = addUserRequest.DateOfBirth,
                NationalIdentity = addUserRequest.NationalIdentity,
                Email = addUserRequest.Email,
                Password = addUserRequest.Password,
            };
            return addUserResponse;
        }

        public async Task<DeleteUserResponse> Delete(DeleteUserRequest deleteUserRequest)
        {
            User user = new User
            {
                UserName = deleteUserRequest.UserName,
                FirstName = deleteUserRequest.FirstName,
                LastName = deleteUserRequest.LastName,
                DateOfBirth = deleteUserRequest.DateOfBirth,
                NationalIdentity = deleteUserRequest.NationalIdentity,
                Email = deleteUserRequest.Email,
                Password = deleteUserRequest.Password,
            };
            await _userRepository.Delete(user);

            DeleteUserResponse deleteUserResponse = new DeleteUserResponse 
            {
                UserName= deleteUserRequest.UserName,
                FirstName = deleteUserRequest.FirstName,
                LastName = deleteUserRequest.LastName,
                DateOfBirth= deleteUserRequest.DateOfBirth,
                NationalIdentity= deleteUserRequest.NationalIdentity,
                Email = deleteUserRequest.Email,
                Password = deleteUserRequest.Password,
            };
            return deleteUserResponse;
        }

        public async Task<List<GetAllUserResponse>> GetAll()
        {
            List<GetAllUserResponse> list = new List<GetAllUserResponse>();

            foreach (var user in await _userRepository.GetAll())
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

        public async Task<GetByIdResponse> GetById(int id)
        {
            User user = await _userRepository.Get(x=>x.Id==id);
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

        public async Task<UpdateUserResponse> Update(UpdateUserRequest updateUserRequest)
        {
            User user = await _userRepository.Get(x => x.Id == updateUserRequest.Id);

            user.UserName = updateUserRequest.UserName;
            user.FirstName = updateUserRequest.FirstName;
            user.LastName = updateUserRequest.LastName;
            user.DateOfBirth = updateUserRequest.DateOfBirth;
            user.NationalIdentity = updateUserRequest.NationalIdentity;
            user.Email = updateUserRequest.Email;
            user.Password = updateUserRequest.Password;

            await _userRepository.Update(user);

            UpdateUserResponse response = new UpdateUserResponse
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
