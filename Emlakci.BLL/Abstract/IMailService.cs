﻿using Emlakci.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.BLL.Abstract
{
    public interface IMailService:IRepositoryService<Mail>
    {
        List<Mail> GetLast4Mail();
    }
}
