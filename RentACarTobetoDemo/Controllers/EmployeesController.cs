using Business.Abstract;
using Business.Dtos.EmployeeDto.Request;
using Business.Dtos.EmployeeDto.Response;
using DataAccess.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleDataResult(await _employeeService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return HandleDataResult(await _employeeService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateEmployeeRequest request)
        {
            return HandleDataResult(await _employeeService.AddAsync(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteEmployeeRequest request)
        {
            return HandleDataResult(await _employeeService.DeleteAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateEmployeeRequest request)
        {
            return HandleDataResult(await _employeeService.UpdateAsync(request));
        }
    }
}
