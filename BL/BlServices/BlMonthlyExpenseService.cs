using BL.BlApi;
using DAL.Models;

namespace BL.BlServices;

public class BlMonthlyExpenseService : IBlMonthlyExpense
{
    IMonthlyExpense DalMonthlyExpense;
    IMapper mapper;
    public BlMonthlyExpenseService(DalManager dalManager)
    {
        this.DalMonthlyExpense = dalManager.MonthlyExpense;
        var config = new MapperConfiguration(cfg => cfg.AddProfile<BlProfile>());
        mapper = config.CreateMapper();
    }

    public List<BlMonthlyExpense> GetMonthlyExpenseList(int code)
    {
        List<BlMonthlyExpense> list = new List<BlMonthlyExpense>();
        var listFromDal = DalMonthlyExpense.GetMEListByBuildingId(code);
        listFromDal.ForEach(E => list.Add(mapper.Map<BlMonthlyExpense>(E)));

        //static int compareByDate(BlMonthlyExpense m1, BlMonthlyExpense m2) => m1.Date > m2.Date;
        //Comparison<BlMonthlyExpense> func = compareByDate;
        //list.Sort(func);

        //list.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
        return list;
    }
    public BlMonthlyExpense AddMonthlyExpense(BlMonthlyExpense expense)
    {
        MonthlyExpense expenseToAdd = mapper.Map<MonthlyExpense>(expense);
        DalMonthlyExpense.AddMonthlyExpense(expenseToAdd);
        return mapper.Map<BlMonthlyExpense>(expenseToAdd);
    }
}
