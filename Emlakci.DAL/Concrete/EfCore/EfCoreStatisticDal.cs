using Emlakci.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.DAL.Concrete.EfCore
{
    public class EfCoreStatisticDal : IStatisticDal
    {
        public int ActiveAgencyCount()
        {
            using (var context = new DataContext())
            {
                return context.Agencies.Where(i => i.Status == true).Count();
            }
        }

        public int ActiveCategoryCount()
        {
            using (var context = new DataContext())
            {
                return context.Categories.Where(i => i.Status == true).Count();
            }
        }

        public decimal AvgProductByRent()
        {
            using (var context = new DataContext())
            {
                return context.Products.Where(i => i.Type == "kiralık").Average(i => i.Price);
            }
        }

        public decimal AvgProductBySale()
        {
            using (var context = new DataContext())
            {
                return context.Products.Where(i => i.Type == "Satılık").Average(i => i.Price);
            }
        }

        public int AvgRoomCount()
        {
            using (var context = new DataContext())
            {
                return (int)context.ProductDetails.Average(i => i.RoomCount);
            }
        }

        public int CategoryCount()
        {
            using (var context = new DataContext())
            {
                return context.Categories.Count();
            }
        }

        public int DaireCount()
        {
            using (var context = new DataContext())
            {
                return context.Products.Where(i=> i.CategoryId==1).Count();
            }
        }

        public int DiffrentCityCount()
        {
            using (var context = new DataContext())
            {
                return context.Products.Select(i => i.CityId).Distinct().Count();
            }
        }

        public decimal LastProductPrice()
        {
            using (var context = new DataContext())
            {
                return context.Products.OrderByDescending(i => i.Id).Select(i => i.Price).FirstOrDefault();
            }
        }

        public string NewestBuilderYear()
        {
            using (var context = new DataContext())
            {
                return context.ProductDetails.OrderByDescending(i => i.BuildYear).Select(i=> i.BuildYear).FirstOrDefault();
            }
        }

        public string OldestBuilderYear()
        {
            using (var context = new DataContext())
            {
                return context.ProductDetails.OrderBy(i => i.BuildYear).Select(i => i.BuildYear).FirstOrDefault();
            }
        }

        public int PassiveCategoryCount()
        {
            using (var context = new DataContext())
            {
                return context.Categories.Count(i => i.Status == false);
            }
        }

        public int ProductCount()
        {
            using (var context = new DataContext())
            {
                return context.Products.Count();
            }
        }

        public string TopAgencyByProductCount()
        {
            using (var context = new DataContext())
            {
                return context.Products.GroupBy(i => i.Agency.FullName).Select(group => new { AgencyName = group.Key, ProductCount = group.Count() }).OrderByDescending(x => x.ProductCount).FirstOrDefault()?.AgencyName;
            }
        }

        public string TopCategoryByProductCount()
        {
            using (var context = new DataContext())
            {
                return context.Products.GroupBy(i => i.Category.Name).Select(group => new { CategoryName = group.Key, ProductCount = group.Count() }).OrderByDescending(x => x.ProductCount).FirstOrDefault()?.CategoryName;
            }
        }

        public string TopCityByProductCount()
        {
            using (var context = new DataContext())
            {
                return context.Products.GroupBy(i => i.City.Name).Select(group => new { CityName = group.Key, ProductCount = group.Count() }).OrderByDescending(x => x.ProductCount).FirstOrDefault()?.CityName;
            }
        }
    }
}
