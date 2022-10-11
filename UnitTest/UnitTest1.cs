using Moq;
using Test.Entities;
using Test.Interfaces;

namespace UnitTest
{
    public class UnitTest1
    {
        private readonly Mock<ISqlRepository<Employee>> _repository;

        public UnitTest1()
        {
            _repository = new Mock<ISqlRepository<Employee>>();
        }

        private void Setup()
        {
            //_repository.Setup(x => x.Insert(It.IsAny<Employee>))
        }


        [Fact]
        public void Test1()
        {

        }
    }
}