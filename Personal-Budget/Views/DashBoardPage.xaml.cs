using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLite;
using SQLitePCL;
using Personal_Budget.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Personal_Budget.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DashBoardPage : Page
    {
        SQLiteConnection conn; // adding an SQLite connection
        string path = "Findata.sqlite"; // Name of the database must be the same 

        public DashBoardPage()
        {
            this.InitializeComponent();
            /// Initializing a database
            conn = new SQLiteConnection(path);
            // Creating table
            conn.CreateTable<Transactions>();

            Calculations nnn = new Calculations();

            /// Full Total
            FullTotal.Text = "Total Valuation: " + nnn.CreditValuation().ToString();

            //// getting values of Income and Expense
            Total.Text = "Income and Expense: " + nnn.IncomeExpenseValues().ToString();

            /// Calulate Asset value           
            AssetRat.Text = "Assets: " + nnn.AssetCalculation().ToString();

            /// calculate Debt value
            DebtRat.Text = "Debt: " + nnn.DebtCalculation().ToString();

            /// Credit
            //CreditSCore.Text = nnn.PercentageScore().ToString();
            CreditSCore.Text = nnn.CreditRatio();
            Percent.Text = nnn.PercentageScore().ToString();
          
        }

    }
}
