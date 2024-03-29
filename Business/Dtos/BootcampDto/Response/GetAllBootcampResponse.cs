﻿namespace Business.Dtos.BootcampDto.Response
{
    public class GetAllBootcampResponse
    {
        public string Name { get; set; }
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set; }
        public DateTime InstructorDateOfBirth { get; set; }
        public string InstructorNationalIdentity { get; set; }
        public string InstructorEmail { get; set; }
        public string InstructorPassword { get; set; }
        public string InstructorCompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string BootcampStateName { get; set; }
    }
}
