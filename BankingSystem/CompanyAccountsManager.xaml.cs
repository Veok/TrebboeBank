using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;
using BankingSystem.Models.Accounts;
using BankingSystem.Models.Operations;

namespace BankingSystem
{
    /// <summary>
    /// Interaction logic for CompanyAccountsManager.xaml
    /// </summary>
    public partial class CompanyAccountsManager : Window
    {
        private string filePath = Environment.CurrentDirectory + @"\" + "Company_Accounts.xml";
        private readonly RegisterCompanyAccount _tmp = new RegisterCompanyAccount();


        public CompanyAccountsManager()
        {
            InitializeComponent();
            DataContext = _tmp;
            XmlFiletoList(filePath);
        }
        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void XmlFiletoList(string filePath)
        {
            try
            {
                using (var sr = new StreamReader(filePath))
                {
                    var deserializer = new XmlSerializer(typeof(ObservableCollection<CompanyAccount>));
                    var tmpList =
                        (ObservableCollection<CompanyAccount>)deserializer.Deserialize(sr);
                    foreach (var item in tmpList)
                    {
                        _tmp.CompanyAccounts.Add(item);
                    }
                }
            }
            catch
            {
                Show();
            }
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            var registerCompany = new RegisterCompanyAccount();
            registerCompany.Show();
        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            var companyAccount1 = ListView1.SelectedIndex;
            DeleteRecord(companyAccount1, filePath);
            _tmp.CompanyAccounts.Clear();
            XmlFiletoList(filePath);

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            _tmp.CompanyAccounts.Clear();
            XmlFiletoList(filePath);
        }

        private void Income_Click(object sender, RoutedEventArgs e)
        {
            var companyAccount = (CompanyAccount)ListView1.SelectedItem;
            var companyAccount2 = ListView1.SelectedIndex;
            ICanSendCash send = new Income();

            var money = Cash.Text;

            try
            {
                var cash = double.Parse(money);
                companyAccount.Amount = cash;
                companyAccount.ApplyIncome(send);
                SaveBalance(filePath, companyAccount, companyAccount2);
                Refresh_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Operacja nieudana");
            }
        }
        private void SaveBalance(string filepath, CompanyAccount companyAccount, int obj)


        {
            var xmlser = new XmlSerializer(typeof(ObservableCollection<CompanyAccount>));
            ObservableCollection<CompanyAccount> list;
            try
            {
                using (Stream s = File.OpenRead(filePath))
                {
                    list = xmlser.Deserialize(s) as ObservableCollection<CompanyAccount>;
                }
            }
            catch
            {
                list = new ObservableCollection<CompanyAccount>();
            }
            if (list == null) return;
            {
                list.RemoveAt(obj);

                list.Insert(obj, companyAccount);
                using (Stream s = File.Create(filepath))
                {
                    xmlser.Serialize(s, list);
                }
            }
        }

        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            var companyAccount = (CompanyAccount)ListView1.SelectedItem;
            var companyAccount2 = ListView1.SelectedIndex;
            ICanSendCash send = new Withdraw();

            var money = Cash.Text;

            try
            {
                var cash = double.Parse(money);
                companyAccount.Amount = cash;
                companyAccount.ApplyIncome(send);
                SaveBalance(filePath, companyAccount, companyAccount2);
                Refresh_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Operacja nieudana");
            }

        }

        private void Personal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void DeleteRecord(int obj, string filePath)
        {
            var xmlser = new XmlSerializer(typeof(ObservableCollection<CompanyAccount>));
            ObservableCollection<CompanyAccount> list;
            try
            {
                using (Stream s = File.OpenRead(filePath))
                {
                    list = xmlser.Deserialize(s) as ObservableCollection<CompanyAccount>;
                }
            }
            catch
            {
                list = new ObservableCollection<CompanyAccount>();
            }

            {
                try
                {
                    list.RemoveAt(obj);
                }
                catch
                {
                    MessageBox.Show("Brak klientów w bazie");
                }
                using (Stream s = File.Create(filePath))
                {
                    xmlser.Serialize(s, list);
                }
            }
        }
    }
}
