using Riva.BusinessLayer.Abstract;
using Riva.DataAccessLayer.Abstract;
using Riva.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.BusinessLayer.Concrete
{
    public class GalleryManger : IGalleryService
    {
        private readonly IGalleryDal _galleryDal;

        public GalleryManger(IGalleryDal galleryDal)
        {
            _galleryDal = galleryDal;
        }

        public void TAdd(Gallery entity)
        {
          _galleryDal.Add(entity);
        }

        public void TDelete(Gallery entity)
        {
          _galleryDal.Delete(entity);
        }

        public Gallery TGetByID(int id)
        {
           return _galleryDal.GetByID(id);
        }

        public List<Gallery> TGetListAll()
        {
      return     _galleryDal.GetListAll();
        }

        public void TUpdate(Gallery entity)
        {
            _galleryDal.Update(entity);
        }
    }
}
