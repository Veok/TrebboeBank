﻿using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using BankingSystem.Models.Accounts;
using BankingSystem.Models.Validators;

namespace BankingSystem
{
    /// <summary>
    ///     Interaction logic for RegisterBisnesCustomer.xaml
    /// </summary>
    public partial class RegisterCompanyAccount
    {
        public RegisterCompanyAccount()
        {
            InitializeComponent();
            CompanyAccounts = new ObservableCollection<CompanyAccount>();

        }
        public ObservableCollection<CompanyAccount> CompanyAccounts { get; set; }


        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            NameBox.Text = string.Empty;
            NipBox.Text = string.Empty;
            EmailBox.Text = string.Empty;
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
            var companyName = NameBox.Text;
            var nip = NipBox.Text;
            var email = EmailBox.Text;
            var street = StreetBox.Text;
            var city = CityBox.Text;
            var country = CountryBox.Text;
            var zipCode = ZipCodeBox.Text;
            var phone = PhoneBox.Text;

            var nameValidator = new NameValidator();
            var nipValidator = new NipValidator();
            var mailValidator = new MailValidator();
            var phoneValidator = new PhoneValidator();

            if (!nameValidator.ValidateName(companyName))
            {
                MessageBox.Show("Podałeś niedozwoloną nazwę firmy");
            }
            else if (!nipValidator.ValidateNip(nip))
            {
                MessageBox.Show("Podałeś nieprawidłowy nip");
            }
            else if (!mailValidator.ValidateMail(email))
            {
                MessageBox.Show("Podałeś nieprawidłowy adres Email");
            }      
            else if (string.IsNullOrEmpty(street) || string.IsNullOrEmpty(zipCode) || string.IsNullOrEmpty(country)
                     || string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Pole adresowe nie może być puste");
            }
            else if (!phoneValidator.ValidatePhoneNumber(phone))
            {
                MessageBox.Show("Nieprawidłowy numer telefonu");
            }
          
            else
            {


                var account = new BankAccount();
                var companyAccount = new CompanyAccount(companyName, nip,  email, zipCode, country,
                    phone, city, street, account)
                {BankAccount = {Balance = 0.0}};
                ;

                var filePath = Environment.CurrentDirectory + @"\" + "Company_Accounts.xml";
                ListToXmlFile(companyAccount, filePath);
                Close();
            }
        }

        private static void ListToXmlFile(CompanyAccount obj, string filePath)
        {
            var xmlser = new XmlSerializer(typeof(ObservableCollection<CompanyAccount>));
            ObservableCollection<CompanyAccount> list;
            try
            {
                using (Stream s = File.OpenRead(filePath))
                {
                    list = xmlser.Deserialize(s) as ObservableCollection<CompanyAccount>;
                }
            }
            catch
            {
                list = new ObservableCollection<CompanyAccount>();
            }
            if (list == null) return;
            {
                list.Add(obj);
                using (Stream s = File.OpenWrite(filePath))
                {
                    xmlser.Serialize(s, list);
                }
            }
        }
    }
}