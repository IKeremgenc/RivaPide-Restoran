
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
	public class EfMessageDal : GenericRepository<Message>, IMessageDal
	{
		public EfMessageDal(RivaPideContext context) : base(context)
		{
		}
	
	}
}
