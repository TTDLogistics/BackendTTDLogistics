namespace EmployeeMangementSystem_Entity.UserLogin;

public class ResetpPasswordRequest
{
    [Required]
    public string userName { get; set; }
    [Required]
    public string newPassword { get; set; }
    [Required]
    public string oldPassword { get; set; }
}
