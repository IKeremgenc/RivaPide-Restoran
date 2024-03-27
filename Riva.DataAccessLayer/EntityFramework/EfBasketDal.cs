using Microsoft.EntityFrameworkCore;
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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(RivaPideContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            using var context=new RivaPideContext();
            var values = context.Baskets.Include(y=>y.Product).ToList();
            return values;
        }
    }
}
