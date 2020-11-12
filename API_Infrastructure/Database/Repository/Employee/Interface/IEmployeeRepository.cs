using API_Model;

namespace API_Infrastructure
{
    public interface IEmployeeRepository
    {
        EmployeeModel GetEmployee(int fkEmpId);
    }
}