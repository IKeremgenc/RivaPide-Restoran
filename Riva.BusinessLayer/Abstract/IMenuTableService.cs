
using Riva.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.BusinessLayer.Abstract
{
    public interface IMenuTableService:IGenericService<MenuTable>
    {
        int TMenuTableCount();
		void TMenuTableStatusApproved(int id);
		void TMenuTableStatusFalseApproved(int id);
	}
}
