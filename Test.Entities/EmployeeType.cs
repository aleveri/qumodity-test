namespace Test.Entities
{
    public class EmployeeType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
