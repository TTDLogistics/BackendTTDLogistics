namespace EmployeeMangementSystem_DAL.Repositories.Interface;

public interface IEmployee:IBaseRepository<EmployeeDetailsEntity>
{
   // Task<ResponseEmployee> InsertUpdateEmployee(EmployeeDetailsEntity employeeDetailsEntity);
   Task<IEnumerable<EmployeeDetailsEntity>> GetEmpDeatilsById(int  empId);
}
