using Business.Abstract;
using Business.Dtos.ApplicantDtos.Request;
using Business.Dtos.EmployeeDto.Request;
using Business.Dtos.InstructorDto.Request;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IInstructorService _instructorService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IApplicantService _applicantServise;
        private readonly IUserRepository _userRepository;

        public AuthManager(
            IApplicantService applicantService,
            IInstructorService instructorService,
            IEmployeeService employeeService, 
            ITokenHelper tokenHelper,
            IUserRepository userRepository,
            IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userRepository = userRepository;
            _applicantServise = applicantService;
            _instructorService = instructorService;
            _employeeService = employeeService;
            _tokenHelper = tokenHelper;
            _userOperationClaimRepository = userOperationClaimRepository;
        }


        public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
        {
            List<OperationClaim> claims = await _userOperationClaimRepository.Query()
                .AsNoTracking().Where(x => x.UserId == user.Id).Select(x => new OperationClaim 
                { 
                    Id = x.OperationClaimId, 
                    Name = x.OperationClaim.Name 
                }).ToListAsync();
            var accessToken = _tokenHelper.CreateToken(user,claims);
            return new SuccessDataResult<AccessToken>(accessToken,"Created Token");
        }

        public async Task<IDataResult<AccessToken>> Login(UserForLoginDto userForLoginDto)
        {
            User user = await _userRepository.GetAsync(x=>x.Email==userForLoginDto.Email);
            var createAccessToken = await CreateAccessToken(user);
            return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Login Success");
        }

        public async Task<IDataResult<AccessToken>> RegisterApplicant(CreateApplicantRequest request)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password,out passwordHash,out passwordSalt);
            Applicant applicant = new Applicant
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                NationalIdentity = request.NationalIdentity,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                About = request.About,
            };
            await _applicantServise.AddAsync(applicant);

            var createAccessToken = await CreateAccessToken(applicant);

            return new SuccessDataResult<AccessToken>(createAccessToken.Data,"Applicant Register Success");
        }

        public async Task<IDataResult<AccessToken>> RegisterEmployee(CreateEmployeeRequest request)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            Employee employee = new Employee
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                NationalIdentity = request.NationalIdentity,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Position = request.Position,
            };
            await _employeeService.AddAsync(employee);

            var createAccessToken = await CreateAccessToken(employee);

            return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Employee Register Success");
        }

        public async Task<IDataResult<AccessToken>> RegisterInstruntor(CreateInstructorRequest request)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            Instructor instructor = new Instructor
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                NationalIdentity = request.NationalIdentity,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CompanyName = request.CompanyName,
            };
            await _instructorService.AddAsync(instructor);

            var createAccessToken = await CreateAccessToken(instructor);

            return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Employee Register Success");
        }
    }
}
