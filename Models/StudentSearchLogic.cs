using System.Linq;
using BookingSystem.Models;

public class StudentSearchLogic
{
    private BookingSystemContext Context;
    public StudentSearchLogic()
    {
        Context = new BookingSystemContext();
    }

    public IQueryable<Student> GetProducts(StudentSearchModel searchModel)
    {
        var result = Context.Student.AsQueryable();
        if (searchModel != null)
        {
            if (searchModel.ID.HasValue)
                result = result.Where(x => x.ID  == searchModel.ID);
            if (!string.IsNullOrEmpty(searchModel.Name))
                result = result.Where(x => x.Name.Contains(searchModel.Name));
            if (!string.IsNullOrEmpty(searchModel.Course))
                result = result.Where(x => x.Course.Contains(searchModel.Course));
            if (searchModel.Paid)
                result = result.Where(x => x.Paid == searchModel.Paid);
        }
        return result;     
    }
}
