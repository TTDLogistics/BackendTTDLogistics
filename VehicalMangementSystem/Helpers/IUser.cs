namespace EmployeeMangementSystem.Helpers;

public interface IUser:IBaseRepository<Users>
{
   AuthenticateResponse Authenticate(AuthenticateRequest model);
   IEnumerable<Users> GetAll();
   Users GetById(int id);
   bool ResetPassword(string userName, string newPassword,string oldPassword);
    void Register(IList<RegisterRequest> model);
    void Update(IList<UpdateRequest> model);
    void Delete(int id);
}
