using DOWNNOTIFIER.BusinessLayer.Abstract;
using DOWNNOTIFIER.DataTransferObject;
using DOWNNOTIFIER.Entity;
using DOWNNOTIFIER.Extension;
using DOWNNOTIFIER.UnitOfWork.Abstract;
using DOWNNOTIFIER.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.BusinessLayer.Concrete
{
    public class UserRoleBL : IUserRoleBL
    {
        private readonly IBaseUnitOfWork unitOfWork = new BaseUnitOfWork();

        public int AddNew(UserRoleDTO dto)
        {
            var entity = new UserRole
            {
                Name = dto.Name
            };

            unitOfWork.UserRole.Insert(entity);

            return unitOfWork.SaveChanges();
        }

        public int Edit(UserRoleDTO dto)
        {
            var entity = unitOfWork.UserRole.Select(x => x.Id == dto.Id).FirstOrDefault();

            entity.Name = dto.Name;

            unitOfWork.UserRole.Update(entity);
            return unitOfWork.SaveChanges();
        }

        public List<UserRoleDTO> GetAll()
        {
            return unitOfWork.UserRole.Select().Select(x => x.ToDTO()).ToList();
        }

        public UserRoleDTO GetById(int id)
        {
            return unitOfWork.UserRole.Select(x => x.Id == id).Select(x => x.ToDTO()).FirstOrDefault();
        }

        public int Remove(UserRoleDTO dto)
        {
            var entity = unitOfWork.UserRole.Select(x => x.Id == dto.Id).FirstOrDefault();

            unitOfWork.UserRole.Delete(entity);
            return unitOfWork.SaveChanges();
        }
    }
}
