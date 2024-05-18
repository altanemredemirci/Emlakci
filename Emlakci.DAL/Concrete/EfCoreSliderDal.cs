using Emlakci.DAL.Abstract;
using Emlakci.DAL.Concrete.EfCore;
using Emlakci.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.DAL.Concrete
{
    public class EfCoreSliderDal : ISliderDal
    {
        public Slider GetByPage(string page)
        {
            using(var context = new DataContext())
            {
                return context.Sliders.FirstOrDefault(i => i.Page == page);
            }
        }
    }
}
