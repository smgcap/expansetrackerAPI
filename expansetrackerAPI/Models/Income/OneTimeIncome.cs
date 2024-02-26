using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace expansetrackerAPI.Models.Income
{
    public class OneTimeIncome
    {
        [Key]
        public int OneTimeIncomeID { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateReceived { get; set; }
        public string Payer { get; set; }
        public string Notes { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
