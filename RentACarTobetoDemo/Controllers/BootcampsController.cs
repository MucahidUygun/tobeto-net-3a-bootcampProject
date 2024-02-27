using Business.Abstract;
using Business.Dtos.BootcampDto.Request;
using Business.Dtos.BootcampDto.Response;
using DataAccess.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampsController : BaseController
    {
        private readonly IBootcampService _service;
        public BootcampsController(IBootcampService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBootcampRequest request) 
        {
            return HandleDataResult(await _service.CreateAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            return HandleDataResult(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            return HandleDataResult(await _service.GetByIdAsync(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBootcampRequest request) 
        {
            return HandleDataResult(await _service.UpdateAsync(request));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBootcampRequest request)
        {
            return HandleResult(await _service.DeleteAsync(request));
        }
    }
}
