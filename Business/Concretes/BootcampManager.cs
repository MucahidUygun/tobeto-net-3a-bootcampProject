﻿using AutoMapper;
using Azure.Core;
using Business.Abstract;
using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.BootcampDto.Request;
using Business.Dtos.BootcampDto.Response;
using Core.Exceptions.Types;
using DataAccess.Abstract;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BootcampManager : IBootcampService
    {
        private readonly IBootcampRepository _repository;
        private readonly IMapper _mapper;
        private readonly IInstructorService _instructorService;

        public BootcampManager(IBootcampRepository repository,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IDataResult<CreateBootcampResponse>> CreateAsync(CreateBootcampRequest request)
        {
            await CheckInstructorIdIsExits(request.InstructorId);
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            await _repository.AddAsync(bootcamp);
            CreateBootcampResponse response = _mapper.Map<CreateBootcampResponse>(bootcamp);
            return new SuccessDataResult<CreateBootcampResponse>(response,"Ekle Başarılı");
        }

        public async Task<IResult> DeleteAsync(DeleteBootcampRequest request)
        {
            await CheckIdIsExists(request.Id);
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            await _repository.DeleteAsync(bootcamp);
            DeleteBootcampResponse response = _mapper.Map<DeleteBootcampResponse>(bootcamp);
            return new SuccessResult("Silme Başarılı");
        }

        public async Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync()
        {
            List<Bootcamp> bootcamps = await _repository.GetAllAsync(include:x=>x.Include(x=>x.Instructor).Include(x=>x.BootcampState));
            List<GetAllBootcampResponse> responses = _mapper.Map<List<GetAllBootcampResponse>>(bootcamps);
            return new SuccessDataResult<List<GetAllBootcampResponse>>(responses,"Listelendi");
        }

        public async Task<IDataResult<GetByIdBootcampResponse>> GetByIdAsync(int id)
        {
            await CheckIdIsExists(id);
            Bootcamp bootcamp = await _repository.GetAsync(x=>x.Id == id, include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState));
            GetByIdBootcampResponse response = _mapper.Map<GetByIdBootcampResponse>(bootcamp);
            return new SuccessDataResult<GetByIdBootcampResponse>(response, "Listelendi");
        }

        public async Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
        {
            await CheckIdIsExists(request.Id);
            await CheckInstructorIdIsExits(request.InstructorId);
            Bootcamp bootcamp = await _repository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request,bootcamp);
            await _repository.UpdateAsync(bootcamp);
            UpdateBootcampResponse response = _mapper.Map<UpdateBootcampResponse>(bootcamp);
            return new SuccessDataResult<UpdateBootcampResponse>(response,"Güncellendi.");
        }
        public async Task CheckIdIsExists(int id)
        {
            var entity = await _repository.GetAsync(x => x.Id == id);
            if (entity is null)
                throw new BusinessException("Bootcamp already not exists");
        }

        public async Task CheckInstructorIdIsExits(int id)
        {
            await _instructorService.CheckIdIsExists(id);
        }
    }
}
