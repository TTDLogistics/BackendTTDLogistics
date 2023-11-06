namespace EmployeeMangementSystem_DAL.Repositories.Implement;

public class EmployeeService : BaseRepository<EmployeeDetailsEntity>, IEmployee
{
    private readonly EmployeeDbContext _context;
    public EmployeeService(EmployeeDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EmployeeDetailsEntity>> GetEmpDeatilsById(int empId)
    {
        try
        {
            return await _context.Employee.Where(x=>x.EmployeeId==empId).ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
