﻿namespace EmployeeMangementSystem_Entity.Common.Status;

public abstract class CommonProperties : AuditedEntity
{
    [Column(name:"status")]
    public bool Status { get; set; }
  
}
