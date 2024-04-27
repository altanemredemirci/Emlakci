using Emlakci.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Emlakci.WEBUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Durum")]
        public bool Status { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("İkon")]
        public string Icon { get; set; }

        public List<Product> Products { get; set; }
    }
}
