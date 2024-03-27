
using Riva.DataAccessLayer.Abstract;
using Riva.DataAccessLayer.Concrete;
using Riva.DataAccessLayer.Repositories;
using RivaEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.DataAccessLayer.EntityFramework
{
    public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public EfTestimonialDal(RivaPideContext context) : base(context)
        {
        }
    }
}
