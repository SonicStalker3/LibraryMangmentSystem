using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaLibraryManagementSystemModels.Model;

namespace AvaloniaApplication1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public string ISBN { get; set; }
        public BBK BBK { get; set; }
        public ICollection<Genre> Genres { get; set; }

        public DateOnly PublicationDate { get; set; }
        public int PublicationYear => PublicationDate.Year;
        public Publisher Publisher { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
        
        public string CoverImage { get; }
        
        public string GenreTags
        {
            get
            {
                return string.Join(", ", Genres.Select(g => g.Name));
            }
        }

        

        public Book(int Id, string Title, string Author, string ISBN, DateOnly Publication, string Publisher,
            string? Description = null, bool IsAvailable = false, List<Genre> Genres = null)
        {
            this.Id = Id;
            this.Title = Title;
            this.Author = new Author{FirstName = Author};
            this.ISBN = ISBN;
            this.PublicationDate = Publication;
            this.Publisher = new Publisher() { Name = Publisher };
            this.Description = Description;
            this.IsAvailable = IsAvailable;
            this.Genres = Genres;
        }

        public Book(int Id, string Title, string Author, string ISBN, int PublicationYear, string Publisher,
            string? Description = null, bool IsAvailable = false, List<Genre> Genres = null): this(Id, Title, Author, ISBN, new DateOnly(PublicationYear, 0, 0), Publisher, Description, IsAvailable: IsAvailable,  Genres: Genres) { }

        public Book()
        {
        }

        public void SetAvailable(bool available) => IsAvailable = available;

        //public virtual ICollection<Circulation> Circulations { get; set; }
    }
}
