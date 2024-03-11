using Business.Abstract;
using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.EmployeeDto.Request;
using Business.Dtos.InstructorDto.Request;
using Core.Utilities.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register applicant")]
        public async Task<IActionResult> Register(CreateApplicantRequest request)
        {
            return HandleDataResult(await _authService.RegisterApplicant(request));
        }
        [HttpPost("register employee")]
        public async Task<IActionResult> Register(CreateEmployeeRequest request)
        {
            return HandleDataResult(await _authService.RegisterEmployee(request));
        }
        [HttpPost("register instructor")]
        public async Task<IActionResult> Register(CreateInstructorRequest instructorForRegisterDto)
        {
            var result = await _authService.RegisterInstruntor(instructorForRegisterDto);
            return HandleDataResult(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var result = await _authService.Login(userForLoginDto);
            return HandleDataResult(result);
        }
    }
}
