namespace GraphQlService;

public class Book {

    public Book(int id, int authorId, string title)
    {
        Id = id;
        AuthorId = authorId;
        Title = title;
    }

    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
}
