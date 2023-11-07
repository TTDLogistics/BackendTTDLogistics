namespace EmployeeMangementSystem_DAL.Repositories.Implement;

public class LocationServices:BaseRepository<LocationEntity>,ILocation
{
    private readonly EmployeeDbContext _employeeDbContext;
    public LocationServices(EmployeeDbContext  context):base(context)
    {
        _employeeDbContext = context;
    }

    public async Task<IEnumerable<ResponseLocationDetails>> GetAllLocationsAsync()
    {
       try
        {
           // return await _employeeDbContext.Location.Where(x=>x.Status==true).ToListAsync();
           return await _employeeDbContext.Location.Where(x=>x.Status==true).Select(x=> new ResponseLocationDetails
           { 
               LocationId = x.LocationId,
               LocationName = x.LocationName,
               Status=x.Status
           }).ToListAsync();  
        }
        catch(Exception )
        {
            throw;
        }
    }

    public async Task<IEnumerable<ResponseLocationDetails>> GetLocationsAsyncById(int locationId)
    {
       try
        {
            return await _employeeDbContext.Location.Where(x => x.Status == true&&x.LocationId==locationId).Select(x => new ResponseLocationDetails
            {
                LocationId = x.LocationId,
                LocationName = x.LocationName,
                Status = x.Status
            }).ToListAsync();
        }
        catch(Exception )
        {
            throw;
        }
    }
}
