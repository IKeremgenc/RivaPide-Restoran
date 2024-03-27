
using Riva.DataAccessLayer.Abstract;
using Riva.DataAccessLayer.Concrete;
using Riva.DataAccessLayer.Repositories;
using Riva.EntiyLayer.Entities;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(RivaPideContext context) : base(context)
        {
        }

		public void ChangeStatusToFalse(int id)
		{
			using var context=new RivaPideContext();
			var value = context.Discounts.Find(id);
			value.Status = false;
			context.SaveChanges();
		}

		public void ChangeStatusToTrue(int id)
		{
			using var context = new RivaPideContext();
			var value = context.Discounts.Find(id);
			value.Status = true;
			context.SaveChanges();
		}

		public List<Discount> GetListByStatusTrue()
		{
			using var context = new RivaPideContext();
			var value = context.Discounts.Where(x => x.Status == true).ToList();
			return value;
		}
	}
}
