namespace EmployeeMangementSystem_DAL.Repositories.Implement;

public class RoleServices:BaseRepository<RoleEntity>,IRole
{
    private readonly EmployeeDbContext _employeeDbContext;
    public RoleServices(EmployeeDbContext context):base(context)
    {
        _employeeDbContext = context;
    }

    public async Task<IEnumerable<RoleEntity>> GetRoleByIdAsync(int roleId)
    {
        try
        {
            return await _employeeDbContext.Role.Where(x => x.Status == true && x.RoleId == roleId).ToListAsync();
        }
        catch(Exception)
        {
            throw;
        }
    }

    async Task<IEnumerable<RoleEntity>> IRole.GetAllAsync()
    {
        try
        {
            return await _employeeDbContext.Role.Where(x=>x.Status==true).ToListAsync();
        }
        catch(Exception)
        {
            throw;
        }
    }
}
