﻿namespace Business.Dtos.ApplicationDto.Request
{
    public class UpdateApplicationRequest
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public int BootcampId { get; set; }
        public int ApplicationStateId { get; set; }
    }
}
