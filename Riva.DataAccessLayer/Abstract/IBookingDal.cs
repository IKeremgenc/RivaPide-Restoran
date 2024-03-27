using Riva.EntityLayer.Entities;
using Riva.EntiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingStatusApproved(int id);
        void BookingStatusCancelled(int id);
        List<Booking> GetFalseBookings();
    }
}
