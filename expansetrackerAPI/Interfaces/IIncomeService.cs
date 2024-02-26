using expansetrackerAPI.Models.Income;

namespace expansetrackerAPI.Interfaces
{
    public interface IIncomeService
    {
        internal void AddIncomeSource(IncomeSource incomeSource);
        internal void DeleteIncomeSource(int id);
        internal IEnumerable<IncomeSource> GetAllIncomeSources();
        internal IncomeSource GetIncomeSourceById(int id);
        internal void UpdateIncomeSource(IncomeSource incomeSource);

    }
}
