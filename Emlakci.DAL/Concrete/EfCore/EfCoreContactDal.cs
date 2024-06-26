﻿using Emlakci.DAL.Abstract;
using Emlakci.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.DAL.Concrete.EfCore
{
    public class EfCoreContactDal : IContactDal
    {
        public Contact GetContact()
        {
            using(var context = new DataContext())
            {
                return context.Contacts.FirstOrDefault();
            }
        }
    }
}
