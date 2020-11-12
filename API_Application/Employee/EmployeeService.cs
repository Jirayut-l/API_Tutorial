using API_Infrastructure;
using API_Model;

namespace API_Application
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeModel GetEmployee(int fkEmpId)
        {
            return _employeeRepository.GetEmployee(fkEmpId);
        }
    }
}