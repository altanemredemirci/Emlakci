using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Emlakci.Entity
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }

        [JsonIgnore]
        public int ProductDetailsId { get; set; }

        [JsonIgnore]
        public ProductDetails ProductDetails { get; set; }
    }
}
