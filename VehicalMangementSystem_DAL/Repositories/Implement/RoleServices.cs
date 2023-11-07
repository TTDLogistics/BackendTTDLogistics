namespace EmployeeMangementSystem_DAL.Repositories.Implement;

public class RoleServices:BaseRepository<RoleEntity>,IRole
{
    private readonly EmployeeDbContext _employeeDbContext;
    public RoleServices(EmployeeDbContext context):base(context)
    {
        _employeeDbContext = context;
    }

    public async Task<IEnumerable<ResponseRoleDeatils>> GetRoleByIdAsync(int roleId)
    {
        try
        {
            // return await _employeeDbContext.Role.Where(x => x.Status == true && x.RoleId == roleId).ToListAsync();
            return await _employeeDbContext.Role.Where(x => x.Status == true&&x.RoleId==roleId).Select(r => new ResponseRoleDeatils
            {

                RoleId = r.RoleId,
                RoleName = r.RoleName,
                Status = r.Status,
            }).ToListAsync();
        }
        catch(Exception)
        {
            throw;
        }
    }

    async Task<IEnumerable<ResponseRoleDeatils>> IRole.GetAllAsync()
    {
        try
        {
            return await _employeeDbContext.Role.Where(x => x.Status == true).Select(r => new ResponseRoleDeatils
            {

                RoleId = r.RoleId,
                RoleName = r.RoleName,
                Status = r.Status,
            }).ToListAsync();
        }
        catch(Exception)
        {
            throw;
        }
    }
}
