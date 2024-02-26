using System.ComponentModel.DataAnnotations;

namespace expansetrackerAPI.Models.Income
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
