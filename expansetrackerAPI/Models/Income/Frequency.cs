using System.ComponentModel.DataAnnotations;

namespace expansetrackerAPI.Models.Income
{
    public class Frequency
    {
        [Key]
        public int FrequencyID { get; set; }
        public string FrequencyName { get; set; }
    }
}
