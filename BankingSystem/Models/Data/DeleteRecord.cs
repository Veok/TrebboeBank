using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using TrebboeBank.Models.Accounts;

namespace TrebboeBank.Models.Data
{




    class DeleteRecord
    {
        public void DeleteRecordPersonalAccount(int obj, string filePath)
        {
            var xmlser = new XmlSerializer(typeof(ObservableCollection<PersonalAccount>));
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

            {
                try
                {
                    list.RemoveAt(obj);
                }
                catch
                {
                    MessageBox.Show("Nie można wykonać operacji");
                }
                using (Stream s = File.Create(filePath))
                {
                    xmlser.Serialize(s, list);
                }
            }
        }


        public void DeleteRecordCompanyAccount(int obj, string filePath)
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

            {
                try
                {
                    list.RemoveAt(obj);
                }
                catch
                {
                    MessageBox.Show("Nie można wykonać operacji");
                }
                using (Stream s = File.Create(filePath))
                {
                    xmlser.Serialize(s, list);
                }
            }
        }
    }
}
