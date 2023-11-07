namespace EmployeeMangementSystem_DAL.Repositories.Interface;

public interface  ILocation:IBaseRepository<LocationEntity>
{
    Task<IEnumerable<ResponseLocationDetails>> GetAllLocationsAsync();
    Task<IEnumerable<ResponseLocationDetails>> GetLocationsAsyncById(int locationId);
}
