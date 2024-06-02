using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.DAL.Abstract
{
    public interface IStatisticDal
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int ProductCount();
        int DaireCount();
        string TopAgencyByProductCount();
        string TopCategoryByProductCount();
        decimal AvgProductBySale();
        decimal AvgProductByRent();
        string TopCityByProductCount();
        int DiffrentCityCount();
        decimal LastProductPrice();
        string NewestBuilderYear();
        string OldestBuilderYear();
        int AvgRoomCount();
        int ActiveAgencyCount();
    }
}
