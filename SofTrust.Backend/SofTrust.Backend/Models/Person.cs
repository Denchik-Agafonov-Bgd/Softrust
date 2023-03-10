namespace SofTrust.Backend.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;

        public Person() { }

        public Person(string Name, string Email, string Phone)
        {
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
        }

    }
}
