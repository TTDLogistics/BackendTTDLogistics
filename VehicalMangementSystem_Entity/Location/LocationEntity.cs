namespace EmployeeMangementSystem_Entity.Location;

public class LocationEntity:CommonProperties
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LocationId { get; set; }
    public string? LocationName { get; set; }
}
