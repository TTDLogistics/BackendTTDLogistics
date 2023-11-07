
namespace EmployeeMangementSystem.Controllers.Location;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocation _location;
    public LocationController(ILocation location)
    {
        _location = location;
    }
    [HttpGet("GetAllRoleDetails")]
    public async Task<IEnumerable<ResponseLocationDetails>> GetAllRoleDetails()
    {
        try
        {
            return await _location.GetAllLocationsAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet("GetLocationsAsyncById")]
    public async Task<IEnumerable<ResponseLocationDetails>> GetLocationsAsyncById(int locationId)
    {
        try
        {
            return await _location.GetLocationsAsyncById(locationId);
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpPost("InsertUpdateLocation")]
    public async Task<ResponseLocation> InsertUpdateLocation([FromBody] LocationEntity locationEntity)
    {
        try
        {
            if (locationEntity != null)
            {
                var result = _location.Get(x => x.LocationId == locationEntity.LocationId);
                if (result != null)
                {
                    var updatLocation = _location.Update(locationEntity);
                    return new ResponseLocation { message = "Data Updated Successfully.", Location = updatLocation };
                }
                else
                {
                    return new ResponseLocation { message = "Data Saved Successfully", Location = await _location.AddAsync(locationEntity) };
                }
            }
            return new ResponseLocation() { message = " Unable to insert the Location data please validate data \r\non screen and try again else contact your administrator." };
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpPost("DeleteLocationInfo")]
    public async Task<ResponseRole> DeleteLocationInfo(int locationId)
    {
        try
        {
            if ( locationId!= null)
            {
                var result = _location.Get(locationId);

                if (true)
                {
                    result.Status = false;
                    _location.Update(result);
                }
                return new ResponseRole() { message = "Successfully Deleted Location Details" };
            }
            return new ResponseRole() { message = "Failed to deleted Location Details, please contact your administrator" };
        }
        catch (ArgumentException argumentException)
        {
            throw argumentException;
        }
    }
}
