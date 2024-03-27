using Riva.BusinessLayer.Abstract;
using Riva.DataAccessLayer.Abstract;
using Riva.EntityLayer.Entities;
using Riva.EntiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public string TProductNameByMaxPrice()
        {
            return _productDal.ProductNameByMaxPrice();
        }

        public string TProductNameByMinPrice()
        {
            return _productDal.ProductNameByMinPrice();
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetByID(int id)
        {
            return _productDal.GetByID(id);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public List<Product> TGetProductsWithCategories()
        {
          return _productDal.GetProductsWithCategories();
        }

        public int TProductCount()
        {
            return _productDal.ProductCount();
        }

        public int TProductCountByCategoryNameDrink()
        {
            return _productDal.ProductCountByCategoryNameDrink();
        }


        public decimal TProductPriceAvg()
        {
            return _productDal.ProductPriceAvg();
        }

        public void TUpdate(Product entity)
        {
           _productDal.Update(entity);
        }

 

        public decimal TTotalPriceByDrinkCategory()
        {
           return _productDal.TotalPriceByDrinkCategory();
        }

        public decimal TTotalPriceBySaladCategory()
        {
            return _productDal.TotalPriceBySaladCategory();
        }

        public decimal TProductAvgPriceByPide()
        {
         return _productDal.ProductAvgPriceByKebap();
        }

    

        public decimal TProductAvgPriceByKebap()
        {
            return _productDal.ProductAvgPriceByKebap();
        }

 

        public int TProductCountByCategoryNameTatlı()
        {
            return _productDal.ProductCountByCategoryNameTatlı();
        }

        public int TProductCountByCategoryNamePide()
        {
            return _productDal.ProductCountByCategoryNamePide();
        }

        public int TProductCountByCategoryNameKebap()
        {
            return _productDal.ProductCountByCategoryNameKebap();
        }

        public int TProductCountByCategoryNameDiğer()
        {
            return _productDal.ProductCountByCategoryNameDiğer();
        }

        public int TProductCountByCategoryNameLahmacun()
        {
            return _productDal.ProductCountByCategoryNameLahmacun();
        }
    }
}
