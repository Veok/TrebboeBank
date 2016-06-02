using System;
using System.Windows;
using System.Windows.Controls;
using TrebboeBank.Models.Accounts;
using TrebboeBank.Models.Data;
using TrebboeBank.Models.Operations;

namespace TrebboeBank
{
    public partial class CompanyAccountsManager
    {
        private readonly string _filePath = Environment.CurrentDirectory + @"\" + "Company_Accounts.xml";
        private readonly RegisterCompanyAccount _tmp = new RegisterCompanyAccount();


        public CompanyAccountsManager()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DataContext = _tmp;
            XmlFiletoList(_filePath);
        }

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void XmlFiletoList(string filePath)
        {

            var xmlToList = new XmlToList();
            try
            {
                xmlToList.XmlToListCompanyAccounts(filePath, _tmp);
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
            var deleteRecord = new DeleteRecord();
            deleteRecord.DeleteRecordCompanyAccount(companyAccount1, _filePath);
            _tmp.CompanyAccounts.Clear();
            XmlFiletoList(_filePath);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            _tmp.CompanyAccounts.Clear();
            XmlFiletoList(_filePath);
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
                if (cash > 0)
                {
                    companyAccount.Amount = cash;
                    companyAccount.ApplyIncome(send);
                    var saveBalance = new SaveBalance();
                    saveBalance.SaveBalanceCompanyAccounts(_filePath, companyAccount, companyAccount2);
                    Refresh_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Nieprawidłowa kwota");
                }
            }
            catch
            {
                MessageBox.Show("Operacja nieudana");
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
                if (cash > 0)
                {
                    companyAccount.Amount = cash;
                    companyAccount.ApplyIncome(send);
                    var saveBalance = new SaveBalance();
                    saveBalance.SaveBalanceCompanyAccounts(_filePath, companyAccount, companyAccount2);
                    Refresh_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Nieprawidłowa kwota");
                }
            }
            catch
            {
                MessageBox.Show("Operacja nieudana");
            }
        }

        private void Personal_Click(object sender, RoutedEventArgs e)
        {
            var personal = new PersonalAccountsManager();
            personal.Show();
            Close();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}