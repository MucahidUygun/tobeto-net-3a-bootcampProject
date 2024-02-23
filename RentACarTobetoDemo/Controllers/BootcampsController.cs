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
    public class BootcampsController : ControllerBase
    {
        private readonly IBootcampService _service;
        public BootcampsController(IBootcampService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IDataResult<CreateBootcampResponse>> Add(CreateBootcampRequest request) 
        {
            return await _service.CreateAsync(request);
        }

        [HttpGet]
        public async Task<IDataResult<List<GetAllBootcampResponse>>> GetAll() 
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IDataResult<GetByIdBootcampResponse>> GetById(int id) 
        {
            return await _service.GetByIdAsync(id);
        }
        [HttpPut]
        public async Task<IDataResult<UpdateBootcampResponse>> Update(UpdateBootcampRequest request) 
        {
            return await _service.UpdateAsync(request);
        }
        [HttpDelete]
        public async Task<IResult> Delete(DeleteBootcampRequest request)
        {
            return await _service.DeleteAsync(request);
        }
    }
}
