namespace EmployeeMangementSystem_DAL.Repositories.Interface;

public interface IRole:IBaseRepository<RoleEntity>
{
    Task <IEnumerable<RoleEntity>> GetAllAsync();
    Task<IEnumerable<RoleEntity>> GetRoleByIdAsync(int roleId);

}
