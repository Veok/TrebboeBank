using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using BankingSystem.Models;
using BankingSystem.Models.Customers;

namespace BankingSystem
{
    public partial class RegisterPersonalCustomer
    {
        public RegisterPersonalCustomer()
        {
            InitializeComponent();
            PersonalCustomers = new ObservableCollection<PersonalCustomer>();
            GenderComboBox.ItemsSource = Enum.GetValues(typeof (Gender));
            GenderComboBox.SelectedIndex = 0;
        }

        public ObservableCollection<PersonalCustomer> PersonalCustomers { get; set; }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            FirstNameBox.Text = "";
            LastNameBox.Text = "";
            PeselBox.Text = "";
            EmailBox.Text = "";
            DoB.Text = "";
            StreetBox.Text = "";
            CityBox.Text = "";
            CountryBox.Text = "";
            ZipCodeBox.Text = "";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var firstName = FirstNameBox.Text;
            var lastName = LastNameBox.Text;
            var pesel = PeselBox.Text;
            var email = EmailBox.Text;
            var doB = DoB.Text;
            var street = StreetBox.Text;
            var city = CityBox.Text;
            var country = CountryBox.Text;
            var zipCode = ZipCodeBox.Text;
            var phone = PhoneBox.Text;

            var pesel1 = Convert2Long(pesel);
            var gender = (Gender) Enum.Parse(typeof (Gender), GenderComboBox.Text);
            var account = new BankAccount();
            var personalCustomer = new PersonalCustomer(firstName, lastName, doB, gender, pesel1, email, street, zipCode,
                country, phone, city, account);
            personalCustomer.BankAccount.Balance = 0.0;


            var filePath = Environment.CurrentDirectory + @"\" + "Personal_Customers.xml";
            ListToXmlFile(personalCustomer, filePath);
            Close();
        }

        private void ListToXmlFile(PersonalCustomer obj, string filePath)
        {
            var xmlser = new XmlSerializer(typeof (ObservableCollection<PersonalCustomer>));
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
            list?.Add(obj);
            using (Stream s = File.OpenWrite(filePath))
            {
                xmlser.Serialize(s, list);
            }
        }

        private long Convert2Long(string str1)
        {
            try
            {
                var lngString = long.Parse(str1);
                return lngString;
            }
            catch
            {
                MessageBox.Show("Zły format nr Pesel");
                return -1;
            }
        }
    }
}