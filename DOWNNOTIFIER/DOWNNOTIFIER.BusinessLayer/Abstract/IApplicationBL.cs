using DOWNNOTIFIER.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.BusinessLayer.Abstract
{
    public interface IApplicationBL
    {
        public List<ApplicationDTO> GetAll();
        public ApplicationDTO GetById(int id);
        public int AddNew(ApplicationDTO dto);
        public int Edit(ApplicationDTO dto);
        public int Remove(ApplicationDTO dto);
    }
}
