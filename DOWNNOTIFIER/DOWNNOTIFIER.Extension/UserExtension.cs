using DOWNNOTIFIER.DataTransferObject;
using DOWNNOTIFIER.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.Extension
{
    public static class UserExtension
    {
        public static UserDTO ToDTO(this User entity)
        {
            return new UserDTO
            {
                Id = entity.Id,
                UserRoleId = entity.UserRoleId,
                Name = entity.Name,
                Surname = entity.Surname,
                Username = entity.Username,
                Password = entity.Password,
                IsActive = entity.IsActive,
                UserRole = entity.UserRole != null 
                    ? entity.UserRole.ToDTO() 
                    : new UserRoleDTO()
            };
        }
    }
}
