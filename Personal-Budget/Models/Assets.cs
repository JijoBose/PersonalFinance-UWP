using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace Personal_Budget.Models
{
    public class Assets
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        public string AssetName { get; set; }

        public double AssetValue { get; set; }

    }
}
