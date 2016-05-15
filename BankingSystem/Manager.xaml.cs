using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using BankingSystem.Models.Customers;

namespace BankingSystem
{
    /// <summary>
    ///     Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        private readonly string filePath = Environment.CurrentDirectory + @"\" + "Personal_Customers.xml";
        private readonly RegisterPersonalCustomer tmp = new RegisterPersonalCustomer();


        public Manager()
        {
            InitializeComponent();

            DataContext = tmp;
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
                    var deserializer = new XmlSerializer(typeof (ObservableCollection<PersonalCustomer>));
                    var tmpList =
                        (ObservableCollection<PersonalCustomer>) deserializer.Deserialize(sr);
                    foreach (var item in tmpList)
                    {
                        tmp.PersonalCustomers.Add(item);
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
            var RegisterNormal = new RegisterPersonalCustomer();
            RegisterNormal.Show();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            tmp.PersonalCustomers.Clear();
            XmlFiletoList(filePath);
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            PersonalCustomer personalCustomer = (PersonalCustomer) ListView1.SelectedItem;
            var Info = new ShowingInfo();
            Info.DataContext = personalCustomer;
            Info.Show();
            
             //Info.Content = personalCustomer;
        }
    }
}