using Business.Abstract;
using Business.Dtos.InstructorDto.Request;
using Business.Dtos.InstructorDto.Response;
using DataAccess.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : BaseController
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleDataResult(await _instructorService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return HandleDataResult(await _instructorService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateInstructorRequest request)
        {
            return HandleDataResult(await _instructorService.AddAsync(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteInstructorRequest request)
        {
            return HandleDataResult(await _instructorService.DeleteAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateInstructorRequest request)
        {
            return HandleDataResult(await _instructorService.UpdateAsync(request));
        }

    }
}