using DOWNNOTIFIER.DataTransferObject;
using DOWNNOTIFIER.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.Extension
{
    public static class ApplicationExtension
    {
        public static ApplicationDTO ToDTO(this Application entity)
        {
            return new ApplicationDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Url = entity.Url,
                IntervalTime = entity.IntervalTime,
                IsActive = entity.IsActive,
                CreatedBy = entity.CreatedBy,
                CreatedDate = entity.CreatedDate,
                UpdatedBy = entity.UpdatedBy,
                UpdatedDate = entity.UpdatedDate,
                CreatedByNavigation = entity.CreatedByNavigation != null
                    ? entity.CreatedByNavigation.ToDTO()
                    : new UserDTO(),
                UpdatedByNavigation = entity.UpdatedByNavigation != null
                    ? entity.UpdatedByNavigation.ToDTO()
                    : new UserDTO(),
            };
        }
    }
}
