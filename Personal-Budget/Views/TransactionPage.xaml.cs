﻿// ************************************************************************
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
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Personal_Budget.Models;
using Personal_Budget.ViewModels;
using SQLite;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Personal_Budget.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TransactionPage : Page
    {
        SQLiteConnection conn; // adding an SQLite connection
        string path = "Findata.sqlite"; // Name of the database must be unique 

        public TransactionPage()
        {
            this.InitializeComponent();

            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            /// Initializing a database
            conn = new SQLiteConnection(path);
            // Creating table
            conn.CreateTable<Transactions>();
            DateStamp.Date = DateTime.Now; // gets current date and time
            //DateStamp1.Date = DateTime.Now;

            //var query = conn.Table<Transactions>();
            //TransactionList.ItemsSource = query.ToList();

            conn.CreateTable<Accounts>();
            var query1 = conn.Table<Accounts>();
            AccountsListSel.ItemsSource = query1.ToList();
            //FromAccount.ItemsSource = query1.ToList();
            //ToAccount.ItemsSource = query1.ToList();


        }

        private async void AddData(object sender, RoutedEventArgs e)
        {
            string AccountSelection = ((Accounts)AccountsListSel.SelectedItem).AccountName;
            /// inserts the data if money value is null
            try
            {
                //// detects if income 
                if (IncExpSelect.SelectionBoxItem.ToString() == "Income")
                {
                    conn.Insert(new Transactions()
                    {
                        DateOfTran = DateStamp.Date.Value.DateTime,
                        TranType = IncExpSelect.SelectionBoxItem.ToString(),
                        Description = Desc.Text,
                        Account = AccountSelection,
                        Amount = Convert.ToDouble(MoneyIn.Text)
                    });

                    var query3 = conn.Query<Accounts>("UPDATE Accounts SET InitialAmount = " + TransactionToAccountIncome() + " WHERE AccountName ='" + AccountSelection + "'");

                    //conn.CreateTable<Transactions>();
                    //var query = conn.Table<Transactions>();
                    //TransactionList.ItemsSource = query.ToList();
                }
                else /// detects if expense
                {
                    double EMoney = Convert.ToDouble(MoneyIn.Text);
                    double FMoney = 0 - EMoney;
                    conn.Insert(new Transactions()
                    {
                        DateOfTran = DateStamp.Date.Value.DateTime,
                        TranType = IncExpSelect.SelectionBoxItem.ToString(),
                        Description = Desc.Text,
                        Account = AccountSelection,
                        Amount = FMoney
                    });

                    double Exp = FMoney + TransactionToExpense();
                    var query3 = conn.Query<Accounts>("UPDATE Accounts SET InitialAmount = " + Exp + " WHERE AccountName ='" + AccountSelection + "'");
                    //conn.CreateTable<Transactions>();
                    //var query = conn.Table<Transactions>();
                    //TransactionList.ItemsSource = query.ToList();
                }
            }
            catch (FormatException)
            {
                MessageDialog dialog = new MessageDialog("You forgot to enter the Amount or entered an invalid data", "Oops..!");
                await dialog.ShowAsync();
            }

        }

        public double TransactionToAccountIncome()
        {
            string AccountSelection = ((Accounts)AccountsListSel.SelectedItem).AccountName;

            conn.CreateTable<Accounts>();
            var query1 = conn.Query<Accounts>("SELECT * FROM Accounts WHERE AccountName ='" + AccountSelection + "'");
            var sumProdQty1 = query1.AsEnumerable().Sum(o => o.InitialAmount);

            conn.CreateTable<Transactions>();
            var query2 = conn.Query<Transactions>("SELECT * FROM Transactions WHERE Account = '" + AccountSelection + "'");
            var sumProdQty2 = query2.AsEnumerable().Sum(o => o.Amount);

            double FinalAmountShip = sumProdQty1 + sumProdQty2;

            return FinalAmountShip;
        }

        public double TransactionToExpense()
        {
            string AccountSelection = ((Accounts)AccountsListSel.SelectedItem).AccountName;

            conn.CreateTable<Accounts>();
            var query1 = conn.Query<Accounts>("SELECT * FROM Accounts WHERE AccountName ='" + AccountSelection + "'");
            var sumProdQty1 = query1.AsEnumerable().Sum(o => o.InitialAmount);
            double FinalTot = sumProdQty1;
            return FinalTot;
        }
    }
}
