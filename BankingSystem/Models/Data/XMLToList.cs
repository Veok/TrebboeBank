using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using TrebboeBank.Models.Accounts;

namespace TrebboeBank.Models.Data
{
    class XmlToList
    {

        public void XmlToListPersonalAccounts(string filepath, RegisterPersonalAccount tmp)
        {
            using (var sr = new StreamReader(filepath))
            {
                var deserializer = new XmlSerializer(typeof(ObservableCollection<PersonalAccount>));
                var tmpList =
                    (ObservableCollection<PersonalAccount>)deserializer.Deserialize(sr);
                foreach (var item in tmpList)
                {

                    /* Wypisanie rekordów do listy */
                    tmp.PersonalAccounts.Add(item);
                }
            }
        }

        public void XmlToListCompanyAccounts(string filePath, RegisterCompanyAccount tmp)
        {
            using (var sr = new StreamReader(filePath))
            {
                var deserializer = new XmlSerializer(typeof(ObservableCollection<CompanyAccount>));
                var tmpList =
                    (ObservableCollection<CompanyAccount>)deserializer.Deserialize(sr);
                foreach (var item in tmpList)
                {
                    /* Wypisanie rekordów do listy */

                    tmp.CompanyAccounts.Add(item);
                }
            }
        }
    }
}
