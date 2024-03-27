using Riva.BusinessLayer.Abstract;
using Riva.DataAccessLayer.Abstract;
using Riva.EntityLayer.Entities;
using Riva.EntiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

		public void BookingStatusApproved(int id)
		{
            _bookingDal.BookingStatusApproved(id);
		}

		public void BookingStatusCancelled(int id)
		{
            _bookingDal.BookingStatusCancelled(id);
		}

		public void TAdd(Booking entity)
        {
            _bookingDal.Add(entity);
        }

        public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public Booking TGetByID(int id)
        {
            return _bookingDal.GetByID(id);
        }

        public List<Booking> TGetFalseBookings()
        {
           return _bookingDal.GetFalseBookings();
        }

        public List<Booking> TGetListAll()
        {
            return _bookingDal.GetListAll();
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
