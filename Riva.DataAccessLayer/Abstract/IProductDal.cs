
using Riva.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        int ProductCount();
        int ProductCountByCategoryNameTatlı();
        int ProductCountByCategoryNameDrink();
        int ProductCountByCategoryNamePide();
        int ProductCountByCategoryNameKebap();
        int ProductCountByCategoryNameLahmacun();
        int ProductCountByCategoryNameDiğer();
        decimal ProductPriceAvg();
        string ProductNameByMaxPrice();
        string ProductNameByMinPrice();
        decimal ProductAvgPriceByPide();
     
        decimal ProductAvgPriceByKebap();
    
        decimal TotalPriceByDrinkCategory();
        decimal TotalPriceBySaladCategory();
    }
}
