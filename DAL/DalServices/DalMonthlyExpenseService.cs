using DAL.DalApi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    public class DalMonthlyExpenseService : IMonthlyExpense
    {
        CoHousingContext _CoHousingData;
        public DalMonthlyExpenseService(CoHousingContext coHousingData)
        {
            _CoHousingData = coHousingData;
        }

        public List<MonthlyExpense> GetMEListByBuildingId(int code)
        {
            List<MonthlyExpense> list = new List<MonthlyExpense>();
            foreach (var e in _CoHousingData.MonthlyExpenses)
            {
                if (e.BuildingCode == code)
                    list.Add(e);
            }
            return list;
        }
        public MonthlyExpense AddMonthlyExpense(MonthlyExpense expense)
        {
            _CoHousingData.MonthlyExpenses.Add(expense);
            _CoHousingData.SaveChanges();
            return expense;
        }
        public MonthlyExpense RemoveMonthlyExpense(int id)
        {
            var expense = _CoHousingData.MonthlyExpenses.FirstOrDefault(e=>e.ExpenditureId==id);
            if (expense == null)
                return null;
            _CoHousingData.MonthlyExpenses.Remove(expense);
            _CoHousingData.SaveChanges();
            return expense;
        }
        public MonthlyExpense UpdateMonthlyExpense(MonthlyExpense newExpense, int id)
        {
            var oldExpense = _CoHousingData.MonthlyExpenses.FirstOrDefault(e => e.ExpenditureId == id);
            if (oldExpense == null)
                return null;
            oldExpense.ExpenditureId = newExpense.ExpenditureId;
            oldExpense.BuildingCode = newExpense.BuildingCode;
            oldExpense.Description = newExpense.Description;
            oldExpense.Amount = newExpense.Amount;
            _CoHousingData.SaveChanges();
            return newExpense;
        }
    }
}

