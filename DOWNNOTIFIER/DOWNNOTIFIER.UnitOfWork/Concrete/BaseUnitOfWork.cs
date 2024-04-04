using DOWNNOTIFIER.DataAccessLayer.Abstract;
using DOWNNOTIFIER.DataAccessLayer.Concrete;
using DOWNNOTIFIER.Entity;
using DOWNNOTIFIER.UnitOfWork.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.UnitOfWork.Concrete
{
    public class BaseUnitOfWork : IBaseUnitOfWork
    {
        private DbContext? _dbContext;
        public DbContext dbContext
        {
            get
            {
                _dbContext = _dbContext ?? new DOWNNOTIFIERContext();

                return _dbContext;
            }
        }


        public IApplicationDAL Application => new ApplicationDAL(dbContext);

        public IUserDAL User => new UserDAL(dbContext);

        public IUserRoleDAL UserRole => new UserRoleDAL(dbContext);

        public int SaveChanges()
        {
            var effectedRowCount = 0;

            if (dbContext.ChangeTracker.HasChanges())
                effectedRowCount = dbContext.SaveChanges();

            return effectedRowCount;
        }
    }
}
