namespace AvaloniaLibraryManagementSystemModels.Systems;

public static class SqlRequests
{
    public const string CreateNewDB = @"

CREATE TABLE IF NOT EXISTS Жанры (
                       Код_Жанр INTEGER PRIMARY KEY,
                       Название TEXT
);

CREATE TABLE IF NOT EXISTS Авторы (
                        Код_Автор INTEGER PRIMARY KEY,
                        Имя TEXT,
                        Фамилия TEXT,
                        Отчество TEXT,
                        Псевдоним TEXT
);

CREATE TABLE IF NOT EXISTS Издатели (
                          Код_Издателя INTEGER PRIMARY KEY,
                          Имя_Издателя TEXT
);

CREATE TABLE IF NOT EXISTS ББК (
                     Код_ББК INTEGER PRIMARY KEY,
                     Научные_Индекс TEXT,
                     Массовые_Индекс TEXT,
                     Название_раздела TEXT
);

CREATE TABLE IF NOT EXISTS Книги (
                       Код_Книги INTEGER PRIMARY KEY,
                       Заголовок TEXT,
                       Описание TEXT NOT NULL,
                       Код_Автор INTEGER NOT NULL,
                       Код_ББК INTEGER NOT NULL,
                       Дата DATE NOT NULL,
                       Код_Издателя INTEGER NOT NULL,
                       FOREIGN KEY (Код_Автор) REFERENCES Авторы(Код_Автор),
                       FOREIGN KEY (Код_Издателя) REFERENCES Издатели(Код_Издателя),
                       FOREIGN KEY (Код_ББК) REFERENCES ББК(Код_ББК)
);

CREATE TABLE IF NOT EXISTS ЖанрыКниги (
                            Код_Книги INTEGER,
                            Код_Жанр INTEGER,
                            PRIMARY KEY (Код_Книги, Код_Жанр),
                            FOREIGN KEY (Код_Книги) REFERENCES Книги(Код_Книги),
                            FOREIGN KEY (Код_Жанр) REFERENCES Жанры(Код_Жанр)
);";

    public const string GetBookQuery = @"
                    SELECT 
                        k.Код_Книги,
                        k.Заголовок,
                        a.Код_Автор || ' ' || a.Имя || ' ' || a.Фамилия || a.Отчество AS Author,
                        b.Научные_Индекс || ' ' || b.Массовые_Индекс || ' ' || b.Название_раздела AS BBK,
                        GROUP_CONCAT(j.Название, ', ') AS Genres,
                        k.Дата,
                        i.Имя_Издателя AS Publisher,
                        k.Описание
                    FROM 
                        Книги k
                        INNER JOIN Авторы a ON k.Код_Автор = a.Код_Автор
                        INNER JOIN ББК b ON k.Код_ББК = b.Код_ББК
                        INNER JOIN ЖанрыКниги jk ON k.Код_Книги = jk.Код_Книги
                        INNER JOIN Жанры j ON jk.Код_Жанр = j.Код_Жанр
                        INNER JOIN Издатели i ON k.Код_Издателя = i.Код_Издателя
                    GROUP BY 
                        k.Код_Книги, k.Заголовок, a.Имя, a.Фамилия, b.Научные_Индекс, b.Массовые_Индекс, k.Дата, i.Имя_Издателя, k.Описание;
                    ";

    public const string GenerateRandomData = @"    -- Insert into Жанры table
INSERT INTO Жанры (Код_Жанр, Название)
VALUES (1, 'Classic'),
       (2, 'Fiction'),
       (3, 'Science Fiction'),
       (4, 'Comedy'),
       (5, 'Dystopian'),
       (6, 'Fantasy'),
       (7, 'Adventure'),
       (8, 'Romance'),
       (9, 'Young Adult'),
       (10, 'Historical Fiction'),
       (11, 'Philosophical'),
       (12, 'Gothic');

-- Insert into Авторы table
INSERT INTO Авторы (Код_Автор, Имя, Фамилия, Отчество, Псевдоним)
VALUES (1, 'Harper', 'Lee', '', ''),
       (2, 'Douglas', 'Adams', '', ''),
       (3, 'George', 'Orwell', '', ''),
       (4, 'J.R.R.', 'Tolkien', '', ''),
       (5, 'Jane', 'Austen', '', ''),
       (6, 'J.D.', 'Salinger', '', ''),
       (7, 'F.', 'Fitzgerald', '', ''),
       (8, 'Leo', 'Tolstoy', '', ''),
       (9, 'Herman', 'Melville', '', ''),
       (10, 'Oscar', 'Wilde', '', ''),
       (11, 'Emily', 'Brontë', '', ''),
       (12, 'Charlotte', 'Brontë', '', ''),
       (13, 'Alexandre', 'Dumas', '', ''),
       (14, 'Mark', 'Twain', '', ''),
       (15, 'Nathaniel', 'Hawthorne', '', '');

-- Insert into Издатели table
INSERT INTO Издатели (Код_Издателя, Имя_Издателя)
VALUES (1, 'J.B. Lippincott & Co.'),
       (2, 'Pan Books'),
       (3, 'Secker and Warburg'),
       (4, 'Allen & Unwin'),
       (5, 'T. Egerton'),
       (6, 'Little, Brown and Company'),
       (7, 'Charles Scribner''s Sons'),
       (8, 'The Russian Messenger'),
       (9, 'Harper & Brothers'),
       (10, 'Lippincott''s Monthly Magazine'),
       (11, 'Thomas Cautley Newby'),
       (12, 'Smith, Elder & Co.'),
       (13, 'Le Journal des Débats'),
       (14, 'Charles L. Webster and Company'),
       (15, 'Ticknor, Reed, and Fields');

-- Insert into ББК table
INSERT INTO ББК (Код_ББК, Научные_Индекс, Массовые_Индекс, Название_раздела)
VALUES (1, 'Ш4', '84', 'Художественная литература'),
       (2, 'Э7', '87', 'Философия'),
       (3, 'Ш1', '81', 'Языкознание (лингвистика)'),
       (4, 'Ш2', '82', 'Фольклор. Фольклористика'),
       (5, 'Ш3', '83', 'Литературоведение');

-- Insert into Книги table
INSERT INTO Книги (Код_Книги, Заголовок, Описание, Код_Автор, Код_ББК, Дата, Код_Издателя)
VALUES (1, 'To Kill a Mockingbird', 'A classic novel about racial injustice in the Deep South', 1, 1, '1960-07-11', 1),
       (2, 'The Hitchhiker''s Guide to the Galaxy',
        'A comedic science fiction series about an unwitting human and his alien friend', 2, 2, '1979-10-12', 2),
       (3, '1984', 'A dystopian novel about a totalitarian future society', 3, 3, '1949-06-08', 3),
       (4, 'The Lord of the Rings', 'A high fantasy novel about a hobbit''s quest to destroy the One Ring', 4, 4,
        '1954-07-29', 4),
       (5, 'Pride and Prejudice', 'A romantic novel about the lives of the Bennett sisters in 19th-century England', 5,
        5, '1813-01-28', 5),
       (6, 'The Catcher in the Rye', 'A coming-of-age novel about teenage angst and alienation', 6, 1, '1951-07-16', 6),
       (7, 'The Great Gatsby', 'A novel about the American Dream and the excesses of the Roaring Twenties', 7, 2,
        '1925-04-10', 7),
       (8, 'War and Peace', 'A historical novel about the Napoleonic Wars and their impact on Russian society', 8, 3,
        '1865-01-01', 8),
       (9, 'Moby-Dick', 'An epic novel about the obsessive hunt for a white whale', 9, 4, '1851-11-14', 9),
       (10, 'The Picture of Dorian Gray', 'A philosophical novel about the nature of beauty and morality', 10, 5,
        '1890-07-20', 10),
       (11, 'Wuthering Heights',
        'A classic romance novel about the tumultuous relationship between Catherine and Heathcliff', 11, 1,
        '1847-12-01', 11),
       (12, 'Jane Eyre', 'A gothic romance novel about a young woman''s journey to independence', 12, 2, '1847-10-16',
        12),
       (13, 'The Count of Monte Cristo', 'An adventure novel about betrayal, revenge, and redemption', 13, 3,
        '1844-08-18', 13),
       (14, 'The Adventures of Huckleberry Finn',
        'A classic American novel about a young boy''s journey down the Mississippi River', 14, 4, '1885-02-18', 14),
       (15, 'The Scarlet Letter', 'A novel about sin, guilt, and redemption in 17th-century Puritan Massachusetts', 15,
        5, '1850-03-16', 15);

INSERT INTO ЖанрыКниги (Код_Книги, Код_Жанр) VALUES
                (1, 1),  -- Classic
                (1, 2),  -- Fiction
                (2, 3),  -- Science Fiction
                (2, 4),  -- Comedy
                (3, 5),  -- Dystopian
                (3, 1),  -- Classic
                (4, 6),  -- Fantasy
                (4, 7),  -- Adventure
                (5, 8),  -- Romance
                (5, 1),  -- Classic
                (6, 9),  -- Young Adult
                (6, 1),  -- Classic
                (7, 10), -- Historical Fiction
                (7, 1),  -- Classic
                (8, 7),  -- Adventure
                (8, 1),  -- Classic
                (9, 11), -- Philosophical
                (9, 8),  -- Romance
                (10, 1), -- Classic
                (11, 8), -- Romance
                (11, 1), -- Classic
                (12, 12), -- Gothic
                (12, 1), -- Classic
                (13, 7), -- Adventure
                (13, 1), -- Classic
                (14, 1), -- Classic
                (14, 7), -- Adventure
                (15, 1), -- Classic
                (15, 10) -- Historical Fiction";
}