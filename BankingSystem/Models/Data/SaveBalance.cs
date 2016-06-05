using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using TrebboeBank.Models.Accounts;

namespace TrebboeBank.Models.Data
{
    class SaveBalance
    {

        public void SaveBalacePersonalAccounts(string filepath, PersonalAccount personalAccount, int obj)


        {
            var xmlser = new XmlSerializer(typeof(ObservableCollection<PersonalAccount>));
            ObservableCollection<PersonalAccount> list;
            try
            {
                using (Stream s = File.OpenRead(filepath))
                {
                    list = xmlser.Deserialize(s) as ObservableCollection<PersonalAccount>;
                }
            }
            catch
            {
                list = new ObservableCollection<PersonalAccount>();
            }
            if (list == null) return;
            {
                list.RemoveAt(obj);
                list.Insert(obj, personalAccount);
                using (Stream s = File.Create(filepath))
                {
                    xmlser.Serialize(s, list);
                }
            }
        }


        public void SaveBalanceCompanyAccounts(string filepath, CompanyAccount companyAccount, int obj)


        {
            var xmlser = new XmlSerializer(typeof(ObservableCollection<CompanyAccount>));
            ObservableCollection<CompanyAccount> list;
            try
            {
                using (Stream s = File.OpenRead(filepath))
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

                list.RemoveAt(obj);

                list.Insert(obj, companyAccount);
                using (Stream s = File.Create(filepath))
                {
                    xmlser.Serialize(s, list);
                }
            }
        }
    }
}
