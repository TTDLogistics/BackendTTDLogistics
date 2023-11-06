namespace EmployeeMangementSystem_Entity.Authenticate;

public class RegisterRequest
{
    [Required]
    public string userName { get; set; }

    [Required]
    public string userRole { get; set; }

    [Required]
    public string password { get; set; }
    [Required]
    public string designation { get; set; }
    [Required]
    public string emailId { get; set; }
    [Required]
    public string mobileNo { get; set; }
  
    
}
