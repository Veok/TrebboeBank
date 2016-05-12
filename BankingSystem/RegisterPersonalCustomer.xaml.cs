using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using BankingSystem.Models;
using BankingSystem.Models.Customers;

namespace BankingSystem
{
    /// <summary>
    ///     Interaction logic for RegisterPersonalCustomer.xaml
    /// </summary>
    public partial class RegisterPersonalCustomer : Window
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
            var main = new MainWindow();
            main.Show();
            Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var FirstName = FirstNameBox.Text;
            var LastName = LastNameBox.Text;
            var Pesel = PeselBox.Text;
            var Email = EmailBox.Text;
            var DoB = this.DoB.Text;
            var Street = StreetBox.Text;
            var City = CityBox.Text;
            var Country = CountryBox.Text;
            var ZipCode = ZipCodeBox.Text;
            var Phone = PhoneBox.Text;

            var Pesel1 = Convert2Long(Pesel);
            var gender = (Gender) Enum.Parse(typeof (Gender), GenderComboBox.Text);
          BankAccount account = new BankAccount();
            var personalCustomer = new PersonalCustomer(FirstName, LastName, DoB, gender, Pesel1, Email, Street, ZipCode,
                Country, Phone, City, account);
            //PersonalCustomers.Add(personalCustomer);

            var filePath = Environment.CurrentDirectory + @"\" + "Personal_Customers.xml";
            ListToXmlFile(personalCustomer, filePath);
            Close();
        }

        private void ListToXmlFile(PersonalCustomer obj, string filePath)
        {
            var xmlser = new XmlSerializer(typeof (ObservableCollection<PersonalCustomer>));
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
                var LngString = long.Parse(str1);
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