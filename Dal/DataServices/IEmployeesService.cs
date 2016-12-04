using Dal.DataModel;

namespace Dal.DataServices
{
    public interface IEmployeesService
    {
        void Add(Employee employee);

        Employee GetEmployee(string idCardNumber);
    }
}
