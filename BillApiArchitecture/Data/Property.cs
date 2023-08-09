namespace BillApiArchitecture.Data
{
    public class Property
    {
        public Guid Id { get; set; }

        public string? Number { get; set; }

        public string? Address { get; set; }

        public Guid? OwnerId { get; set; }

        public Owner? Owner { get; set; }

    }
}
