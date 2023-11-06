namespace EmployeeMangementSystem_Entity.Employee;

public class Employee_Asset_Mapping_Entity:CommonProperties
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeAssetMappingId { get; set; }
    public int EmployeeID { get; set; }
    public int AssetId { get; set; }

}
