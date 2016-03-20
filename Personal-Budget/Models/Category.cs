using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace Personal_Budget.Models
{
    public class Category
    {
        SQLiteConnection conn; // adding an SQLite connection
        string path = "Findata.sqlite"; // Name of the database must be the same

        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        public string Method { get; set; }
        public string Symbols { get; set; }

        public void LoadCategory()
        {
            /// Initializing a database
            conn = new SQLiteConnection(path);
            // Creating table
            conn.CreateTable<Category>();
            conn.Insert(new Category { Method = "Income", Symbols = "Home"});
            conn.Insert(new Category { Method = "Income", Symbols = "Home" });
            conn.Insert(new Category { Method = "Income", Symbols = "Home" });
            conn.Insert(new Category { Method = "Income", Symbols = "Home" });
            conn.Insert(new Category { Method = "Income", Symbols = "Home" });
            conn.Insert(new Category { Method = "Income", Symbols = "Home" });
            conn.Insert(new Category { Method = "Income", Symbols = "Home" });
            conn.Insert(new Category { Method = "Income", Symbols = "Home" });
            conn.Insert(new Category { Method = "Income", Symbols = "Home" });
            conn.Insert(new Category { Method = "Income", Symbols = "Home" });

        }
    }
}
