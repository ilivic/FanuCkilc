using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ckliker
{
    public class ClassSelectData
    {
        public static StaticUser CorrUser { get; set; }
        public static List<StaticUser> ListUser { get; set; }
        public static List<DataIndex> ListIndexer { get; set; }
        public static void SaveUser(int summ)
        {
            StreamWriter writer = new StreamWriter("DataUser.io");
            foreach (var index in ListUser)
            {
                if (index.Name != CorrUser.Name && index.Password != CorrUser.Password && index.Login != CorrUser.Login)
                {
                    writer.Write(index.Name + ";" + index.Login + ";" + index.Password + ";" + index.Role + ";" + index.Summ + ":");
                }
                else
                {
                    writer.Write(index.Name + ";" + index.Login + ";" + index.Password + ";" + index.Role + ";" + summ + ":");
                }
            }
            writer.Close();
        }
        public static void SaveIndex()
        {
            StreamWriter writer = new StreamWriter("Index.io");
            foreach (var index in ListIndexer) 
            {
                writer.Write(index.param+";"+index.IndexerSumm+":");
            }
            writer.Close();
        }
        public static void GetInex()
        {
            ListIndexer = new List<DataIndex>();
            StreamReader reader = new StreamReader(@"Index.io");
            var VAlueAll = reader.ReadToEnd();
            foreach (var index in VAlueAll.Split(':'))
            {
                if (index != "")
                {
                    ListIndexer.Add(new DataIndex()
                    {
                        param = index.Split(';')[0],
                        IndexerSumm = int.Parse(index.Split(';')[1])
                    });
                }
            }
        }
        public static void GetData()
        {
            ListUser = new List<StaticUser>();
            StreamReader reader = new StreamReader(@"DataUser.io");
            var ValueAll = reader.ReadToEnd();
            foreach (var index in ValueAll.Split(':')) 
            {
                if (index != "")
                {

                    ListUser.Add(new StaticUser
                    {
                        Name = index.Split(';')[0],
                        Login = index.Split(';')[1],
                        Password = index.Split(';')[2],
                        Role = index.Split(';')[3],
                        Summ = Convert.ToInt32(index.Split(';')[4]),
                    });
                }
            }
            reader.Close();
        }

    }
    public partial class StaticUser
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Summ { get; set; }
    }
    public partial class DataIndex
    {
        public string param { get; set; }
        public int IndexerSumm { get; set; }

    }
}
