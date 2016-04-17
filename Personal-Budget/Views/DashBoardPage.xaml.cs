// ************************************************************************
//Personal Finance - App to track your income, expenses and assets.
//Copyright (C) 2016  Jijo Bose

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.
// **************************************************************************


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
            Calculations nnn = new Calculations();

            /// Full Total
            FullTotal.Text = "Total Valuation: " + nnn.FullValuation().ToString();

            /// Calulate Asset value           
            AssetRat.Text = "Assets: " + nnn.AssetCalculation().ToString();

            /// calculate Debt value
            DebtRat.Text = "Debt: " + nnn.DebtCalculation().ToString();

            /// Credit
            CreditSCore.Text = "Credit Ratio: " + nnn.CreditRatio();

            Percent.Text = "Debt : " + nnn.PercentageScore().ToString("0.00") + "%";

          
        }

    }
}
