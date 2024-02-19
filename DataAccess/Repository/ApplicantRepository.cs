using Core.DataAccess.EntityFramework.EfRepositoryBase;
using DataAccess.Abstract;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ApplicantRepository:EfRepositoryBase<Applicant,int,BaseDbContext>,IApplicantRepository
    {
        public ApplicantRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
