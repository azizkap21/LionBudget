using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.DAL.Abstract;
using Lion.Domain.Models;

namespace Lion.DAL.Concrete
{
    public class BudgetRepository : GenericRepository<Budget>, IBudgetRepository 
    {

        public Budget GetBudget(Guid id)
        {
            return GetAll().Where(x => x.BudgetID == id).FirstOrDefault();
        }
    }
}
