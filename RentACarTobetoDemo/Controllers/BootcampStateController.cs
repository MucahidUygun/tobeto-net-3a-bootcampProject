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
    public class BootcampStateController : ControllerBase
    {
        private readonly IBootcampStateService _service;

        public BootcampStateController(IBootcampStateService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IDataResult<CreateBootcampStateResponse>> Create(CreateBootcampStateRequest request)
        {
            return await _service.AddAsync(request);
        }
        [HttpGet]
        public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAll()
        {
            return await _service.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<IDataResult<GetByIdBootcampStateResponse>> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }
        [HttpPut]
        public async Task<IDataResult<UpdateBootcampStateResponse>> Update(UpdateBootcampStateRequest request)
        {
            return await _service.UpdateAsync(request);
        }
        [HttpDelete]
        public async Task<IResult> Delete (DeleteBootcampStateRequest request)
        {
            return await _service.Delete(request);
        }
    }
}
