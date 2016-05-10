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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
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
            this.Close();
        }

        private void RegisterBisnesCustomer_Click(object sender, RoutedEventArgs e)
        {
            var RegisterBisnes = new RegisterBisnesCustomer();
            RegisterBisnes.Show();
            this.Close();
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            var Manager = new Manager();
            Manager.Show();
            this.Close();
        }
    }
}
