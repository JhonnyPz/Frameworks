namespace app.Data;

public class DBConnection
{
  public DBConnection(string _connectionString) => ConnectionString = _connectionString;
  public string ConnectionString { get; set; }
}