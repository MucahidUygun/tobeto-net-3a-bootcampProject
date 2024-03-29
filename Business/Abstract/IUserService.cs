﻿using Business.Dtos.User.Request;
using Business.Dtos.User.Response;
using Core.Utilities.Security.Entities;
using DataAccess.Utilities.Results;
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
        Task<IDataResult<List<GetAllUserResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdResponse>> GetByIdAsync(int id);
        Task<IDataResult<User>> GetByEmailAsync(string email);

        //List<GetAllUserResponse> GetAll();
        //GetByIdUserResponse GetById(int id);

    }
}
