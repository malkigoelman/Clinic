namespace Mirpaha.Entities
{
    public class Client
    {
     

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Payment { get; set; }
        public List<Comment> Comments { get; set; }
    }
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
    }
}
