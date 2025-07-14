namespace LawPavillion.Library.Backend.API.Dtos
{
    /// <summary>
    /// Data Transfer Object for returning book details to clients.
    /// </summary>
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
