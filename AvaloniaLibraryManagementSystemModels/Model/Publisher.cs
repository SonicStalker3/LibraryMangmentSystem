using System.ComponentModel.DataAnnotations;

namespace AvaloniaLibraryManagementSystemModels.Model;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ISBN { get; set; }
}