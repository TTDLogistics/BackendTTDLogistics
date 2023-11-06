namespace EmployeeMangementSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        var configuration = builder.Configuration;
        var env = builder.Environment;


        // Add services to the container.
        ///add cors policy
        services.AddCors(crosOption =>
        crosOption.AddPolicy(name: ServiceConfigurations.MyAllowSpecificsOrigins,
        crosPolicyBuilder =>
        {
            //crosPolicyBuilder.WithOrigins("http://127.0.0.1:5502").AllowAnyHeader().AllowAnyMethod();
            crosPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

        }
        ));
        //database configuration
        services.AddDbContext<EmployeeDbContext>(optionsAction => optionsAction.UseSqlServer
        (
            configuration.GetConnectionString("constr")

            ));
        // configure strongly typed settings object
        services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

        builder.Services.AddControllers();

        services.AddAutoMapper(typeof(Program));
        services.AddScoped<IJwtUtils, JwtUtils>();
        services.AddScoped<IUser, UserServices>();
        services.AddScoped<IEmployee,EmployeeService>();
        services.AddScoped<IRole, RoleServices>();  
        services.AddScoped<ILocation, LocationServices>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();

       // app.UseAuthorization();

        app.UseDeveloperExceptionPage();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseHttpsRedirection();
        app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseCors(ServiceConfigurations.MyAllowSpecificsOrigins);
        app.UseMiddleware<JwtMiddleware>();
        app.MapControllers();

        app.Run();
        bool IsOriginAllowed(string host)
        {
            return ServiceConfigurations.IsOriginAllowed(host, env.EnvironmentName, Constant.DEV_ENV_NAME, string.Empty, string.Empty);
        }

    }
}