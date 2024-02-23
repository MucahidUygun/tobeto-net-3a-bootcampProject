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
    public class ApplicationStateController : ControllerBase
    {
        private readonly IApplicationStateService _service;

        public ApplicationStateController(IApplicationStateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAll()
        {
            return await _service.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<IDataResult<GetByIdApplicationStateResponse>> Get(int id)
        {
            return await _service.GetByIdApplicationStateAsync(id);
        }
        [HttpPost]
        public async Task<IDataResult<CreateApplicationStateResponse>> Add(CreateApplicationStateRequest request)
        {
            return await _service.AddAsync(request);
        }
        [HttpPut]
        public async Task<IDataResult<UpdateApplicationStateResponse>> Update (UpdateApplicationStateRequest request)
        {
            return await _service.UpdateAsync(request);
        }
        [HttpDelete]
        public async Task<IResult> Delete (DeleteApplicationStateRequest request)
        {
            return await _service.DeleteAsync(request);
        }
    }
}
