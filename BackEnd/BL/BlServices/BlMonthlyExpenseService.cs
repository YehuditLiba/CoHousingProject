using BL.BlApi;

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

    public List<MonthlyExpense> GetMonthlyExpenseList(int code)
    {
        List<MonthlyExpense> list = new List<MonthlyExpense>();
        var listFromDal = DalMonthlyExpense.GetMEListByBuildingId(code);
        listFromDal.ForEach(E => list.Add(mapper.Map<MonthlyExpense>(E)));
        //foreach (var t in listFromDal)
        //{
        //    list.Add(new MonthlyExpense(){
        //        ExpenditureId=t.ExpenditureId,
        //        Description=t.Description,
        //        Amount=t.Amount,
        //    });
        //}
        //static int compareByDate(MonthlyExpense m1, MonthlyExpense m2) => m1.Date. - m2.Date;
        //Comparison<MonthlyExpense> func = compareByDate;
        //list.Sort(func);

        //list.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
        return list;
    }
    public MonthlyExpense AddMonthlyExpense(MonthlyExpense expense)
    {
        //return DalMonthlyExpense.AddMonthlyExpense(expense);
        return null;
    }
}
