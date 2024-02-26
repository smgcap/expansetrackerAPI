using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace expansetrackerAPI.Models.Income
{
    public class IncomeSource
    {
        [Key]
        public int IncomeSourceID { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateReceived { get; set; }
        public string Payer { get; set; }
        public string Notes { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Frequency")]
        public int FrequencyID { get; set; }
        public virtual Frequency Frequency { get; set; }
    }
}
