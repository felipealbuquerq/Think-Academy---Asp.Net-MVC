namespace Site.Models
{
    public class Suppliers
    {
        public Suppliers() { }

        public Suppliers(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public static Suppliers Create(int id, string name)
        {
            return new Suppliers(id, name);
        }
    }
}