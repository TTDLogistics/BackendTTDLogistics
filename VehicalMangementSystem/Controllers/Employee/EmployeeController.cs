using EmployeeMangementSystem_Entity.Employee;
using EmployeeMangementSystem_Entity.Location;
using EmployeeMangementSystem_Entity.Role;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangementSystem.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpGet("GetAllEmpDeatils")]
        public async Task<IEnumerable<EmployeeDetailsEntity>> GetAllEmpDeatils()
        {
            try
            {
                var result = await _employee.GetAllAsync();
                return result;
            }
            catch (ArgumentException argumentException)
            {
                //_logger.LogError(argumentException, "ArgumentException caught in GetOutTurnSummaryNoDetails");
                throw argumentException;
            }
        }
        [HttpGet("GetEmpDeatilsById")]
        public async Task<IEnumerable<EmployeeDetailsEntity>> GetEmpDeatilsById(int empId)
        {
            try
            {
                return await _employee.GetEmpDeatilsById(empId);
            }
            catch (ArgumentException argumentException)
            {
                //_logger.LogError(argumentException, "ArgumentException caught in GetOutTurnSummaryNoDetails");
                throw argumentException;
            }
        }
        [HttpPost("InsertUpdateEmployee")]
        public async Task<ResponseEmployee> InsertUpdateEmployee([FromBody] EmployeeDetailsEntity employeeDetailsEntity)
        {

            try
            {           
                if (employeeDetailsEntity != null)
                {
                    var result = _employee.Get(x => x.EmployeeId == employeeDetailsEntity.EmployeeId);
                    if (result != null)
                    {             
                       var updateEmployee = _employee.Update(employeeDetailsEntity);
                        return new ResponseEmployee { message = "Data Updated Successfully.", EmployeeDetails = updateEmployee };
                    }
                    else
                    {
                        var response = await _employee.AddAsync(employeeDetailsEntity);
                        return new ResponseEmployee { message = "Data Saved Successfully",EmployeeDetails=response };
                    }
                }
                return new ResponseEmployee() { message = " Unable to insert the employee data please validate data \r\non screen and try again else contact your administrator." };
            }
            catch(Exception)
            {
                throw;
            }
        }
        [HttpPost("DeleteEmpInfo")]
        public async Task<ResponseEmployee> DeleteEmpInfo(int empId)
        {
            try
            {
                if (empId != null)
                {
                    var result =  _employee.Get(empId);

                    if (result.EmployeeId != null)
                    {
                        result.Status = false;
                        result.IsActive = false;
                        _employee.Update(result);
                    }
                    return new ResponseEmployee() { message = "Successfully Deleted Employee Details" };
                }
                return new ResponseEmployee() { message = "Failed to deleted Employee Details, please contact your administrator" };
            }
            catch (ArgumentException argumentException)
            {
               // _logger.LogError(argumentException, "ArgumentException caught in DeleteRCNInfo");
                throw argumentException;
            }
        }

    }
}
