namespace EmployeeMangementSystem.Controllers.Role;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRole _role; 
    public RoleController(IRole role)
    {
        _role = role;      
    }
    [HttpGet ("GetAllRoleDetails")]
    public async Task<IEnumerable<RoleEntity>> GetAllRoleDetails()
    {
        try
        {
            return await _role.GetAllAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet("GetRoleByIdAsync")]
    public async Task<IEnumerable<RoleEntity>> GetRoleByIdAsync(int roleId)
    {
        try
        {
            return await _role.GetRoleByIdAsync(roleId);
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpPost("InsertUpdateRole")]
    public async Task<ResponseRole> InsertUpdateRole([FromBody] RoleEntity roleEntity)
    {
        try
        {
            if (roleEntity != null)
            {
                var result = _role.Get(x => x.RoleId == roleEntity.RoleId);
                if (result != null)
                {
                    var updateRole = _role.Update(roleEntity);
                    return new ResponseRole { message = "Data Updated Successfully.", Role = updateRole };
                }
                else
                {
                    return new ResponseRole { message = "Data Saved Successfully", Role = await _role.AddAsync(roleEntity) };              
                }
            }
            return new ResponseRole() { message = " Unable to insert the Role data please validate data \r\non screen and try again else contact your administrator." };
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpPost("DeleteRoleInfo")]
    public async Task<ResponseRole> DeleteRoleInfo(int roleId)
    {
        try
        {
            if (roleId != null)
            {
                var result = _role.Get(roleId);

                if (true)
                {
                    result.Status = false;
                    _role.Update(result);
                }
                return new ResponseRole() { message = "Successfully Deleted Role Details" };
            }
            return new ResponseRole() { message = "Failed to deleted Role Details, please contact your administrator" };
        }
        catch (ArgumentException argumentException)
        {
            throw argumentException;
        }
    }
}
