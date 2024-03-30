using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.Entity
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public byte BathCount { get; set; }
        public byte BedRoomCount { get; set; }
        public byte RoomCount { get; set; }
        public byte GarageSize { get; set; }
        public string BuildYear { get; set; }
        public decimal Price { get; set; }
        [StringLength(500)]
        public string Location { get; set; }
        [StringLength(500)]
        public string VideoUrl { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
