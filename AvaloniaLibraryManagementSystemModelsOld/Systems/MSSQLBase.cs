using System.Data.SqlClient;

namespace AvaloniaLibraryManagementSystemModels.Systems;

public class MssqlBase: DataBase
{
    private SqlConnection _connection;
    
    public MssqlBase(string dataSource, string dbName, bool isSecure)
    {
        string con = string.Join(';', 
            $"Data Source={dataSource}",
            $"Initial Catalog={dbName}",
            $"Trusted_Connection={isSecure}");
        _connection = new SqlConnection(con);
        //DataSource=ARSENIY-DESKTOP;Initial Catalog=Library;Integrated Security=True
    }
    public override void OpenConnection()
    {
        if (_connection.State == System.Data.ConnectionState.Closed)
        {
            _connection.Open();
        }
    }

    public override void CloseConnection()
    {
        if (_connection.State == System.Data.ConnectionState.Open)
        {
            _connection.Close();
        }
    }

    public SqlConnection GetConnection()
    {
        return _connection;
    }
}