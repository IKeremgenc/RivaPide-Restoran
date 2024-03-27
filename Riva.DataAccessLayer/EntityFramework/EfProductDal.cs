
using Microsoft.EntityFrameworkCore;
using Riva.DataAccessLayer.Abstract;
using Riva.DataAccessLayer.Concrete;
using Riva.DataAccessLayer.Repositories;
using Riva.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(RivaPideContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new RivaPideContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public decimal ProductAvgPriceByPide()
        {
            using var context = new RivaPideContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Pide").Select(z => z.CategoryID).FirstOrDefault())).Average(w => w.Price);
        }

        public decimal ProductAvgPriceByKebap()
        {
            using var context = new RivaPideContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Kebap").Select(z => z.CategoryID).FirstOrDefault())).Average(w => w.Price);
        }

       

        public int ProductCount()
        {
            using var context = new RivaPideContext();
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
           using var context=new RivaPideContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameTatlı()
        {
            using var context = new RivaPideContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Tatlı").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new RivaPideContext();
            return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            using var context = new RivaPideContext();
            return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            using var context = new RivaPideContext();
            return context.Products.Average(x=> x.Price);
        }

        public decimal ProductPriceBySteakDiğer()
        {
            using var context = new RivaPideContext();
            return context.Products.Where(x => x.ProductName == "Diğer").Select(y => y.Price).FirstOrDefault();
        }

  

        public decimal TotalPriceByDrinkCategory()
        {
            using var context = new RivaPideContext();
            int id=context.Categories.Where(x=>x.CategoryName=="İçecek").Select(y=>y.CategoryID).FirstOrDefault();
            return context.Products.Where(x => x.CategoryID == id).Sum(y => y.Price);
        }

        public decimal TotalPriceBySaladCategory()
        {
            using var context = new RivaPideContext();
            int id = context.Categories.Where(x => x.CategoryName == "Salata").Select(y => y.CategoryID).FirstOrDefault();
            return context.Products.Where(x => x.CategoryID == id).Sum(y => y.Price);
        }

        public int ProductCountByCategoryNamePide()
        {
            using var context = new RivaPideContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Pide").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameKebap()
        {
            using var context = new RivaPideContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Kebap").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameDiğer()
        {
            using var context = new RivaPideContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Diğer").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameLahmacun()
        {
            using var context = new RivaPideContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Lahmacun").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }
    }
}
