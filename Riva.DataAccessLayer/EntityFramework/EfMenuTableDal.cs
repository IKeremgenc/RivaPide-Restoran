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
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        public EfMenuTableDal(RivaPideContext context) : base(context)
        {
        }

        public int MenuTableCount()
        {
            using var context = new RivaPideContext();
            return context.MenuTables.Count();
        }

		public void MenuTableStatusApproved(int id)
		{
			using var context = new RivaPideContext();
			var values = context.MenuTables.Find(id);
			values.Status = true;
			context.SaveChanges();
		}

		public void MenuTableStatusFalseApproved(int id)
		{
			using var context = new RivaPideContext();
			var values = context.MenuTables.Find(id);
			values.Status = false;
			context.SaveChanges();
		}
	}
}
