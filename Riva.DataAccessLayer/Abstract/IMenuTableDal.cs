
using Riva.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.DataAccessLayer.Abstract
{
    public interface IMenuTableDal:IGenericDal<MenuTable>
    {
        int MenuTableCount();
        void MenuTableStatusApproved(int id);
        void MenuTableStatusFalseApproved(int id);

	}
}
