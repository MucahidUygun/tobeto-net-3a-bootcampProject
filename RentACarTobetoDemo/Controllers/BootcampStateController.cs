using Business.Abstract;
using Business.Dtos.BootcampStateDto.Request;
using Business.Dtos.BootcampStateDto.Response;
using DataAccess.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampStateController : BaseController
    {
        private readonly IBootcampStateService _service;

        public BootcampStateController(IBootcampStateService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBootcampStateRequest request)
        {
            return HandleDataResult(await _service.AddAsync(request));
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
        public async Task<IActionResult> Update(UpdateBootcampStateRequest request)
        {
            return HandleDataResult(await _service.UpdateAsync(request));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete (DeleteBootcampStateRequest request)
        {
            return HandleDataResult(await _service.Delete(request));
        }
    }
}
