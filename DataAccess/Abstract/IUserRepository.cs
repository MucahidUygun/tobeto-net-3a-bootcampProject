﻿using Core.DataAccess;
using Core.Utilities.Security.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IAsyncRepository<User,int>,IRepository<User,int>
    {
    }
}
