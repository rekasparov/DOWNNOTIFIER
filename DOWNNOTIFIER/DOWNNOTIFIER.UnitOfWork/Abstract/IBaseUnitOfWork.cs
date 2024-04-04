using DOWNNOTIFIER.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.UnitOfWork.Abstract
{
    public interface IBaseUnitOfWork
    {
        public IApplicationDAL Application { get; }
        public IUserDAL User { get; }
        public IUserRoleDAL UserRole { get; }

        public int SaveChanges();
    }
}
