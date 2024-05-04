using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.BLL.DTOs.CategoryDTO
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public bool Status { get; set; }
        [StringLength(100)]
        public string Icon { get; set; }
    }
}
