using System.Windows;
using BankingSystem.Models.Accounts;

namespace BankingSystem
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
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