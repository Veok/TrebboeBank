using System.Windows;

namespace BankingSystem
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterNormalCustomer_Click(object sender, RoutedEventArgs e)
        {
            var RegisterNormal = new RegisterPersonalCustomer();
            RegisterNormal.Show();
            Close();
        }

        private void RegisterBisnesCustomer_Click(object sender, RoutedEventArgs e)
        {
            var RegisterBisnes = new RegisterBisnesCustomer();
            RegisterBisnes.Show();
            Close();
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            var Manager = new Manager();
            Manager.Show();
            Close();
        }
    }
}