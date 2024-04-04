using DOWNNOTIFIER.Entity;
using DOWNNOTIFIER.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.DataAccessLayer.Abstract
{
    public interface IApplicationDAL : IBaseRepository<Application>
    {
    }
}
