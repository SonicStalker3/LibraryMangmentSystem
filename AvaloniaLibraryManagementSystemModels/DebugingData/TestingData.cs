using AvaloniaLibraryManagementSystemModels.Model;

namespace AvaloniaLibraryManagementSystemModels.DebugingData;

public class TestingData
{
    public static Genre[] Genres = new[]
    {
        new Genre { Id = 1, Name = "Классика" },
        new Genre { Id = 2, Name = "Художественная литература" },
        new Genre { Id = 3, Name = "Научная фантастика" },
        new Genre { Id = 4, Name = "Комедия" },
        new Genre { Id = 5, Name = "Антиутопия" },
        new Genre { Id = 6, Name = "Фэнтези" },
        new Genre { Id = 7, Name = "Приключения" },
        new Genre { Id = 8, Name = "Роман" },
        new Genre { Id = 9, Name = "Литература для молодежи" },
        new Genre { Id = 10, Name = "Историческая проза" },
        new Genre { Id = 11, Name = "Философская литература" },
        new Genre { Id = 12, Name = "Готика" }
    };
    
    public static Author[] Authors = new[]
    {
        new Author { Id = 1, FirstName = "Харпер", LastName = "Ли" },
        new Author { Id = 2, FirstName = "Дуглас", LastName = "Адамс" },
        new Author { Id = 3, FirstName = "Джордж", LastName = "Оруэлл" },
        new Author { Id = 4, FirstName = "Дж.Р.Р.", LastName = "Толкиен" },
        new Author { Id = 5, FirstName = "Джейн", LastName = "Остен" },
        new Author { Id = 6, FirstName = "Дж.Д.", LastName = "Сэлинджер" },
        new Author { Id = 7, FirstName = "Ф.", LastName = "Фицджеральд" },
        new Author { Id = 8, FirstName = "Лев", LastName = "Толстой" },
        new Author { Id = 9, FirstName = "Герман", LastName = "Мелвилл" },
        new Author { Id = 10, FirstName = "Оскар", LastName = "Уайльд" },
        new Author { Id = 11, FirstName = "Эмили", LastName = "Бронте" },
        new Author { Id = 12, FirstName = "Шарлотта", LastName = "Бронте" },
        new Author { Id = 13, FirstName = "Александр", LastName = "Дюма" },
        new Author { Id = 14, FirstName = "Марк", LastName = "Твен" },
        new Author { Id = 15, FirstName = "Натаниэль", LastName = "Хоторн" }
    };
    
    public static Publisher[] Publishers = new[]
    {
        new Publisher { Id = 1, ISBN="0-397-00436-2", Name = "Джей Би Липпинкотт и Ко." },
        new Publisher { Id = 2, ISBN="0-330-02544-3", Name = "Пан Букс" },
        new Publisher { Id = 3, ISBN="0-436-20135-6", Name = "Секер и Уорбург" },
        new Publisher { Id = 4, ISBN="0-04-823195-9", Name = "Аллен и Анвин" },
        new Publisher { Id = 5, ISBN="1-84022-427-3", Name = "Т. Эгертон" },
        new Publisher { Id = 6, ISBN="0-316-16004-6", Name = "Литл, Браун и Компани" },
        new Publisher { Id = 7, ISBN="0-684-80359-2", Name = "Чарльз Скрибнерс Санс" },
        new Publisher { Id = 8, ISBN="5-93347-108-1", Name = "Русский Вестник" },
        new Publisher { Id = 9, ISBN="0-06-112008-1", Name = "Харпер и Братья" },
        new Publisher { Id = 10, ISBN="1-58734-038-6", Name = "Липпинкоттс Мансли Магазин" },
        new Publisher { Id = 11, ISBN="0-19-283369-5", Name = "Томас Котли Ньюби" },
        new Publisher { Id = 12, ISBN="0-09-943709-5", Name = "Смит, Элдер и Ко." },
        new Publisher { Id = 13, ISBN="2-07-040381-5", Name = "Журнал Дебатов" },
        new Publisher { Id = 14, ISBN="0-943396-35-3", Name = "Чарльз Л. Вебстер и Компани" },
        new Publisher { Id = 15, ISBN="0-395-08309-4", Name = "Тикнор, Рид, и Филдс" }
    };
   public static BBK[] BBKs = new[]
    {
        new BBK { Id = 1, ScientificIndex = "Ш4", MassIndex = "84", SectionName = "Художественная литература" },
        new BBK { Id = 2, ScientificIndex = "Э7", MassIndex = "87", SectionName = "Философия" },
        new BBK { Id = 3, ScientificIndex = "Ш1", MassIndex = "81", SectionName = "Языкознание (лингвистика)" },
        new BBK { Id = 4, ScientificIndex = "Ш2", MassIndex = "82", SectionName = "Фольклор. Фольклористика" },
        new BBK { Id = 5, ScientificIndex = "Ш3", MassIndex = "83", SectionName = "Литературоведение" }
    };
    
    public static Book[] Book = new[]
    {
        new Book
        {
            Id = 1, Title = "Убить Пересмешника",
            Description = "Классический роман о расовой несправедливости в глубоком Юге",
            AuthorId = 1, BBKId = 1, PublicationDate = new DateOnly(1960, 7, 11), PublisherId = 1
        },
        new Book
        {
            Id = 2, Title = "Путеводитель по Галактике",
            Description = "Комедийная научно-фантастическая серия о невольном человеке и его инопланетном друге",
            AuthorId = 2, BBKId = 2, PublicationDate = new DateOnly(1979, 10, 12), PublisherId = 2
        },
        new Book
        {
            Id = 3, Title = "1984", Description = "Антиутопический роман о тоталитарном будущем обществе",
            AuthorId = 3, BBKId = 3, PublicationDate = new DateOnly(1949, 6, 8), PublisherId = 3
        },
        new Book
        {
            Id = 4, Title = "Властелин Колец",
            Description = "Высокофэнтезийный роман о квесте хоббита по уничтожению Единого Кольца",
            AuthorId = 4, BBKId = 4, PublicationDate = new DateOnly(1954, 7, 29), PublisherId = 4
        },
        new Book
        {
            Id = 5, Title = "Гордость и Предубеждение",
            Description = "Романтический роман о жизни сестер Беннет в 19-м веке Англии",
            AuthorId = 5, BBKId = 5, PublicationDate = new DateOnly(1813, 1, 28), PublisherId = 5
        },
        new Book
        {
            Id = 6, Title = "Над пропастью во ржи",
            Description = "Роман о взрослении и отчуждении подростка",
            AuthorId = 6, BBKId = 1, PublicationDate = new DateOnly(1951, 7, 16), PublisherId = 6
        },
        new Book
        {
            Id = 7, Title = "Великий Гэтсби",
            Description = "Роман об Американской Мечте и избытках эпохи Джаза",
            AuthorId = 7, BBKId = 2, PublicationDate = new DateOnly(1925, 4, 10), PublisherId = 7
        },
        new Book
        {
            Id = 8, Title = "Война и Мир",
            Description = "Исторический роман о Наполеоновских войнах и их влиянии на русское общество",
            AuthorId = 8, BBKId = 3, PublicationDate = new DateOnly(1865, 1, 1), PublisherId = 8
        },
        new Book
        {
            Id = 9, Title = "Моби-Дик", Description = "Эпический роман о навязчивом поиске белого кита",
            AuthorId = 9, BBKId = 4, PublicationDate = new DateOnly(1851, 11, 14), PublisherId = 9
        },
        new Book
        {
            Id = 10, Title = "Портрет Дориана Грея",
            Description = "Философский роман о природе красоты и морали",
            AuthorId = 10, BBKId = 5, PublicationDate = new DateOnly(1890, 7, 20), PublisherId = 10
        },
        new Book
        {
            Id = 11, Title = "Утиный Город",
            Description =
                "Классический роман о бурной любви между Кэтрин и Хитклиффом",
            AuthorId = 11, BBKId = 1, PublicationDate = new DateOnly(1847, 12, 1), PublisherId = 11
        },
        new Book
        {
            Id = 12, Title = "Джейн Эйр",
            Description = "Готический романтический роман о молодой женщине, ищущей независимости",
            AuthorId = 12, BBKId = 2, PublicationDate = new DateOnly(1847, 10, 16), PublisherId = 12
        },
        new Book
        {
            Id = 13, Title = "Граф Монте-Кристо",
            Description = "Приключенческий роман о предательстве, мести и искуплении",
            AuthorId = 13, BBKId = 3, PublicationDate = new DateOnly(1844, 8, 18), PublisherId = 13
        },
        new Book
        {
            Id = 14, Title = "Приключения Гекльберри Финна",
            Description = "Классический американский роман о путешествии молодого мальчика по Миссисипи",
            AuthorId = 14, BBKId = 4, PublicationDate = new DateOnly(1844, 2, 18), PublisherId = 14
        },
        new Book
        {
            Id = 15, Title = "Алый знак",
            Description = "Роман о грехе, вины и искуплении в 17-м веке Пуританской Массачусетс",
            AuthorId = 15, BBKId = 5, PublicationDate = new DateOnly(1850, 3, 16), PublisherId = 15
        }
    };

    public static BookGenre[] BookGenres = new[]
    {
        new BookGenre { BookId = 1, GenreId = 1 }, // Classic
        new BookGenre { BookId = 1, GenreId = 2 }, // Fiction

        new BookGenre { BookId = 2, GenreId = 3 }, // Science Fiction
        new BookGenre { BookId = 2, GenreId = 4 }, // Comedy

        new BookGenre { BookId = 3, GenreId = 5 }, // Dystopian
        new BookGenre { BookId = 3, GenreId = 1 }, // Classic

        new BookGenre { BookId = 4, GenreId = 6 }, // Fantasy
        new BookGenre { BookId = 4, GenreId = 7 }, // Adventure

        new BookGenre { BookId = 5, GenreId = 8 }, // Romance
        new BookGenre { BookId = 5, GenreId = 1 }, // Classic

        new BookGenre { BookId = 6, GenreId = 9 }, // Young Adult
        new BookGenre { BookId = 6, GenreId = 1 }, // Classic

        new BookGenre { BookId = 7, GenreId = 10 }, // Historical Fiction
        new BookGenre { BookId = 7, GenreId = 1 }, // Classic

        new BookGenre { BookId = 8, GenreId = 7 }, // Adventure
        new BookGenre { BookId = 8, GenreId = 1 }, // Classic

        new BookGenre { BookId = 9, GenreId = 11 }, // Philosophical
        new BookGenre { BookId = 9, GenreId = 8 }, // Romance

        new BookGenre { BookId = 10, GenreId = 1 }, // Classic

        new BookGenre { BookId = 11, GenreId = 8 }, // Romance
        new BookGenre { BookId = 11, GenreId = 1 }, // Classic

        new BookGenre { BookId = 12, GenreId = 12 }, // Gothic
        new BookGenre { BookId = 12, GenreId = 1 }, // Classic

        new BookGenre { BookId = 13, GenreId = 7 }, // Adventure
        new BookGenre { BookId = 13, GenreId = 1 }, // Classic

        new BookGenre { BookId = 14, GenreId = 1 }, // Classic
        new BookGenre { BookId = 14, GenreId = 7 }, // Adventure

        new BookGenre { BookId = 15, GenreId = 1 }, // Classic
        new BookGenre { BookId = 15, GenreId = 10 }, // Historical Fiction
    };
}