using DOWNNOTIFIER.DataTransferObject;
using DOWNNOTIFIER.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.Extension
{
    public static class UserRoleExtension
    {
        public static UserRoleDTO ToDTO(this UserRole entity)
        {
            return new UserRoleDTO
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
