namespace EmployeeMangementSystem_Entity.Employee;

public class EmployeeDetailsEntity : CommonProperties
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeId { get; set; }
    public int RoleId { get; set; }
    public int LocationId { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public int PhoneNumber { get; set; }
    public int EmergencyPhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
  //  public string? ProfileImage { get; set; }
    public int FingerPrintId { get; set; }
    public string? EmailAddress { get; set; }
    public bool IsActive { get; set; }
    public DateTime JoiningDate { get; set; }
    public string? CurrentAddress { get; set; }
    public string? PermanentAddress { get; set; }
    public string? AlternateAddress { get; set; }
    public bool MaritalStatus { get;set; }
    public string? BloodGroup { get;set; }
    public string? AdharNumber { get; set; }
    public string? PanNumber { get; set; }
    public string? VoterId { get; set;   }
    public string? RationCard { get; set; }
    public string? LicenceNumber { get; set; }
    public DateTime LicenceValidity { get; set; }
    public string? BadgeNumber { get;set; }
    public string? BankAccountNumber { get; set; }
    public string? BankName { get;set; }
    public string? BankIFSCCode { get; set; }
    public string? DulySignedCheckNumber { get;set; }
    public string? Education { get; set; }
    public decimal TotalYearsOfEducation { get; set; }
    public string? PreviousEmploymentDetails { get; set; }
    public string? pliticalAffliations { get; set; }
    public string? CriminalOffence { get;set; }
    public string? CourtCasePending { get;set; }
    //public ICollection<LocationEntity> LocationEntities { get; set; }
    //public ICollection<RoleEntity> RoleEntities { get; set; }
}
