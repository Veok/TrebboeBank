using System.Windows;

namespace BankingSystem
{
    /// <summary>
    ///     Interaction logic for RegisterBisnesCustomer.xaml
    /// </summary>
    public partial class RegisterBisnesCustomer : Window
    {
        public RegisterBisnesCustomer()
        {
            InitializeComponent();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            NameBox.Text = "";
            NipBox.Text = "";
            EmailBox.Text = "";
            DoR.Text = "";
            StreetBox.Text = "";
            CityBox.Text = "";
            CountryBox.Text = "";
            ZipCodeBox.Text = "";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainWindow();
            Main.Show();
            Close();
        }
    }
}