namespace SofTrust.Backend.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; } = String.Empty;

        public Message() { }

        public Message(int PersonId, int SubjectId, string Name)
        {
            this.PersonId = PersonId;
            this.SubjectId = SubjectId;
            this.Name = Name;
        }
    }
}
