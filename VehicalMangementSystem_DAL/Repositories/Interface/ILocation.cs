namespace EmployeeMangementSystem_DAL.Repositories.Interface;

public interface  ILocation:IBaseRepository<LocationEntity>
{
    Task<IEnumerable<LocationEntity>> GetAllLocationsAsync();
    Task<IEnumerable<LocationEntity>> GetLocationsAsyncById(int locationId);
}
