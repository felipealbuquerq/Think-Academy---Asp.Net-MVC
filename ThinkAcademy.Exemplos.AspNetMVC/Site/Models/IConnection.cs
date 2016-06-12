using System.Data.SQLite;
using System;
namespace Site.Models
{
    public interface IConnection : IDisposable
    {
        void Close();
        SQLiteConnection Open();
        SQLiteCommand CreateCommand();
    }
}