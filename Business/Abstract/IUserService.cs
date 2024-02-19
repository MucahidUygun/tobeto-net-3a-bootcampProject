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
        Task<List<GetAllUserResponse>> GetAllAsync();
        Task<GetByIdResponse> GetByIdAsync(int id);

        //List<GetAllUserResponse> GetAll();
        //GetByIdUserResponse GetById(int id);

    }
}
