using System.Collections.ObjectModel;
using AvaloniaLibraryManagementSystemModels.DebugingData;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration;

namespace AvaloniaLibraryManagementSystemModels.Model;

public class DatabaseContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BBK> BBKs { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }

    public DatabaseContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        SQLitePCL.Batteries.Init();
        optionsBuilder.UseSqlite("Data Source=Library.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookGenre>()
            .HasKey(bg => new { bg.BookId, bg.GenreId });

        modelBuilder.Entity<BookGenre>()
            .HasOne(bg => bg.Book)
            .WithMany(b => b.BookGenres)
            .HasForeignKey(bg => bg.BookId);

        modelBuilder.Entity<BookGenre>()
            .HasOne(bg => bg.Genre)
            .WithMany(g => g.BookGenres)
            .HasForeignKey(bg => bg.GenreId);
    }

    public void CreateDebugDatabase()
    {
        Genres.AddRange(TestingData.Genres);
        SaveChanges();

        Authors.AddRange(TestingData.Authors);
        SaveChanges();

        Publishers.AddRange(TestingData.Publishers);
        SaveChanges();

        BBKs.AddRange(TestingData.BBKs);
        SaveChanges();

        Books.AddRange(TestingData.Book);
        SaveChanges();

        BookGenres.AddRange(TestingData.BookGenres);
        SaveChanges();
    }

    public IEnumerable<Book> GetBooks()
    {
        Genres.Load();
        BookGenres.Load();
        return Books
            .Include(b => b.Author)
            .Include(b => b.BBK)
            .Include(b => b.BookGenres)
            .Include(b => b.Publisher)
            .ToList();
    }

    public IEnumerable<Genre> GetGenres()
    {
        Genres.Load();
        return Genres
            .OrderBy(g => g.Name) // sort by name
            .Include(g => g.BookGenres)
            .ToList();

    }
}