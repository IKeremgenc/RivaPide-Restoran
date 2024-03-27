
using Riva.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.BusinessLayer.Abstract
{
    public interface IMoneyCaseService:IGenericService<MoneyCase>
    {
        decimal TTotalMoneyCaseAmount();
    }
}
