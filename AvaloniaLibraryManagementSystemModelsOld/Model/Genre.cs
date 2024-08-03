namespace AvaloniaApplication1.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; }

    public Genre(int Id, string Name)
    {
        this.Id = Id;
        this.Name = Name;
    }

    public Genre()
    {
    }
}