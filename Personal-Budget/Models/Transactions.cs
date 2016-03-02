using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Budget.Models
{
    public class Transactions
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime DateOfTran { get; set; }

        public string Description { get; set; }
        public string TranType { get; set; }
        public double Amount { get; set; }
    }
}
