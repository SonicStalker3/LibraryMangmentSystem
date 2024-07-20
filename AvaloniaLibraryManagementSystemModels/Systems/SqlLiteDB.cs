using System.Data.SQLite;
namespace AvaloniaLibraryManagementSystemModels.Systems;

public class SqlLiteDB: DataBase
{
    public SQLiteConnection _connection;
    
    public SqlLiteDB(string dataSource)
    {
        string con = string.Join(';', 
            $"Data Source={dataSource}");
        _connection = new SQLiteConnection(con);
        //DataSource=ARSENIY-DESKTOP;Initial Catalog=Library;Integrated Security=True
    }
    
    public override void OpenConnection()
    {
        _connection.Open();
    }

    public override void CloseConnection()
    {
        _connection.Close();
    }
    
    public SQLiteConnection GetConnection()
    {
        return _connection;
    }

    public override void PrepareDB()
    {
        if (true)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = "CREATE TABLE Жанры (\n    Код_Жанр INT PRIMARY KEY,\n    Название NVARCHAR(255)\n);\n\nCREATE TABLE Авторы (\n    Код_Автор INT PRIMARY KEY,\n    Имя NVARCHAR(50),\n\tФамилия NVARCHAR(50),\n\tОтчество NVARCHAR(50),\n\tПсевдоним NVARCHAR(50)\n);\n\nCREATE TABLE Издатели (\n    Код_Издателя INT PRIMARY KEY,\n\tИмя_Издателя NVARCHAR(255)\n);\n\nCREATE TABLE ББК (\n    Код_ББК INT PRIMARY KEY,\n    Научные_Индекс NVARCHAR(255),\n\tМассовые_Индекс NVARCHAR(255),\n\tНазвание_раздела NVARCHAR(255)\n);\n\nCREATE TABLE Книги (\n    Код_Книги INT PRIMARY KEY,\n    Заголовок NVARCHAR(50),\n    Описание NVARCHAR(MAX) NOT NULL,\n\tКод_Автор INT NOT NULL,\n\tКод_ББК INT NOT NULL,\n\tДата DATE NOT NULL,\n\tКод_Издателя INT NOT NULL,\n);\n\nCREATE TABLE Жанры_Книги (\n    Код_Книги INT,\n    Код_Жанр INT,\n    PRIMARY KEY (Код_Книги, Код_Жанр),\n    FOREIGN KEY (Код_Книги) REFERENCES Книги(Код_Книги),\n    FOREIGN KEY (Код_Жанр) REFERENCES Жанры(Код_Жанр)\n);\n\nALTER TABLE Книги\nADD CONSTRAINT FK_Книги_Авторы\nFOREIGN KEY (Код_Автор) REFERENCES Авторы(Код_Автор);\n\nALTER TABLE Книги\nADD CONSTRAINT FK_Книги_Издатели\nFOREIGN KEY (Код_Издателя) REFERENCES Издатели(Код_Издателя);\n\nALTER TABLE Книги\nADD CONSTRAINT FK_Книги_ББК\nFOREIGN KEY (Код_ББК) REFERENCES ББК(Код_ББК);";
            command.Connection = _connection;
            command.ExecuteNonQuery();
        }
    }
}