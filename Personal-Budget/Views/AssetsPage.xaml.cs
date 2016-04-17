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
using Personal_Budget.ViewModels;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Personal_Budget.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AssetsPage : Page
    {
        SQLiteConnection conn; // adding an SQLite connection
        string path = "Findata.sqlite"; // Name of the database must be unique 

        public AssetsPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            /// Initializing a database
            conn = new SQLiteConnection(path);
            // Creating table
            conn.CreateTable<Assets>();

            /// Refresh Data
            var query = conn.Table<Assets>();
            AssetListView.ItemsSource = query.ToList();

        }

        private async void AddData(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Insert(new Assets()
                {
                    AssetName = AssetNameText.Text,
                    AssetValue = Convert.ToDouble(AssetValue.Text)
                });

                var query = conn.Table<Assets>();
                AssetListView.ItemsSource = query.ToList();
            }
            catch (FormatException)
            {
                MessageDialog dialog = new MessageDialog("You forgot to enter the Value or entered an invalid data", "Oops..!");
                await dialog.ShowAsync();
            }

        }

        //private void RefreshList_Click(object sender, RoutedEventArgs e)
        //{
        //    conn.CreateTable<Assets>();
        //    var query = conn.Table<Assets>();
        //    AssetListView.ItemsSource = query.ToList();
        //}

        private async void ClearFileds_Click(object sender, RoutedEventArgs e)
        {
            AssetNameText.Text = string.Empty;
            AssetValue.Text = string.Empty;

            MessageDialog ClearDialog = new MessageDialog("Cleared", "information");
            await ClearDialog.ShowAsync();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            conn.CreateTable<Assets>();
            /// Refresh Data
            var query = conn.Table<Assets>();
            AssetListView.ItemsSource = query.ToList();
        }
    }
}
