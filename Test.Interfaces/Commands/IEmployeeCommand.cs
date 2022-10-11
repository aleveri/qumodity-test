using Test.Entities;

namespace Test.Interfaces.Commands
{
    public interface IEmployeeCommand
    {
        Task Create(Employee entity);
        Task Update(Employee entity);
    }
}
