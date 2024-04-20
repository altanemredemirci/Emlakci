using Emlakci.Entity;

namespace Emlakci.WEBUI.Models
{
    public class ResultProductTypeModel //category
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Icon { get; set; }

        public List<Product> Products { get; set; }
    }
}
