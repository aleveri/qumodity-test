namespace Test.Entities
{
    public class Shop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<ShopEmployee> Employees { get; set; }
    }
}
