using Riva.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.BusinessLayer.Abstract
{
    public interface IBookingService:IGenericService<Booking>
	{
		void BookingStatusApproved(int id);
		void BookingStatusCancelled(int id);
        List<Booking> TGetFalseBookings();
    }
}
