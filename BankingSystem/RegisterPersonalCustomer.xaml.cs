using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
using System.Xaml;
using BankingSystem.Customers;

using System.Xml.Serialization;

namespace BankingSystem
{
    /// <summary>
    /// Interaction logic for RegisterPersonalCustomer.xaml
    /// </summary>
    public partial class RegisterPersonalCustomer : Window
    {

        public ObservableCollection<PersonalCustomer> PersonalCustomers { get; set; }
        public RegisterPersonalCustomer()
        {
            InitializeComponent();
            PersonalCustomers = new ObservableCollection<PersonalCustomer>();
            this.GenderComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
            this.GenderComboBox.SelectedIndex = 0;

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            this.FirstNameBox.Text = "";
            this.LastNameBox.Text = "";
            this.PeselBox.Text = "";
            this.EmailBox.Text = "";
            this.DoB.Text = "";
            this.StreetBox.Text = "";
            this.CityBox.Text = "";
            this.CountryBox.Text = "";
            this.ZipCodeBox.Text = "";

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

            string FirstName = this.FirstNameBox.Text;
            string LastName = this.LastNameBox.Text;
            string Pesel = this.PeselBox.Text;
            string Email = this.EmailBox.Text;
            string DoB = this.DoB.Text;
            string Street = this.StreetBox.Text;
            string City = this.CityBox.Text;
            string Country = this.CountryBox.Text;
            string ZipCode = this.ZipCodeBox.Text;
            string Phone = this.PhoneBox.Text;

            var Pesel1 = Convert2Long(Pesel);
            Gender gender = (Gender)Enum.Parse(typeof(Gender), this.GenderComboBox.Text);

            PersonalCustomer personalCustomer = new PersonalCustomer(FirstName, LastName, DoB, gender, Pesel1, Email, Street, ZipCode, Country, Phone, City);
            //PersonalCustomers.Add(personalCustomer);

            string filePath = Environment.CurrentDirectory + @"\" + "Personal_Customers.xml";
            ListToXmlFile(personalCustomer, filePath);
            this.Close();

        }
        private void ListToXmlFile(PersonalCustomer obj,string filePath)
        {
           


                XmlSerializer xmlser = new XmlSerializer(typeof(ObservableCollection<PersonalCustomer>));
                ObservableCollection<PersonalCustomer> list = null;
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
                list.Add(obj);
                using (Stream s = File.OpenWrite(filePath))
                {
                    xmlser.Serialize(s, list);
                }

            
        }
        private long Convert2Long(string str1)
        {
            try
            {
                long LngString = Int64.Parse(str1);
                return LngString;
            }
            catch
            {
                MessageBox.Show("Zły format nr Pesel");
                return -1;
            }
        }

    }
}
