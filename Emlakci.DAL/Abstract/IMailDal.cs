﻿using Emlakci.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.DAL.Abstract
{
    public interface IMailDal : IRepository<Mail>
    {
        List<Mail> GetLast4Mail();
    }
}
