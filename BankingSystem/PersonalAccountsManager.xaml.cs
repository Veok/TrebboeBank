using System;
using System.Windows;
using System.Windows.Controls;
using TrebboeBank.Models.Accounts;
using TrebboeBank.Models.Data;
using TrebboeBank.Models.Operations;

namespace TrebboeBank
{
    public partial class PersonalAccountsManager
    {
        private readonly string _filePath = Environment.CurrentDirectory + @"\" + "Personal_Accounts.xml";
        private readonly RegisterPersonalAccount _tmp = new RegisterPersonalAccount();


        public PersonalAccountsManager()
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
                xmlToList.XmlToListPersonalAccounts(filePath, _tmp);

            }
            catch
            {
                Show();
            }
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            var registerNormal = new RegisterPersonalAccount();
            registerNormal.Show();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            _tmp.PersonalAccounts.Clear();
            XmlFiletoList(_filePath);
        }


        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            var personalAccount1 = ListView1.SelectedIndex;
            var deleteRecord = new DeleteRecord();
            deleteRecord.DeleteRecordPersonalAccount(personalAccount1, _filePath);
            _tmp.PersonalAccounts.Clear();
            XmlFiletoList(_filePath);
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Income_Click(object sender, RoutedEventArgs e)
        {
            var personalAccount = (PersonalAccount)ListView1.SelectedItem;
            var personalAccount2 = ListView1.SelectedIndex;
            ICanSendCash send = new Income();

            var money = Cash.Text;

            try
            {
                var cash = double.Parse(money);
                if (cash > 0)
                {
                    personalAccount.Amount = cash;
                    personalAccount.ApplyIncome(send);
                    var saveBalance = new SaveBalance();
                    saveBalance.SaveBalacePersonalAccounts(_filePath, personalAccount, personalAccount2);
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
            var personalAccount = (PersonalAccount)ListView1.SelectedItem;
            var personalAccount2 = ListView1.SelectedIndex;
            ICanSendCash send = new Withdraw();

            var money = Cash.Text;

            try
            {
                var cash = double.Parse(money);
                if (cash > 0)
                {
                    personalAccount.Amount = cash;
                    personalAccount.ApplyIncome(send);
                    var saveBalance = new SaveBalance();
                    saveBalance.SaveBalacePersonalAccounts(_filePath, personalAccount, personalAccount2);
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

        private void Company_Click(object sender, RoutedEventArgs e)
        {
            var company = new CompanyAccountsManager();
            company.Show();
            Close();
        }
    }
}