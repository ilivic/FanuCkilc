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
    /// Логика взаимодействия для PageMenugm.xaml
    /// </summary>
    public partial class PageMenugm : Page
    {
        public PageMenugm()
        {
            InitializeComponent();
            refresh();
        }
        public void refresh()
        {
            ListIndex.ItemsSource = ClassSelectData.ListIndexer.ToList();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Selection = (sender as Button).DataContext as DataIndex;
            NavigationService.Navigate(new PageCheng(Selection));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClassSelectData.SaveIndex();
            NavigationService.GoBack();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataIndex NewData = new DataIndex();
            ClassSelectData.ListIndexer.Add(NewData);
            refresh();
            NavigationService.Navigate(new PageCheng(NewData));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var Selection = (sender as Button).DataContext as DataIndex;
            ClassSelectData.ListIndexer.Remove(Selection);
            refresh();
        }
    }
}
