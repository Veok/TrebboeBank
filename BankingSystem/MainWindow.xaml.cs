using System.Windows;

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


        private void RegisterBisnesCustomer_Click(object sender, RoutedEventArgs e)
        {
            var registerBisnes = new RegisterBisnesCustomer();
            registerBisnes.Show();
            Close();
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            var manager = new Manager();
            manager.Show();
            Close();
        }
    }
}