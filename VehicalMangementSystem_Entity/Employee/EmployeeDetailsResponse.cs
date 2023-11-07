
namespace EmployeeMangementSystem_Entity.Employee;

public class EmployeeDetailsResponse
{
    public int EmployeeId { get; set; }
    public int RoleId { get; set; }
    public int LocationId { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? EmergencyPhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? ProfileImage { get; set; }
    public int FingerPrintId { get; set; }
    public string? EmailAddress { get; set; }
    public bool Status { get; set; }
    public DateTime JoiningDate { get; set; }
    public string? CurrentAddress { get; set; }
    public string? PermanentAddress { get; set; }
    public string? AlternateAddress { get; set; }
    public string? MaritalStatus { get; set; }
    public string? BloodGroup { get; set; }
    public string? AdharNumber { get; set; }
    public string? PanNumber { get; set; }
    public string? VoterId { get; set; }
    public string? RationCard { get; set; }
    public string? LicenceNumber { get; set; }
    public DateTime LicenceValidity { get; set; }
    public string? BadgeNumber { get; set; }
    public string? BankAccountNumber { get; set; }
    public string? BankName { get; set; }
    public string? BankIFSCCode { get; set; }
    public string? DulySignedCheckNumber { get; set; }
    public string? Education { get; set; }
    public double TotalYearsOfEducation { get; set; }
    public string? PreviousEmploymentDetails { get; set; }
    public string? PoliticalAffliations { get; set; }
    public string? CriminalOffence { get; set; }
    public string? CourtCasePending { get; set; }
}
