using API_Model;

namespace API_Application
{
    public interface IEmployeeService
    {
        EmployeeModel GetEmployee(int fkEmpId);

    }
}