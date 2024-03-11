using Business.Dtos.EmployeeDto.Request;
using Business.Dtos.EmployeeDto.Response;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdEmployeeResponse>> GetByIdAsync(int id);
        Task<IDataResult<CreateEmployeeResponse>> AddAsync(Employee request);
        Task<IResult> DeleteAsync(DeleteEmployeeRequest request);
        Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request);

        //List<GetAllEmployeeResponse> GetAll();
        //GetByIdEmployeeResponse GetById(int id);
        //CreateEmployeeResponse Add(CreateEmployeeRequest request);
        //DeleteEmployeeResponse Delete(DeleteEmployeeRequest request);
        //UpdateEmployeeResponse Update(UpdateEmployeeRequest request);
    }
}
