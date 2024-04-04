using System;
using System.Collections.Generic;

namespace DOWNNOTIFIER.Entity;

public partial class User
{
    public int Id { get; set; }

    public int UserRoleId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Application> ApplicationCreatedByNavigations { get; set; } = new List<Application>();

    public virtual ICollection<Application> ApplicationUpdatedByNavigations { get; set; } = new List<Application>();

    public virtual UserRole UserRole { get; set; } = null!;
}
