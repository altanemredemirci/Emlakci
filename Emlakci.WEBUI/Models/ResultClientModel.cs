using System.ComponentModel.DataAnnotations;

namespace Emlakci.WEBUI.Models
{
    public class ResultClientModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
