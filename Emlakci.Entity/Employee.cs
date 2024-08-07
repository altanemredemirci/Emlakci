﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        
        [StringLength(100)]
        public string Name { get; set; }
       
        [StringLength(100)]
        public string Title { get; set; }
        
        [StringLength(100)]
        public string Email { get; set; }
        
        [StringLength(100)]
        public string Phone { get; set; }
        
        public bool Status { get; set; }

        [StringLength(100)]
        public string ImageUrl { get; set; }
    }
}
