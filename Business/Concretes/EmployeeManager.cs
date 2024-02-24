using AutoMapper;
using Business.Abstract;
using Business.Dtos.EmployeeDto.Request;
using Business.Dtos.EmployeeDto.Response;
using DataAccess.Abstract;
using DataAccess.Utilities.Results;
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
        private readonly IMapper _mapper;

        public EmployeeManager(IEmployeeRepository employeeRepository,IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllEmployeeResponse>>> GetAll()
        {
            List<GetAllEmployeeResponse> employees = _mapper.Map<List<GetAllEmployeeResponse>>(await _employeeRepository.GetAllAsync());
                
            return new SuccessDataResult<List<GetAllEmployeeResponse>>(employees,"Başarıyla Listelendi");
        }

        public async Task<IDataResult<GetByIdEmployeeResponse>> GetById(int id)
        {
            GetByIdEmployeeResponse response = _mapper.Map<GetByIdEmployeeResponse>(await _employeeRepository.GetAsync(x=>x.Id==id));

            return new SuccessDataResult<GetByIdEmployeeResponse>(response,"Başarıyla listelendi");
        }

        public async Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
        {
            Employee employee = _mapper.Map<Employee>(request);
            await _employeeRepository.AddAsync(employee);

            CreateEmployeeResponse response = _mapper.Map<CreateEmployeeResponse>(employee);

            return new SuccessDataResult<CreateEmployeeResponse>(response,"Başarıyla Eklendi");
        }

        public async Task<IDataResult<DeleteEmployeeResponse>> DeleteAsync(DeleteEmployeeRequest request)
        {
            Employee employee = await _employeeRepository.GetAsync(x => x.Id == request.Id);
            await _employeeRepository.DeleteAsync(employee);

            DeleteEmployeeResponse response = _mapper.Map<DeleteEmployeeResponse>(employee);
            return new SuccessDataResult<DeleteEmployeeResponse>(response,"Başarıyla Silindi");
        }

        public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
        {
            Employee employee = _mapper.Map<Employee>(request);
            await _employeeRepository.UpdateAsync(employee);

            UpdateEmployeeResponse response = _mapper.Map<UpdateEmployeeResponse>(employee);
            return new SuccessDataResult<UpdateEmployeeResponse>(response,"Başarıyla Güncellendi.");
        }
    }
}
