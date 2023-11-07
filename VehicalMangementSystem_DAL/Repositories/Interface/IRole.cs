namespace EmployeeMangementSystem_DAL.Repositories.Interface;

public interface IRole:IBaseRepository<RoleEntity>
{
    Task <IEnumerable<ResponseRoleDeatils>> GetAllAsync();
    Task<IEnumerable<ResponseRoleDeatils>> GetRoleByIdAsync(int roleId);

}
