using DAL.DalApi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    internal class DalOneTimeExpenseService : IOneTimeExpense
    {
        CoHousingContext _CoHousingData;
        public DalOneTimeExpenseService(CoHousingContext coHousingData)
        {
            _CoHousingData = coHousingData;
        }

        public List<OneTimeExpense> GetOTEListByBuildingId(int code)
        {
            List<OneTimeExpense> list = new List<OneTimeExpense>();
            foreach (var t in _CoHousingData.OneTimeExpenses)
            {
                if (t.BuildingCode==code)
                    list.Add(t);
            }
            return list;
        }
        public OneTimeExpense AddOneTimeExpense(OneTimeExpense ote)
        {
            _CoHousingData.OneTimeExpenses.Add(ote);
            _CoHousingData.SaveChanges();
            return ote;
        }
        public OneTimeExpense RemoveOneTimeExpense(int code)
        {
            var expense = _CoHousingData.OneTimeExpenses.FirstOrDefault(e => e.ExpenditureId== code);
            if (expense == null) { return null; }
            _CoHousingData.OneTimeExpenses.Remove(expense);
            _CoHousingData.SaveChanges();
            return expense;
        }
        public OneTimeExpense UpdateOneTimeExpense(OneTimeExpense newExpense, int id)
        {
            var oldExpense= _CoHousingData.OneTimeExpenses.FirstOrDefault(e => e.ExpenditureId == id);
            if (oldExpense == null)
                return null;
            oldExpense.BuildingCode = newExpense.BuildingCode;
            oldExpense.Description = newExpense.Description;
            oldExpense.Date = newExpense.Date;
            oldExpense.Total = newExpense.Total;
            _CoHousingData.SaveChanges();
            return newExpense;
        }
    }
}
