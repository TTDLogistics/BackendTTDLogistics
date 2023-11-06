namespace EmployeeMangementSystem_Entity.UserLogin;

public class Users:CommonProperties
{
    public int Id { get; set; }
    public string userName { get; set; }
    public string? userRole { get; set; }
    public string? designation { get; set; }
    public string? emailId { get; set; }
    public string? mobileNo { get; set; }
    public string? loginName { get; set; }

    //  [JsonIgnore]
    public string PasswordHash { get; set; }
}
