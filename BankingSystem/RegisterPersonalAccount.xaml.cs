using System;
using System.Collections.ObjectModel;
using System.Windows;
using TrebboeBank.Models.Accounts;
using TrebboeBank.Models.Data;
using TrebboeBank.Models.Validators;

namespace TrebboeBank
{
    public partial class RegisterPersonalAccount
    {

        /** Numer telofonu powinien się zaczynać od "+"
         * By stworzyć konto trzeba podać prawdziwy numer pesel oraz date urodzenia powyżej 18 roku życia
         * Email powinien zawierać "@" */

        public RegisterPersonalAccount()
        {
            InitializeComponent();
            PersonalAccounts = new ObservableCollection<PersonalAccount>();
            GenderComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
            GenderComboBox.SelectedIndex = 0;
        }

        public ObservableCollection<PersonalAccount> PersonalAccounts { get; set; }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            FirstNameBox.Text = string.Empty;
            LastNameBox.Text = string.Empty;
            PeselBox.Text = string.Empty;
            EmailBox.Text = string.Empty;
            DoB.Text = string.Empty;
            StreetBox.Text = string.Empty;
            CityBox.Text = string.Empty;
            CountryBox.Text = string.Empty;
            ZipCodeBox.Text = string.Empty;
            PhoneBox.Text = string.Empty;
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


            var nameValidator = new NameValidator();
            var mailValidator = new MailValidator();
            var peselValidator = new PeselValidator();
            var dobValidator = new DateOfBirthValidator();
            var phoneValidator = new PhoneValidator();

            if (!nameValidator.ValidateName(firstName))
            {
                MessageBox.Show("Podałeś nieprawidłowę imię.");
            }
            else if (!nameValidator.ValidateName(lastName))
            {
                MessageBox.Show("Podałeś nieprawidłowe nazwisko");
            }
            else if (!peselValidator.ValidatePesel(pesel))
            {
                MessageBox.Show("Podałeś nieprawidłowy numer PESEL");
            }
            else if (!mailValidator.ValidateMail(email))
            {
                MessageBox.Show("Podałeś nieprawidłowy adres Email");
            }
            else if (!phoneValidator.ValidatePhoneNumber(phone))
            {
                MessageBox.Show("Nieprawidłowy numer telefonu");
            }

            else if (!dobValidator.ValidateDoB(doB))
            {
                MessageBox.Show("Nieprawidłowa data urodzenia");
            }
            else if (string.IsNullOrEmpty(street) || string.IsNullOrEmpty(zipCode) || string.IsNullOrEmpty(country)
                     || string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Pole adresowe nie może być puste");
            }


            else
            {
                var gender = (Gender)Enum.Parse(typeof(Gender), GenderComboBox.Text);
                var account = new BankAccount();
                var personalAccount = new PersonalAccount(firstName, lastName, doB, gender, pesel, email, street,
                    zipCode,
                    country, phone, city, account)
                { BankAccount = { Balance = 0.0 } };

                var filePath = Environment.CurrentDirectory + @"\" + "Personal_Accounts.xml";
                var listToXml = new ListToXml();
                listToXml.PersonalAccounts(personalAccount, filePath);

                Close();
            }
        }


    }
}