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
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal _moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            _moneyCaseDal = moneyCaseDal;
        }

        public void TAdd(MoneyCase entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(MoneyCase entity)
        {
            throw new NotImplementedException();
        }

        public MoneyCase TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<MoneyCase> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public decimal TTotalMoneyCaseAmount()
        {
            return _moneyCaseDal.TotalMoneyCaseAmount();
        }

        public void TUpdate(MoneyCase entity)
        {
            throw new NotImplementedException();
        }
    }
}
