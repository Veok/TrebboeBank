using System.Windows;

namespace TrebboeBank
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }


        private void PersonalManager_Click(object sender, RoutedEventArgs e)
        {
            var personalAccounts = new PersonalAccountsManager();
            personalAccounts.Show();
            Close();
        }

        private void CompanyManager_Click(object sender, RoutedEventArgs e)
        {
            var companuAccounts = new CompanyAccountsManager();
            companuAccounts.Show();
            Close();
        }
    }
}