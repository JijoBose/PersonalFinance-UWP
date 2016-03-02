using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace Personal_Budget.Models
{
    public class Calculations
    {
        SQLiteConnection conn; // adding an SQLite connection
        string path = "Findata.sqlite"; // Name of the database must be the same

        public string DebtCalculation()
        {
            /// Initializing a database
            conn = new SQLiteConnection(path);
            // Creating table
            conn.CreateTable<Debt>();

            //// getting values of debt
            string Toto;
            var SumQuery1 = conn.Query<Debt>("SELECT * FROM Debt");
            var sumProdQty1 = SumQuery1.AsEnumerable().Sum(o => o.DebtAmount);
            double SUMOF = sumProdQty1;
            return Toto = SUMOF.ToString();
        }

        public string AssetCalculation()
        {
            conn = new SQLiteConnection(path);
            // Creating table
            conn.CreateTable<Assets>();

            double _tot;
            string tot;
            var SumQuery = conn.Query<Assets>("SELECT * FROM Assets");
            var sumProdQty = SumQuery.AsEnumerable().Sum(o => o.AssetValue);
            _tot = sumProdQty;
            return tot = Convert.ToString(_tot);
        }

        public string IncomeExpenseValues()
        {
            conn = new SQLiteConnection(path);
            // Creating table
            conn.CreateTable<Transactions>();

            //// getting values
            string Toto;
            var SumQuery = conn.Query<Transactions>("SELECT * FROM Transactions");
            var sumProdQty = SumQuery.AsEnumerable().Sum(o => o.Amount);
            return Toto = sumProdQty.ToString();
        }

        public string CreditValuation()
        {
            double Tran = Convert.ToDouble(IncomeExpenseValues());
            double Asset = Convert.ToDouble(AssetCalculation());
            double Debts = Convert.ToDouble(DebtCalculation());

            double Total = Tran + Asset + Debts;
            string _total = Total.ToString();
            return _total;
        }

    }
}
