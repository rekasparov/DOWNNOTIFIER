using DOWNNOTIFIER.DataAccessLayer.Abstract;
using DOWNNOTIFIER.Entity;
using DOWNNOTIFIER.Repository.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.DataAccessLayer.Concrete
{
    public class UserDAL : BaseEFRepository<User>, IUserDAL
    {
        public UserDAL(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
