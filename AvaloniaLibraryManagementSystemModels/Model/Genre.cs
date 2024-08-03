using System.ComponentModel.DataAnnotations;

namespace AvaloniaLibraryManagementSystemModels.Model;


public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<BookGenre> BookGenres { get; set; }
    
}