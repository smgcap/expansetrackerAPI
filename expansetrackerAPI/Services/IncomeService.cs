using expansetrackerAPI.Data;
using expansetrackerAPI.Interfaces;
using expansetrackerAPI.Models.Income;
using System.Linq;

namespace expansetrackerAPI.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly ExpanseDbContext _expanseDbContext;
        IncomeService(ExpanseDbContext expanseDbContext)
        {
            this._expanseDbContext = expanseDbContext;
        }

        public void AddIncomeSource(IncomeSource incomeSource)
        {
            try
            {
                _expanseDbContext.IncomeSources.Add(incomeSource);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void DeleteIncomeSource(int id)
        {
            try
            {
                var incomeSource = _expanseDbContext.IncomeSources.FirstOrDefault(x => x.IncomeSourceID == id);
                _expanseDbContext.IncomeSources.Remove(incomeSource);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public IEnumerable<IncomeSource> GetAllIncomeSources()
        {
            try
            {
                return _expanseDbContext.IncomeSources.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public IncomeSource GetIncomeSourceById(int id)
        {
            try
            {
                return _expanseDbContext.IncomeSources.FirstOrDefault(x => x.IncomeSourceID == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateIncomeSource(IncomeSource incomeSource)
        {
            try
            {
                _expanseDbContext.IncomeSources.Update(incomeSource);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
