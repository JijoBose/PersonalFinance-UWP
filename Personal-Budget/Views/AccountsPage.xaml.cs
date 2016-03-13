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
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Personal_Budget.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountsPage : Page
    {
        SQLiteConnection conn; // adding an SQLite connection
        string path = "Findata.sqlite"; // Name of the database must be unique 

        public AccountsPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            /// Initializing a database
            conn = new SQLiteConnection(path);
            // Creating table
            conn.CreateTable<Accounts>();
            var query = conn.Table<Accounts>();
            TransactionList.ItemsSource = query.ToList();

        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(AccName.Text == null)
                {
                    MessageDialog dialog = new MessageDialog("Amount Name not Entered", "Oops..!");
                    await dialog.ShowAsync();
                }
                else
                {
                    conn.Insert(new Accounts()
                    {
                        AccountName = AccName.Text,
                        InitialAmount = Convert.ToDouble(MoneyIn.Text)
                    });

                    conn.CreateTable<Accounts>();
                    var query = conn.Table<Accounts>();
                    TransactionList.ItemsSource = query.ToList();
                }

            }
            catch (SQLiteException)
            {
                MessageDialog dialog = new MessageDialog("You forgot to enter the Amount or entered an invalid data", "Oops..!");
                await dialog.ShowAsync();
            }

        }

        private async void ClearFileds_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog ClearDialog = new MessageDialog("Cleared", "information");
            await ClearDialog.ShowAsync();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            conn.CreateTable<Accounts>();
            var query = conn.Table<Accounts>();
            TransactionList.ItemsSource = query.ToList();
        }
    }
}
