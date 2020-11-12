using API_Model;
using AutoMapper;

namespace API_Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMapper _mapper;
        private readonly API_TESTContext _apiTestContext;

        public EmployeeRepository(IMapper mapper)
        {
            _mapper = mapper;
            _apiTestContext = new API_TESTContext();
        }

        public EmployeeModel GetEmployee(int fkEmpId)
        {
            var entity = _apiTestContext.Employee.Find(fkEmpId);
            return _mapper.Map<EmployeeModel>(entity);
        }
    }
}