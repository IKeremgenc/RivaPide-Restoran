
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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(RivaPideContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using var context=new RivaPideContext();
            return context.Categories.Where(x => x.Status == true).Count();
        }

        public int CategoryCount()
        {
            using var context = new RivaPideContext();
            return context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            using var context = new RivaPideContext();
            return context.Categories.Where(x => x.Status == false).Count();
        }
    }
}
