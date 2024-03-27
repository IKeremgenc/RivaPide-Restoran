
using Riva.DataAccessLayer.Abstract;
using Riva.DataAccessLayer.Concrete;
using Riva.DataAccessLayer.Repositories;
using Riva.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(RivaPideContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new RivaPideContext();
            return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public decimal LastOrderPrice()
        {
            using var context = new RivaPideContext();
            return context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {
            return 0;
        }

        public int TotalOrderCount()
        {
            using var context = new RivaPideContext();
            return context.Orders.Count();
        }
    }
}
