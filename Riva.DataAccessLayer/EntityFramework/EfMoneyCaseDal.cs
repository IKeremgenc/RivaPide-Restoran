
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
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        public EfMoneyCaseDal(RivaPideContext context) : base(context)
        {
        }

        public decimal TotalMoneyCaseAmount()
        {
            using var context = new RivaPideContext();
            return context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
        }
    }
}