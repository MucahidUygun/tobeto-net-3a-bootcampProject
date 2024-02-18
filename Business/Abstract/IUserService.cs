using Business.Dtos.User.Request;
using Business.Dtos.User.Response;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<List<GetAllUserResponse>> GetAll();
        Task<GetByIdResponse> GetById(int id);
        Task<UpdateUserResponse> Update(UpdateUserRequest updateUserRequest);
        Task<AddUserResponse> Add(AddUserRequest addUserRequest);
        Task<DeleteUserResponse> Delete(DeleteUserRequest deleteUserRequest);



    }
}
