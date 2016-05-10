using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankingSystem
{
    /// <summary>
    /// Interaction logic for RegisterBisnesCustomer.xaml
    /// </summary>
    public partial class RegisterBisnesCustomer : Window
    {
        public RegisterBisnesCustomer()
        {
            InitializeComponent();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {


            this.NameBox.Text = "";
            this.NipBox.Text = "";
            this.EmailBox.Text = "";
            this.DoR.Text = "";
            this.StreetBox.Text = "";
            this.CityBox.Text = "";
            this.CountryBox.Text = "";
            this.ZipCodeBox.Text = "";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainWindow();
            Main.Show();
            this.Close();
        }
    }
}
