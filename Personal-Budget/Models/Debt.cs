using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace Personal_Budget.Models
{
    public class Debt
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        public DateTime DateofDebt { get; set; }
        public string DebtName { get; set; }
        public double DebtAmount { get; set; }

    }
}
