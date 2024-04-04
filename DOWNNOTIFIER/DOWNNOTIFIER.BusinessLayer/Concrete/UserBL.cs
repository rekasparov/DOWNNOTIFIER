using DOWNNOTIFIER.BusinessLayer.Abstract;
using DOWNNOTIFIER.DataTransferObject;
using DOWNNOTIFIER.Entity;
using DOWNNOTIFIER.Extension;
using DOWNNOTIFIER.UnitOfWork.Abstract;
using DOWNNOTIFIER.UnitOfWork.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWNNOTIFIER.BusinessLayer.Concrete
{
    public class UserBL : IUserBL
    {
        private readonly IBaseUnitOfWork unitOfWork = new BaseUnitOfWork();

        public int AddNew(UserDTO dto)
        {
            var entity = new User
            {
                UserRoleId = dto.UserRoleId,
                Name = dto.Name,
                Surname = dto.Surname,
                Username = dto.Username,
                Password = dto.Password,
                IsActive = dto.IsActive
            };

            unitOfWork.User.Insert(entity);

            return unitOfWork.SaveChanges();
        }

        public int Edit(UserDTO dto)
        {
            var entity = unitOfWork.User.Select(x => x.Id == dto.Id).FirstOrDefault();

            entity.UserRoleId = dto.UserRoleId;
            entity.Name = dto.Name;
            entity.Surname = dto.Surname;
            entity.Username = dto.Username;
            entity.Password = dto.Password;
            entity.IsActive = dto.IsActive;

            unitOfWork.User.Update(entity);
            return unitOfWork.SaveChanges();
        }

        public List<UserDTO> GetAll()
        {
            return unitOfWork.User.Select().Include(x => x.UserRole).Select(x => x.ToDTO()).ToList();
        }

        public UserDTO GetById(int id)
        {
            return unitOfWork.User.Select(x => x.Id == id).Include(x => x.UserRole).Select(x => x.ToDTO()).FirstOrDefault();
        }

        public int Remove(UserDTO dto)
        {
            var entity = unitOfWork.User.Select(x => x.Id == dto.Id).FirstOrDefault();

            unitOfWork.User.Delete(entity);
            return unitOfWork.SaveChanges();
        }
    }
}
