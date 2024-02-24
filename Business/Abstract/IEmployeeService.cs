using Business.Dtos.EmployeeDto.Request;
using Business.Dtos.EmployeeDto.Response;
using DataAccess.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        Task<IDataResult<List<GetAllEmployeeResponse>>> GetAll();
        Task<IDataResult<GetByIdEmployeeResponse>> GetById(int id);
        Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request);
        Task<IDataResult<DeleteEmployeeResponse>> DeleteAsync(DeleteEmployeeRequest request);
        Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request);

        //List<GetAllEmployeeResponse> GetAll();
        //GetByIdEmployeeResponse GetById(int id);
        //CreateEmployeeResponse Add(CreateEmployeeRequest request);
        //DeleteEmployeeResponse Delete(DeleteEmployeeRequest request);
        //UpdateEmployeeResponse Update(UpdateEmployeeRequest request);
    }
}
