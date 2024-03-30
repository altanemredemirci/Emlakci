using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public decimal Price { get; set; }
        [StringLength(250)]
        public string CoverImage { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(100)]
        public string District { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        public int CategoryId { get; set; } //Foreign Key
        public Category Category { get; set; } 
    }
}
