﻿namespace Business.Dtos.ApplicationDto.Response
{
    public class GetByIdApplicationResponse
    {
        public string ApplicantFirstName { get; set; }
        public string ApplicantLastName { get; set; }
        public DateTime ApplicantDateOfBirth { get; set; }
        public string ApplicantNationalIdentity { get; set; }
        public string ApplicantEmail { get; set; }
        public string ApplicantAbout { get; set; }
        public string BootcampName { get; set; }
        public string ApplicationStateName { get; set; }
    }
}
