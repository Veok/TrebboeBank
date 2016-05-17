using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using BankingSystem.Models.Customers;
using BankingSystem.Models.Operations;

namespace BankingSystem
{
    public partial class Manager
    {
        private readonly string _filePath = Environment.CurrentDirectory + @"\" + "Personal_Customers.xml";
        private readonly RegisterPersonalAccount tmp = new RegisterPersonalAccount();


        public Manager()
        {
            InitializeComponent();

            DataContext = tmp;
            XmlFiletoList(_filePath);
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
                    var deserializer = new XmlSerializer(typeof (ObservableCollection<PersonalAccount>));
                    var tmpList =
                        (ObservableCollection<PersonalAccount>) deserializer.Deserialize(sr);
                    foreach (var item in tmpList)
                    {
                        tmp.PersonalAccounts.Add(item);
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
            var registerNormal = new RegisterPersonalAccount();
            registerNormal.Show();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            tmp.PersonalAccounts.Clear();
            XmlFiletoList(_filePath);
        }


        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            var personalAccount1 = ListView1.SelectedIndex;
            var filePath = Environment.CurrentDirectory + @"\" + "Personal_Customers.xml";
            DeleteRecord(personalAccount1, filePath);
            tmp.PersonalAccounts.Clear();
            XmlFiletoList(filePath);
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DeleteRecord(int obj, string filePath)
        {
            var xmlser = new XmlSerializer(typeof (ObservableCollection<PersonalAccount>));
            ObservableCollection<PersonalAccount> list;
            try
            {
                using (Stream s = File.OpenRead(filePath))
                {
                    list = xmlser.Deserialize(s) as ObservableCollection<PersonalAccount>;
                }
            }
            catch
            {
                list = new ObservableCollection<PersonalAccount>();
            }
            if (list != null)
            {
                list.RemoveAt(obj);
                using (Stream s = File.Create(filePath))
                {
                    xmlser.Serialize(s, list);
                }
            }
        }

        private void Income_Click(object sender, RoutedEventArgs e)
        {
            var personalAccount = (PersonalAccount) ListView1.SelectedItem;
            var personalAccount2 = ListView1.SelectedIndex;
            ICanSendCash send = new Income();

            var money = Cash.Text;

            try
            {
                var cash = double.Parse(money);
                personalAccount.Amount = cash;
                personalAccount.ApplyIncome(send);
                SaveBalance(_filePath, personalAccount, personalAccount2);
                Refresh_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Operacja nieudana");
            }
        }

        private void SaveBalance(string filepath, PersonalAccount personalAccount, int obj)


        {
            var xmlser = new XmlSerializer(typeof (ObservableCollection<PersonalAccount>));
            ObservableCollection<PersonalAccount> list;
            try
            {
                using (Stream s = File.OpenRead(_filePath))
                {
                    list = xmlser.Deserialize(s) as ObservableCollection<PersonalAccount>;
                }
            }
            catch
            {
                list = new ObservableCollection<PersonalAccount>();
            }
            if (list != null)
            {
                list.RemoveAt(obj);

                list.Insert(obj, personalAccount);
                using (Stream s = File.Create(filepath))
                {
                    xmlser.Serialize(s, list);
                }
            }
        }

        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            var personalAccount = (PersonalAccount) ListView1.SelectedItem;
            var personalAccount2 = ListView1.SelectedIndex;
            ICanSendCash send = new Withdraw();

            var money = Cash.Text;

            try
            {
                var cash = double.Parse(money);
                personalAccount.Amount = cash;
                personalAccount.ApplyIncome(send);
                SaveBalance(_filePath, personalAccount, personalAccount2);
                Refresh_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Operacja nieudana");
            }
        }
    }
}