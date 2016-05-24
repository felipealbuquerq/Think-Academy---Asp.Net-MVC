using System.Collections.Generic;
using System.Data.SQLite;

namespace Site.Models
{
    public class DalSuppliers
    {
        protected IConnection _connection;
        public DalSuppliers(IConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Suppliers> All(string name = null)
        {
            using (SQLiteCommand command = _connection.CreateCommand())
            {
                command.CommandType = System.Data.CommandType.Text;
                if (string.IsNullOrEmpty(name))
                {
                    command.CommandText = "SELECT Id, Name FROM Suppliers ORDER BY Name";
                }
                else
                {
                    command.CommandText = "SELECT Id, Name FROM Suppliers WHERE Name LIKE @Name ORDER BY Name";
                    command.Parameters.Add("@Name", System.Data.DbType.String).Value = string.Format("%{0}%", name);
                }                
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            yield return Suppliers.Create(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
            }
        }
    }
}