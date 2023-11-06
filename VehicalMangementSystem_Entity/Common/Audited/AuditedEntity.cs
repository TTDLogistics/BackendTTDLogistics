namespace EmployeeMangementSystem_Entity.Common.Audited;

public abstract class AuditedEntity
{
    [Column(name: "CreatedDate")]
    public DateTime CreatedDate { get; set; }

    [Column(name: "CreatedBy")]
    public int CreatedBy { get; set; }

    [Column(name: "ModifiedDate")]
    public DateTime ModifiedDate { get; set; }

    [Column(name: "ModifiedBy")]
    public int ModifiedBy { get; set; }

    [Column(name: "LockedStatus")]
    public bool LockedStatus { get; set; }

}
