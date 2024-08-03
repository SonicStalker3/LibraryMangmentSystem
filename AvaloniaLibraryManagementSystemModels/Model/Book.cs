using System.ComponentModel.DataAnnotations.Schema;

namespace AvaloniaLibraryManagementSystemModels.Model;


public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string? CoverImage { get; set; }
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public int BBKId { get; set; }
    public virtual BBK BBK { get; set; }
    public DateOnly PublicationDate { get; set; }
    public int PublicationYear => PublicationDate.Year;
    public int PublisherId { get; set; }
    public virtual Publisher Publisher { get; set; }
    public bool IsAvailable { get; set; }
    public virtual ICollection<BookGenre> BookGenres { get; set; }
    public string Genres => string.Join(", ", BookGenres.Select((genre => genre.Genre.Name)));
}