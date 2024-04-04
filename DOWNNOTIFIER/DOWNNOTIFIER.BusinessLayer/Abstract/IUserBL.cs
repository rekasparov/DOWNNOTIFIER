using DOWNNOTIFIER.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.BusinessLayer.Abstract
{
    public interface IUserBL
    {
        public List<UserDTO> GetAll();
        public UserDTO GetById(int id);
        public UserDTO GetByCridential(string username, string password);
        public int AddNew(UserDTO dto);
        public int Edit(UserDTO dto);
        public int Remove(UserDTO dto);
    }
}
