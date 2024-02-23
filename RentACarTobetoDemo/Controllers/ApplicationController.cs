using Business.Abstract;
using Business.Dtos.ApplicationDto.Request;
using Business.Dtos.ApplicationDto.Response;
using Business.Dtos.BootcampDto.Request;
using DataAccess.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
        {
            return await _applicationService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IDataResult<GetByIdApplicationResponse>> GetById(int id)
        {
            return await _applicationService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
        {
            return await _applicationService.AddAsync(request);
        }

        [HttpDelete]
        public async Task<IResult> DeleteAsync(DeleteApplicationRequest request)
        {
            return await _applicationService.DeleteAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
        {
            return await _applicationService.UpdateAsync(request);
        }
        
    }
}
