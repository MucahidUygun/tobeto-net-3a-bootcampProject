using Business.Abstract;
using Business.Dtos.ApplicationStateDto.Request;
using Business.Dtos.ApplicationStateDto.Response;
using DataAccess.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStateController : BaseController
    {
        private readonly IApplicationStateService _service;

        public ApplicationStateController(IApplicationStateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleDataResult(await _service.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return HandleDataResult(await _service.GetByIdApplicationStateAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateApplicationStateRequest request)
        {
            return HandleDataResult(await _service.AddAsync(request));
        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateApplicationStateRequest request)
        {
            return HandleDataResult(await _service.UpdateAsync(request));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete (DeleteApplicationStateRequest request)
        {
            return HandleDataResult(await _service.DeleteAsync(request));
        }
    }
}
