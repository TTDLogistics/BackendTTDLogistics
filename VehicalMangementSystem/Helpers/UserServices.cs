namespace EmployeeMangementSystem.Helpers;

public class UserServices: BaseRepository<Users>, IUser
{
    private readonly EmployeeDbContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;
    public UserServices(EmployeeDbContext context, IMapper mapper, IJwtUtils jwtUtils) : base(context)
    {
        _context = context;
        _mapper = mapper;
        _jwtUtils = jwtUtils;
    }
    
    //public UserServices(IMSDbContext context, IMapper mapper, IJwtUtils jwtUtils)
    //{
    //    _context = context;
    //    _mapper = mapper;
    //    _jwtUtils = jwtUtils;
    //}
    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user =  _context.Users.SingleOrDefault(x => x.userName == model.Username);

        // validate
        if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            throw new AppException("Username or password is incorrect");

        // authentication successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = _jwtUtils.GenerateToken(user);
        return response;
    }

    public IEnumerable<Users> GetAll()
    {
        return  _context.Users;
    }

    public Users GetById(int id)
    {
        return getUser(id);
    }

    //public void Register(IList<RegisterRequest> model)
    //{


    //    foreach (var user in model)
    //    {
    //        if (string.IsNullOrEmpty(user.userName))
    //        {
    //            continue;
    //        }
    //        var userEnitity = _context.Users.Any(x => x.userName.Equals(user.userName));
    //        validate
    //        if (_context.Users.Any(x => x.userName == user.userName))
    //            throw new AppException("Username '" + user.userName + "' is already taken");

    //        Create a new instance of the user entity
    //        var newUser = new Users
    //        {
    //            designation = user.designation,
    //            userName = user.userName,
    //            emailId = user.emailId,
    //            mobileNo = user.mobileNo,
    //            userRole = user.userRole,
    //            PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.password)
    //             Set other properties accordingly
    //        };
    //        Add the new user entity to the context's DbSet
    //        _context.Set<Users>().Add(newUser);
    //    }

    //    Save changes to persist the users in the database
    //    _context.SaveChanges();
    //}

    public void Register(IList<RegisterRequest> model)
    {

        foreach (var user in model)
        {
            if (string.IsNullOrEmpty(user.userName))
            {
                continue;
            }


            if (_context.Users.Any(x => x.userName == user.userName))
            {
                var existingUser = _context.Users.SingleOrDefault(x => x.userName == user.userName);
                // var existingUser = _context.Set<Users>(x => x.userName == user.userName);

                if (existingUser != null)
                {
                    // Modify the properties of the existing user
                    existingUser.designation = user.designation;
                    //   existingUser.userName = user.userName;
                    //existingUser.loginName = user.loginName;
                    // existingUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.);
                    existingUser.emailId = user.emailId;
                    existingUser.mobileNo = user.mobileNo;
                    existingUser.userRole = user.userRole;
                    //  existingUser.Id = user.Id;

                    // Modify other properties as needed
                }
            }
            else
            {
                // Create a new instance of the user entity
                var newUser = new Users
                {
                    designation = user.designation,
                    userName = user.userName,
                    emailId = user.emailId,
                    mobileNo = user.mobileNo,
                    userRole = user.userRole,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.password)
                    // Set other properties accordingly
                };
                // Add the new user entity to the context's DbSet
                _context.Set<Users>().Add(newUser);

            }

            // Save changes to persist the users in the database
            _context.SaveChanges();
        }


    }




    public void Update(IList<UpdateRequest> model)
    {
        foreach (var user in model)
        {
            //if (_context.Users.Any(x => x.userName == user.userName))
            //    throw new AppException("Username '" + user.userName + "' is already taken");

            // Retrieve the user from the database
            var existingUser = _context.Set<Users>().Find(user.Id);

            if (existingUser != null)
            {
                // Modify the properties of the existing user
                existingUser.designation = user.designation;
                //   existingUser.userName = user.userName;
                existingUser.loginName = user.loginName;
                // existingUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.);
                existingUser.emailId = user.emailId;
                existingUser.mobileNo = user.mobileNo;
                existingUser.userRole = user.userRole;
                existingUser.Id = user.Id;

                // Modify other properties as needed
            }
        }

        // Save changes to persist the updates in the database
        _context.SaveChanges();
    }
    public void Delete(int id)
    {
        var user = getUser(id);
       // user.Status = false;
        _context.Users.Update(user);
        _context.SaveChanges();
    }
    public bool ResetPassword(string userName, string newPassword,string oldPassword)
    {
        var user = _context.Users.FirstOrDefault(u => u.userName == userName);
        if (user == null)
        {
            return false; // Invalid or expired reset token
        }
        if (user == null || !BCrypt.Net.BCrypt.Verify(oldPassword, user.PasswordHash))
            throw new AppException("Username or password is incorrect");
        // Update the user's password
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
       // _mapper.Map(userName,newPassword, user);
        _context.Users.Update(user);
        _context.SaveChanges();
        return true; // Password reset successful
    }

    // helper methods

    private Users getUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}
