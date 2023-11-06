
namespace EmployeeMangementSystem.Helpers;

public interface IJwtUtils
{
    public string GenerateToken(Users user);
    public int? ValidateToken(string token);
}
