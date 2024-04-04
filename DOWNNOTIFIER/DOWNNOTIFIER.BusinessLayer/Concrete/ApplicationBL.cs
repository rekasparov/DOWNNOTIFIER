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
    public class ApplicationBL : IApplicationBL
    {
        private readonly IBaseUnitOfWork unitOfWork = new BaseUnitOfWork();

        public int AddNew(ApplicationDTO dto)
        {
            var entity = new Application
            {
                Name = dto.Name,
                Url = dto.Url,
                IntervalTime = dto.IntervalTime,
                IsActive = dto.IsActive,
                CreatedBy = dto.CreatedBy,
                CreatedDate = dto.CreatedDate,
            };

            unitOfWork.Application.Insert(entity);

            return unitOfWork.SaveChanges();
        }

        public int Edit(ApplicationDTO dto)
        {
            var entity = unitOfWork.Application.Select(x => x.Id == dto.Id).FirstOrDefault();

            entity.Name = dto.Name;
            entity.Url = dto.Url;
            entity.IntervalTime = dto.IntervalTime;
            entity.IsActive = dto.IsActive;
            entity.UpdatedBy = dto.UpdatedBy;
            entity.UpdatedDate = dto.UpdatedDate;

            unitOfWork.Application.Update(entity);
            return unitOfWork.SaveChanges();
        }

        public List<ApplicationDTO> GetAll()
        {
            return unitOfWork.Application.Select().Include(x => x.CreatedByNavigation).Include(x => x.CreatedByNavigation).Select(x => x.ToDTO()).ToList();
        }

        public ApplicationDTO GetById(int id)
        {
            return unitOfWork.Application.Select(x => x.Id == id).Include(x => x.CreatedByNavigation).Include(x => x.CreatedByNavigation).Select(x => x.ToDTO()).FirstOrDefault();
        }

        public int Remove(ApplicationDTO dto)
        {
            var entity = unitOfWork.Application.Select(x => x.Id == dto.Id).FirstOrDefault();

            unitOfWork.Application.Delete(entity);
            return unitOfWork.SaveChanges();
        }
    }
}
