using System;
using System.Data.SQLite;
namespace Site.Models
{
    public class Connection : IConnection
    {
        private SQLiteConnection _con;
        public Connection()
        {
            Open();
        }
        public SQLiteConnection Open()
        {
            if (_con == null)
            {
                var c = System.Configuration.ConfigurationManager.ConnectionStrings["sqlite"].ToString();
                _con = new SQLiteConnection(c);
            }

            if (_con.State == System.Data.ConnectionState.Closed)
            {
                _con.Open();
            }

            return _con;
        }

        public void Close()
        {
            if (_con != null)
            {
                if (_con.State == System.Data.ConnectionState.Open)
                {
                    _con.Close();
                }
                _con.Dispose();
                _con = null;
            }
        }

        public void Dispose()
        {
            Close();
        }

        public SQLiteCommand CreateCommand()
        {
            Open();
            return _con.CreateCommand();
        }
    }
}