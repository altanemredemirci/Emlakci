using Emlakci.BLL.Abstract;
using Emlakci.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.BLL.Concrete
{
    public class StatisticManager : IStatisticService
    {
        private readonly IStatisticDal _statisticDal;

        public StatisticManager(IStatisticDal statisticDal)
        {
            _statisticDal = statisticDal;
        }

        public int ActiveAgencyCount()
        {
            return _statisticDal.ActiveAgencyCount();
        }

        public int ActiveCategoryCount()
        {
            return _statisticDal.ActiveCategoryCount();
        }

        public decimal AvgProductByRent()
        {
            return _statisticDal.AvgProductByRent();
        }

        public decimal AvgProductBySale()
        {
            return _statisticDal.AvgProductBySale();
        }

        public int AvgRoomCount()
        {
            return _statisticDal.AvgRoomCount();
        }

        public int CategoryCount()
        {
            return _statisticDal.CategoryCount();
        }

        public int DaireCount()
        {
            return _statisticDal.DaireCount();
        }

        public int DiffrentCityCount()
        {
            return _statisticDal.DiffrentCityCount();
        }

        public decimal LastProductPrice()
        {
            return _statisticDal.LastProductPrice();
        }

        public string NewestBuilderYear()
        {
            return _statisticDal.NewestBuilderYear();
        }

        public string OldestBuilderYear()
        {
            return _statisticDal.OldestBuilderYear();
        }

        public int PassiveCategoryCount()
        {
            return _statisticDal.PassiveCategoryCount();
        }

        public int ProductCount()
        {
            return _statisticDal.ProductCount();
        }

        public string TopAgencyByProductCount()
        {
            return _statisticDal.TopAgencyByProductCount();
        }

        public string TopCategoryByProductCount()
        {
            return _statisticDal.TopCategoryByProductCount();
        }

        public string TopCityByProductCount()
        {
            return _statisticDal.TopCityByProductCount();
        }
    }
}
