using Azure;
using Emlakci.DAL.Abstract;
using Emlakci.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.DAL.Concrete.EfCore
{
    public class EfCoreSliderDal : EfCoreGenericRepository<Slider,DataContext>, ISliderDal
    {

    }
}

