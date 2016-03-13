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
            conn.DropTable<Transactions>();
            conn.DropTable<Debt>();
            conn.DropTable<Assets>();
            conn.DropTable<Accounts>();
            DeletePopupbar.IsOpen = false;
        }

        private void NoCancel_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            DeletePopupbar.IsOpen = false;
        }
    }
}
