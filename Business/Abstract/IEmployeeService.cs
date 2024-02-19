using Business.Dtos.EmployeeDto.Request;
using Business.Dtos.EmployeeDto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        Task<List<GetAllEmployeeResponse>> GetAll();
        Task<GetByIdEmployeeResponse> GetById(int id);
        Task<CreateEmployeeResponse> AddAsync(CreateEmployeeRequest request);
        Task<DeleteEmployeeResponse> DeleteAsync(DeleteEmployeeRequest request);
        Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request);

        //List<GetAllEmployeeResponse> GetAll();
        //GetByIdEmployeeResponse GetById(int id);
        //CreateEmployeeResponse Add(CreateEmployeeRequest request);
        //DeleteEmployeeResponse Delete(DeleteEmployeeRequest request);
        //UpdateEmployeeResponse Update(UpdateEmployeeRequest request);
    }
}
