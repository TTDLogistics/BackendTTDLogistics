namespace EmployeeMangementSystem.Controllers.Login;

[Authorization.Authorize]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUser _userService;
    private IMapper _mapper;
    private readonly Helpers.AppSettings _appSettings;
    //private readonly ILogger<UsersController> _logger;
    private readonly ILogger<UsersController> _logger;

    public UsersController(
        IUser userService,
        IMapper mapper,
        IOptions<Helpers.AppSettings> appSettings, ILogger<UsersController> logger)
    {
        _userService = userService;
        _appSettings = appSettings.Value;
        _mapper = mapper;
        _logger = logger;
    }

    [Authorization.AllowAnonymous]
    [HttpGet("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        try
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }
        catch (ArgumentException argumentException)
        {
            _logger.LogError(argumentException, "ArgumentException caught in Authenticate");
            throw argumentException;
        }
    }
    [Authorization.AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register([FromBody] IList<RegisterRequest> model)
    {
        try
        {
            _userService.Register(model);
            return Ok(new { message = "Registration successful" });
        }
        catch (ArgumentException argumentException)
        {
            _logger.LogError(argumentException, "ArgumentException caught in Register");
            throw argumentException;
        }
    }
    [Authorization.AllowAnonymous]
    [HttpPost("ResetPassword")]
    public ResponseLogin ResetPassword([FromBody] ResetpPasswordRequest resetpPasswordRequest)
    {
        try
        {
            if (resetpPasswordRequest.userName != null && resetpPasswordRequest.newPassword != null && resetpPasswordRequest.oldPassword != null)
            {
                if (_userService.ResetPassword(resetpPasswordRequest.userName, resetpPasswordRequest.newPassword, resetpPasswordRequest.oldPassword))
                {
                    return new ResponseLogin() { message = "Password reset successful" };
                }
                else
                {
                    return new ResponseLogin() { message = "Invalid Password Please try again. " };
                }
            }
            return new ResponseLogin() { message = "Somthing went wrong please conact to admin." };
        }
        catch (ArgumentException argumentException)
        {
            _logger.LogError(argumentException, "ArgumentException caught in ResetPassword");
            throw argumentException;
        }
    }

    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        try
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        catch (ArgumentException argumentException)
        {
            _logger.LogError(argumentException, "ArgumentException caught in GetAll");
            throw argumentException;
        }
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }
        catch (ArgumentException argumentException)
        {
            _logger.LogError(argumentException, "ArgumentException caught in GetById");
            throw argumentException;
        }
    }
    [HttpPut("Update")]
    public IActionResult Update([FromBody] IList<UpdateRequest> model)
    {
        try
        {
            _userService.Update(model);
            return Ok(new { message = "User updated successfully" });
        }
        catch (ArgumentException argumentException)
        {
            _logger.LogError(argumentException, "ArgumentException caught in Update");
            throw argumentException;
        }
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _userService.Delete(id);
            return Ok(new { message = "User deleted successfully" });
        }
        catch (ArgumentException argumentException)
        {
            _logger.LogError(argumentException, "ArgumentException caught in Delete");
            throw argumentException;
        }
    }
}