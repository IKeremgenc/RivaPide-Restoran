using Riva.EntityLayer.Entities;
using Riva.EntiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        int TCategoryCount();
        int TActiveCategoryCount();
        int TPassiveCategoryCount();
    }
}
