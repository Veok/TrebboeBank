using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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
using System.Xml.Linq;
using System.Xml.Serialization;
using BankingSystem.Customers;

namespace BankingSystem
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        RegisterPersonalCustomer tmp = new RegisterPersonalCustomer();
        string filePath = Environment.CurrentDirectory + @"\" + "Personal_Customers.xml";


        public Manager()
        {
            InitializeComponent();

            this.DataContext = tmp;
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
                    ObservableCollection<PersonalCustomer> tmpList =
                        (ObservableCollection<PersonalCustomer>) deserializer.Deserialize(sr);
                    foreach (var item in tmpList)
                    {

                        tmp.PersonalCustomers.Add(item);
                    }
                }

            }
            catch
            {
                this.Show();
                
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
    }


}

