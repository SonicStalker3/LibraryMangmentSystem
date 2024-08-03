using System.ComponentModel.DataAnnotations;
using SQLite;

namespace AvaloniaLibraryManagementSystemModels.Model;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Patronymic { get; set; }
    public string? Pseudonym { get; set; }

    public string FullName => string.Join(" ",FirstName, LastName);
}