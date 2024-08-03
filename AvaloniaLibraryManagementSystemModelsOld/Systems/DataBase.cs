using System.Data.SqlClient;

namespace AvaloniaLibraryManagementSystemModels.Systems;


public abstract class DataBase
{
    public virtual void OpenConnection()
    {

    }

    public virtual void CloseConnection()
    {

    }

    /*public virtual T GetConnection<T>()
    {
        return null;
    }*/
    public virtual void PrepareDB()
    {
        
    }
    
}