using AutoMapper;
using Azure.Core;
using Business.Abstract;
using Business.Constants.Messages;
using Business.Dtos.EmployeeDto.Request;
using Business.Dtos.EmployeeDto.Response;
using Business.Rules;
using Core.Exceptions.Types;
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
        private readonly EmployeeBusinessRules _rules;
        private readonly IMapper _mapper;

        public EmployeeManager(IEmployeeRepository employeeRepository,IMapper mapper,EmployeeBusinessRules rules)
        {
            _rules = rules;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync()
        {
            List<GetAllEmployeeResponse> employees = _mapper.Map<List<GetAllEmployeeResponse>>(await _employeeRepository.GetAllAsync());
                
            return new SuccessDataResult<List<GetAllEmployeeResponse>>(employees, EmployeeMessages.GetAllListed);
        }

        public async Task<IDataResult<GetByIdEmployeeResponse>> GetByIdAsync(int id)
        {
            await _rules.CheckIdIsExists(id);
            Employee employee = await _employeeRepository.GetAsync(x => x.Id == id);
            GetByIdEmployeeResponse response = _mapper.Map<GetByIdEmployeeResponse>(employee);

            return new SuccessDataResult<GetByIdEmployeeResponse>(response, EmployeeMessages.GetByIdListed);
        }

        public async Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
        {
            Employee employee = _mapper.Map<Employee>(request);
            await _employeeRepository.AddAsync(employee);

            CreateEmployeeResponse response = _mapper.Map<CreateEmployeeResponse>(employee);

            return new SuccessDataResult<CreateEmployeeResponse>(response, EmployeeMessages.Added);
        }

        public async Task<IResult> DeleteAsync(DeleteEmployeeRequest request)
        {
            await _rules.CheckIdIsExists(request.Id);
            Employee employee = await _employeeRepository.GetAsync(x => x.Id == request.Id);
            await _employeeRepository.DeleteAsync(employee);

            return new SuccessResult(EmployeeMessages.Deleted);
        }

        public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
        {
            await _rules.CheckIdIsExists(request.Id);
            Employee employee =await _employeeRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request,employee);
            await _employeeRepository.UpdateAsync(employee);

            UpdateEmployeeResponse response = _mapper.Map<UpdateEmployeeResponse>(employee);
            return new SuccessDataResult<UpdateEmployeeResponse>(response, EmployeeMessages.Updated);
        }
        
    }
}
