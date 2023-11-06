namespace EmployeeMangementSystem_Entity.Role;

public class RoleEntity:CommonProperties
{
    [Key]
    public int RoleId { get; set; }
    public string? RoleName { get; set; }
}
