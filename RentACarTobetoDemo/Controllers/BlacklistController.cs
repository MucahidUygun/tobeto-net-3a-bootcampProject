using Business.Abstract;
using Business.Dtos.Blacklists.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistController : BaseController
    {
        private readonly IBlacklistService _service;
        public BlacklistController(IBlacklistService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateBlacklistRequest request)
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
            return HandleDataResult(await _service.GetByIdBlacklistAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlacklistRequest request)
        {
            return HandleDataResult(await _service.UpdateAsync(request));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBlacklistRequest request)
        {
            return HandleResult(await _service.DeleteAsync(request));
        }

    }
}
