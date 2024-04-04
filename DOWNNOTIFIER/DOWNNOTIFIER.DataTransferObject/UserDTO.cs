using System;
using System.Collections.Generic;

namespace DOWNNOTIFIER.DataTransferObject;

public partial class UserDTO
{
    public int Id { get; set; }

    public int UserRoleId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<ApplicationDTO> ApplicationCreatedByNavigations { get; set; } = new List<ApplicationDTO>();

    public virtual ICollection<ApplicationDTO> ApplicationUpdatedByNavigations { get; set; } = new List<ApplicationDTO>();

    public virtual UserRoleDTO UserRole { get; set; } = null!;
}
