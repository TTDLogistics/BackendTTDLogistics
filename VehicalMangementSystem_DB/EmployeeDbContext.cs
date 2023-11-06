namespace EmployeeMangementSystem_DB;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext() : base()
    {

    }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> option) :
        base(option)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = "Server=AMIT\\MSSQLSERVER2019;Database=TTDLogistics; Integrated Security = true; TrustServerCertificate = True; MultipleActiveResultSets = True; Max Pool Size = 200; ";

            optionsBuilder.UseSqlServer(connectionString,
                options => options.EnableRetryOnFailure());
        }
    }
    public DbSet<Users> Users { get; set; }
    public DbSet<EmployeeDetailsEntity> Employee { get; set; }
    public DbSet<RoleEntity> Role { get; set; }
    public DbSet<LocationEntity> Location { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LocationEntity>()
        .HasKey(location => location.LocationId);
        modelBuilder.Entity<RoleEntity>()
       .HasKey(role => role.RoleId);
        // Other configurations
    }
    public override int SaveChanges()
    {
       // UpdateAutitedEntity();
        return base.SaveChanges();
    }
    public sealed override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      // UpdateAutitedEntity();
        return await base.SaveChangesAsync(true, cancellationToken);
    }


}
