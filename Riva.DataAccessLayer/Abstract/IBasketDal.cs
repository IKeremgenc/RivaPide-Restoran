using Riva.EntityLayer.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.DataAccessLayer.Abstract
{
    public interface IBasketDal : IGenericDal<Basket>
    {
        List<Basket> GetBasketByMenuTableNumber(int id);
    }
}
