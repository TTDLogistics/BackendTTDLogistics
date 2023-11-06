namespace EmployeeMangementSystem_DAL.Repositories.Implement;

public class LocationServices:BaseRepository<LocationEntity>,ILocation
{
    private readonly EmployeeDbContext _employeeDbContext;
    public LocationServices(EmployeeDbContext  context):base(context)
    {
        _employeeDbContext = context;
    }

    public async Task<IEnumerable<LocationEntity>> GetAllLocationsAsync()
    {
       try
        {
            return await _employeeDbContext.Location.Where(x=>x.Status==true).ToListAsync();
        }
        catch(Exception )
        {
            throw;
        }
    }

    public async Task<IEnumerable<LocationEntity>> GetLocationsAsyncById(int locationId)
    {
       try
        {
            return await _employeeDbContext.Location.Where(x => x.Status == true && x.LocationId == locationId).ToListAsync();
        }
        catch(Exception )
        {
            throw;
        }
    }
}
