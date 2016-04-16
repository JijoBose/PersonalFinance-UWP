//Personal Finance App to manage your income and expenses.
//Copyright(C) 2016  Jijo Bose

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU Affero General Public License as published
//by the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//GNU Affero General Public License for more details.

//You should have received a copy of the GNU Affero General Public License
//along with this program.If not, see<http://www.gnu.org/licenses/>.

using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using SQLite;
using SQLitePCL;
using Personal_Budget.Models;
using Windows.UI.Popups;

namespace Personal_Budget.Views
{
    public sealed partial class SettingsPage : Page
    {

        SQLiteConnection conn; // adding an SQLite connection
        string path = "Findata.sqlite"; // Name of the database must be unique 

        Template10.Services.SerializationService.ISerializationService _SerializationService;

        public SettingsPage()
        {
            InitializeComponent();
            _SerializationService = Template10.Services.SerializationService.SerializationService.Json;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var index = int.Parse(_SerializationService.Deserialize(e.Parameter?.ToString()).ToString());
            MyPivot.SelectedIndex = index;
        }

        private void ResetButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            DeletePopupbar.IsOpen = true;
        }

        private void YesDelete_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            conn = new SQLiteConnection(path);
            /// deleteing table
            conn.DropTable<Accounts>();
            conn.DropTable<Transactions>();
            conn.DropTable<Debt>();
            conn.DropTable<Assets>();
            DeletePopupbar.IsOpen = false;
        }

        private void NoCancel_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            DeletePopupbar.IsOpen = false;
        }
    }
}
