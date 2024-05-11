using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.BLL.DTOs.AgencyDTO
{
    public class UpdateAgencyDTO
    {
        public int Id { get; set; }
        [StringLength(70)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(70)]
        public string Image { get; set; }
        [StringLength(150)]
        public string SocialOne { get; set; }
        [StringLength(150)]
        public string SocialTwo { get; set; }
        [StringLength(150)]
        public string SocialThree { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
    }
}
