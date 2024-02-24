using Business.Abstract;
using Business.Dtos.InstructorDto.Request;
using Business.Dtos.InstructorDto.Response;
using DataAccess.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAll()
        {
            return await _instructorService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IDataResult<GetByIdInstructorResponse>> GetById(int id)
        {
            return await _instructorService.GetById(id);
        }

        [HttpPost]
        public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
        {
            return await _instructorService.AddAsync(request);
        }

        [HttpDelete]
        public async Task<IDataResult<DeleteInstructorResponse>> DeleteAsync(DeleteInstructorRequest request)
        {
            return await _instructorService.DeleteAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
        {
            return await _instructorService.UpdateAsync(request);
        }

    }
}