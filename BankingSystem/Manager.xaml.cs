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
        private readonly RegisterPersonalCustomer _tmp = new RegisterPersonalCustomer();


        public Manager()
        {
            InitializeComponent();

            DataContext = _tmp;
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
                    var deserializer = new XmlSerializer(typeof(ObservableCollection<PersonalCustomer>));
                    var tmpList =
                        (ObservableCollection<PersonalCustomer>)deserializer.Deserialize(sr);
                    foreach (var item in tmpList)
                    {
                        _tmp.PersonalCustomers.Add(item);
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
            var registerNormal = new RegisterPersonalCustomer();
            registerNormal.Show();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            _tmp.PersonalCustomers.Clear();
            XmlFiletoList(_filePath);
        }



        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            int personalCustomer1 = ListView1.SelectedIndex;
            var filePath = Environment.CurrentDirectory + @"\" + "Personal_Customers.xml";
            DeleteRecord(personalCustomer1, filePath);
            _tmp.PersonalCustomers.Clear();
            XmlFiletoList(filePath);
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DeleteRecord(int obj, string filePath)
        {
            var xmlser = new XmlSerializer(typeof(ObservableCollection<PersonalCustomer>));
            ObservableCollection<PersonalCustomer> list;
            try
            {
                using (Stream s = File.OpenRead(filePath))
                {
                    list = xmlser.Deserialize(s) as ObservableCollection<PersonalCustomer>;
                }
            }
            catch
            {
                list = new ObservableCollection<PersonalCustomer>();
            }
            list.RemoveAt(obj);
            using (Stream s = File.Create(filePath))
            {
                xmlser.Serialize(s, list);
            }
        }

        private void Income_Click(object sender, RoutedEventArgs e)
        {
            PersonalCustomer personalCustomer = (PersonalCustomer) ListView1.SelectedItem;
            int personalCustomer2 =  ListView1.SelectedIndex;
             ICanSendCash send = new Income();
            
            var Cash = this.Cash.Text;

            try
            {
               double cash = double.Parse(Cash);
                personalCustomer.Amount = cash;
                personalCustomer.ApplyIncome(send);
                SaveBalance(_filePath, personalCustomer, personalCustomer2);
                Refresh_Click(null, null);

            }
            catch
            {
                MessageBox.Show("Operacja nieudana");
            }
            
            
        }

        private void SaveBalance(string filepath, PersonalCustomer personalCustomer, int obj)


        {
            var xmlser = new XmlSerializer(typeof(ObservableCollection<PersonalCustomer>));
            ObservableCollection<PersonalCustomer> list = null;
            try
            {
                using (Stream s = File.OpenRead(_filePath))
                {
                    list = xmlser.Deserialize(s) as ObservableCollection<PersonalCustomer>;
                }
            }
            catch
            {
                list = new ObservableCollection<PersonalCustomer>();
            }
            list.RemoveAt(obj);

            list.Insert(obj,personalCustomer);
            using (Stream s = File.Create(filepath))
            {
                xmlser.Serialize(s, list);
            }
        }

        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            PersonalCustomer personalCustomer = (PersonalCustomer)ListView1.SelectedItem;
            int personalCustomer2 = ListView1.SelectedIndex;
            ICanSendCash send = new Withdraw();

            var Cash = this.Cash.Text;

            try
            {
                double cash = double.Parse(Cash);
                personalCustomer.Amount = cash;
                personalCustomer.ApplyIncome(send);
                SaveBalance(_filePath, personalCustomer, personalCustomer2);
                Refresh_Click(null, null);

            }
            catch
            {
                MessageBox.Show("Operacja nieudana");
            }
        }
    }
    }
