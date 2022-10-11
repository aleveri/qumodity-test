using Test.Entities;
using Test.Interfaces;
using Test.Interfaces.Commands;

namespace Test.Commands
{
    public class EmployeeCommand : IEmployeeCommand
    {
        private readonly ISqlRepository<Employee> _employeeRepository;

        public EmployeeCommand(ISqlRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task Create(Employee entity)
        {
            try
            {
                await _employeeRepository.Insert(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(Employee entity)
        {
            try
            {
                await _employeeRepository.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
