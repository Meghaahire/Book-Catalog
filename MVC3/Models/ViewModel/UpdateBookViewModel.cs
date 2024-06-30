namespace MVC3.Models.ViewModel
{
    public class UpdateBookViewModel
    {

        public Guid Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishDate { get; set; }
        public long Price { get; set; }
    }
}
