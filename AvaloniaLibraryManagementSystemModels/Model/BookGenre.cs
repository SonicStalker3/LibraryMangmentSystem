using System.ComponentModel.DataAnnotations.Schema;

namespace AvaloniaLibraryManagementSystemModels.Model;

public class BookGenre
{ 
    public int BookId { get; set; }
    public virtual Book Book { get; set; }
    public int GenreId { get; set; }
    public virtual Genre Genre { get; set; }
}