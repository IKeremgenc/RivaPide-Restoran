using Riva.BusinessLayer.Abstract;
using Riva.DataAccessLayer.Abstract;
using Riva.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.BusinessLayer.Concrete
{
	public class MenuTableManager : IMenuTableService
	{
		private readonly IMenuTableDal _menuTableDal;
		public MenuTableManager(IMenuTableDal menuTableDal)
		{
			_menuTableDal = menuTableDal;
		}

		public void TMenuTableStatusFalseApproved(int id)
		{
			_menuTableDal.MenuTableStatusFalseApproved(id);
		}

		public void TAdd(MenuTable entity)
		{
			_menuTableDal.Add(entity);
		}

		public void TDelete(MenuTable entity)
		{
			_menuTableDal.Delete(entity);
		}

		public MenuTable TGetByID(int id)
		{
			return _menuTableDal.GetByID(id);
		}

		public List<MenuTable> TGetListAll()
		{
			return _menuTableDal.GetListAll();
		}

		public int TMenuTableCount()
		{
			return _menuTableDal.MenuTableCount();
		}

		public void TMenuTableStatusApproved(int id)
		{
			 _menuTableDal.MenuTableStatusApproved(id);
		}

		public void TUpdate(MenuTable entity)
		{
			_menuTableDal.Update(entity);
		}
	}
}
