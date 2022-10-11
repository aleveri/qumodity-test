namespace Test.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public Guid EmployeeTypeId { get; set; }

        public string Name { get; set; }

        public ICollection<ShopEmployee> Shops { get; set; }

    }
}
