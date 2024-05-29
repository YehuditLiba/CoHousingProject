using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IMonthlyExpense
    {
        public List<MonthlyExpense> GetMEListByBuildingId(int code);
        public MonthlyExpense AddMonthlyExpense(MonthlyExpense expense);
        public MonthlyExpense RemoveMonthlyExpense(int id);
        public MonthlyExpense UpdateMonthlyExpense(MonthlyExpense newExpense, int id);
    }
}
