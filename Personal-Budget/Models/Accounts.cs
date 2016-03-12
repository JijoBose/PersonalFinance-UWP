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

        public string AccountName { get; set; }
        public double Money { get; set; }

    }
}
