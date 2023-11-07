namespace EmployeeMangementSystem_DAL.Repositories.Implement;

public class EmployeeService : BaseRepository<EmployeeDetailsEntity>, IEmployee
{
    private readonly EmployeeDbContext _context;
    public EmployeeService(EmployeeDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EmployeeDetailsResponse>> GetAllEmpDeatils()
    {
       try
        {
            var empResponse = await _context.Employee.Where(x => x.Status == true).Select(e=>new EmployeeDetailsResponse
            {

                EmployeeId = e.EmployeeId,
                Status = e.Status,
                AdharNumber = e.AdharNumber,
                AlternateAddress = e.AlternateAddress,
                BadgeNumber= e.BadgeNumber,
                BankAccountNumber = e.BankAccountNumber,
                BankIFSCCode = e.BankIFSCCode,
                BankName = e.BankName,
                BloodGroup= e.BloodGroup,
                CourtCasePending= e.CourtCasePending,
                CriminalOffence= e.CriminalOffence,
                CurrentAddress= e.CurrentAddress,
                DateOfBirth = e.DateOfBirth,
                DulySignedCheckNumber   = e.DulySignedCheckNumber,
                Education=e.Education,
                EmailAddress=e.EmailAddress,
                EmergencyPhoneNumber   =e.EmergencyPhoneNumber,
                FingerPrintId=e.FingerPrintId,
                FirstName=e.FirstName,
                JoiningDate=e.JoiningDate,
                LastName=e.LastName,
                LicenceNumber=e.LicenceNumber,
                LicenceValidity=e.LicenceValidity,
                LocationId=e.LocationId,
                MaritalStatus=e.MaritalStatus,
                MiddleName= e.MiddleName,
                PanNumber=e.PanNumber,
                PermanentAddress= e.PermanentAddress,
                PhoneNumber=Convert.ToString(e.PhoneNumber),
                PoliticalAffliations=e.PoliticalAffliations,
                PreviousEmploymentDetails=e.PreviousEmploymentDetails,
                ProfileImage=e.ProfileImage,
                RationCard=e.RationCard,
                RoleId=e.RoleId,
                TotalYearsOfEducation=e.TotalYearsOfEducation,
                VoterId=e.VoterId

            }).ToListAsync();
            return empResponse;
        }
        catch(Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<EmployeeDetailsResponse>> GetEmpDeatilsById(int empId)
    {
        try
        {
           // return await _context.Employee.Where(x=>x.EmployeeId==empId&& x.Status==true).ToListAsync();
            var empResponse = await _context.Employee.Where(x =>  x.EmployeeId == empId && x.Status == true).Select(e => new EmployeeDetailsResponse
            {

                EmployeeId = e.EmployeeId,
                Status = e.Status,
                AdharNumber = e.AdharNumber,
                AlternateAddress = e.AlternateAddress,
                BadgeNumber = e.BadgeNumber,
                BankAccountNumber = e.BankAccountNumber,
                BankIFSCCode = e.BankIFSCCode,
                BankName = e.BankName,
                BloodGroup = e.BloodGroup,
                CourtCasePending = e.CourtCasePending,
                CriminalOffence = e.CriminalOffence,
                CurrentAddress = e.CurrentAddress,
                DateOfBirth = e.DateOfBirth,
                DulySignedCheckNumber = e.DulySignedCheckNumber,
                Education = e.Education,
                EmailAddress = e.EmailAddress,
                EmergencyPhoneNumber = e.EmergencyPhoneNumber,
                FingerPrintId = e.FingerPrintId,
                FirstName = e.FirstName,
                JoiningDate = e.JoiningDate,
                LastName = e.LastName,
                LicenceNumber = e.LicenceNumber,
                LicenceValidity = e.LicenceValidity,
                LocationId = e.LocationId,
                MaritalStatus = e.MaritalStatus,
                MiddleName = e.MiddleName,
                PanNumber = e.PanNumber,
                PermanentAddress = e.PermanentAddress,
                PhoneNumber = e.PhoneNumber,
                PoliticalAffliations = e.PoliticalAffliations,
                PreviousEmploymentDetails = e.PreviousEmploymentDetails,
                ProfileImage = e.ProfileImage,
                RationCard = e.RationCard,
                RoleId = e.RoleId,
                TotalYearsOfEducation = e.TotalYearsOfEducation,
                VoterId = e.VoterId

            }).ToListAsync();
            return empResponse;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
