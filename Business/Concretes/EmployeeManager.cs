using Business.Abstract;
using Business.Dtos.EmployeeDto.Request;
using Business.Dtos.EmployeeDto.Response;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<GetAllEmployeeResponse>> GetAll()
        {
            List<GetAllEmployeeResponse> employees = new List<GetAllEmployeeResponse>();
            foreach (var employee in await _employeeRepository.GetAllAsync())
            {
                GetAllEmployeeResponse response = new GetAllEmployeeResponse()
                {
                    UserId = employee.Id,
                    UserName = employee.UserName,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email, 
                    DateOfBirth = employee.DateOfBirth,
                    NationalIdentity = employee.NationalIdentity,
                    Password = employee.Password,
                    Position = employee.Position,
                    CreatedDate = employee.CreatedDate,
                    DeletedDate = employee.DeletedDate,
                    UpdatedDate = employee.UpdatedDate,

                };
                employees.Add(response);
            }
            return employees;
        }

        public async Task<GetByIdEmployeeResponse> GetById(int id)
        {
            Employee employee = await _employeeRepository.GetAsync(x => x.Id == id);
            GetByIdEmployeeResponse response = new GetByIdEmployeeResponse()
            {
                UserId = employee.Id,
                UserName = employee.UserName,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                NationalIdentity = employee.NationalIdentity,
                Password = employee.Password,
                Position = employee.Position,
                CreatedDate = employee.CreatedDate,
                DeletedDate = employee.DeletedDate,
                UpdatedDate = employee.UpdatedDate,

            };
            return response;
        }

        public async Task<CreateEmployeeResponse> AddAsync(CreateEmployeeRequest request)
        {
            Employee employee = new Employee()
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                NationalIdentity = request.NationalIdentity,
                Password = request.Password,
                Position = request.Position,

            };
            await _employeeRepository.AddAsync(employee);

            CreateEmployeeResponse response = new CreateEmployeeResponse()
            {
                UserId = employee.Id,
                UserName = employee.UserName,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                NationalIdentity = employee.NationalIdentity,
                Password = employee.Password,
                Position = employee.Position,
                CreatedDate = employee.CreatedDate,
            };

            return response;
        }

        public async Task<DeleteEmployeeResponse> DeleteAsync(DeleteEmployeeRequest request)
        {
            Employee employee = await _employeeRepository.GetAsync(x => x.Id == request.UserId);
            employee.Id = request.UserId;
            await _employeeRepository.DeleteAsync(employee);

            DeleteEmployeeResponse response = new DeleteEmployeeResponse()
            {
                UserId = employee.Id,
                UserName = employee.UserName,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                NationalIdentity = employee.NationalIdentity,
                Password = employee.Password,
                Position = employee.Position,
                CreatedDate = employee.CreatedDate,
                DeletedDate = employee.DeletedDate,
                UpdatedDate = employee.UpdatedDate,

            };
            return response;
        }

        public async Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request)
        {
            Employee employee = await _employeeRepository.GetAsync(x => x.Id == request.UserId);
            employee.UserName = request.UserName;
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.DateOfBirth = request.DateOfBirth;
            employee.NationalIdentity = request.NationalIdentity;
            employee.Password = request.Password;
            employee.Position = request.Position;
            await _employeeRepository.UpdateAsync(employee);

            UpdateEmployeeResponse response = new UpdateEmployeeResponse()
            {
                UserId = employee.Id,
                UserName = employee.UserName,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                NationalIdentity = employee.NationalIdentity,
                Password = employee.Password,
                Position = employee.Position,
                CreatedDate = employee.CreatedDate,
                UpdatedDate = employee.UpdatedDate,

            };
            return response;
        }
    }
}
