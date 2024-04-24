using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ckliker
{
    /// <summary>
    /// Логика взаимодействия для PageAutho.xaml
    /// </summary>
    public partial class PageAutho : Page
    {
        public PageAutho()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassSelectData.GetData();
            var DataUser = ClassSelectData.ListUser.Where(z=>z.Login == TxtLogin.Text && z.Password==TxtPassword.Password).FirstOrDefault();
            if (DataUser != null)
            {
                ClassSelectData.GetInex();
                ClassSelectData.CorrUser = DataUser;
                if (DataUser.Role == "Admin")
                {
                    NavigationService.Navigate(new PageMenugm());
                }
                else 
                {
                    NavigationService.Navigate(new PageMenuch());
                }
            }
        }
    }
}
