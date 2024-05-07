using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IOneTimeExpense
    {
        public List<OneTimeExpense> GetOTEListByBuildingId(int code);
        public OneTimeExpense AddOneTimeExpense(OneTimeExpense ote);
        public OneTimeExpense RemoveOneTimeExpense(int code);
        public OneTimeExpense UpdateOneTimeExpense(OneTimeExpense newExpense, int id);
    }
}
