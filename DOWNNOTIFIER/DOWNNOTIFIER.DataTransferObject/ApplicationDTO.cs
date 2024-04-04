using System;
using System.Collections.Generic;

namespace DOWNNOTIFIER.DataTransferObject;

public partial class ApplicationDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int IntervalTime { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual UserDTO CreatedByNavigation { get; set; } = null!;

    public virtual UserDTO? UpdatedByNavigation { get; set; }
}
