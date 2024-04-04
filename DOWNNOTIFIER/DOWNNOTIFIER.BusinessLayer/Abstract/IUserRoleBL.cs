using DOWNNOTIFIER.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.BusinessLayer.Abstract
{
    public interface IUserRoleBL
    {
        public List<UserRoleDTO> GetAll();
        public UserRoleDTO GetById(int id);
        public int AddNew(UserRoleDTO dto);
        public int Edit(UserRoleDTO dto);
        public int Remove(UserRoleDTO dto);
    }
}
