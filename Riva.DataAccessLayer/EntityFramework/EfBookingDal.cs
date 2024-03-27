
using Riva.DataAccessLayer.Abstract;
using Riva.DataAccessLayer.Concrete;
using Riva.DataAccessLayer.Repositories;
using Riva.EntityLayer.Entities;
using Riva.EntiyLayer.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(RivaPideContext context) : base(context)
        {
        }

        public void BookingStatusApproved(int id)
        {
            using var context = new RivaPideContext();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusCancelled(int id)
        {
            using var context = new RivaPideContext();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon İptal Edildi";
            context.SaveChanges();
        }


        public List<Booking> GetFalseBookings()
        {
            using var context = new RivaPideContext();
            var values = context.Bookings
                               .Where(b => b.Description == "Rezervasyon Alındı")
                               .ToList();
            return values;
        }

    }
}
