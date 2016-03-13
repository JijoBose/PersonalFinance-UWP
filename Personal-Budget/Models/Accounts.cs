using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Personal_Budget.Models
{
    public class Accounts
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Unique]
        public string AccountName { get; set; }

    }
}
