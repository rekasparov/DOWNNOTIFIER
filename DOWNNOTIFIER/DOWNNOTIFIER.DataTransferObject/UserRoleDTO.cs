using System;
using System.Collections.Generic;

namespace DOWNNOTIFIER.DataTransferObject;

public partial class UserRoleDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserDTO> Users { get; set; } = new List<UserDTO>();
}
