
using Riva.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        int TProductCount();
        int TProductCountByCategoryNameTatlı();
        int TProductCountByCategoryNameDrink();
        int TProductCountByCategoryNamePide();
        int TProductCountByCategoryNameKebap();
        int TProductCountByCategoryNameLahmacun();
        int TProductCountByCategoryNameDiğer();
        decimal TProductPriceAvg();
        string TProductNameByMaxPrice();
        string TProductNameByMinPrice();
        decimal TProductAvgPriceByPide();

        decimal TProductAvgPriceByKebap();

        decimal TTotalPriceByDrinkCategory();
        decimal TTotalPriceBySaladCategory();
    }
}
