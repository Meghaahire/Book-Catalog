namespace MVC3.Models.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishDate { get; set; }
        public long Price { get; set; }

    }
}
