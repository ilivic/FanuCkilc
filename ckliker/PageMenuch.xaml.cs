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
using System.Windows.Threading;

namespace ckliker
{
    /// <summary>
    /// Логика взаимодействия для PageMenuch.xaml
    /// </summary>
    public partial class PageMenuch : Page
    {
        DispatcherTimer  timer = new DispatcherTimer();
        Boolean indexClic =false;
        public static int allSumm {  get; set; }
        public static int LastSumm {  get; set; }
        public PageMenuch()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(100000);
            timer.Tick += Timer_Tick;
            allSumm = ClassSelectData.CorrUser.Summ;
            TxtViewSumm.Text = allSumm.ToString();
            LastSumm = 0;
            LIstIndexer.ItemsSource = ClassSelectData.ListIndexer.ToList();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            allSumm += LastSumm;
            TxtViewSumm.Text = allSumm.ToString();
            TxtViewSumm.ToolTip = "Прибавленно: " + LastSumm.ToString();
            if (allSumm < 3000000)
            {
                StakAutho.Children.Clear();
                timer.Stop();
            }
        }

        public void AddAutho()
        {

            Button NewButton = new Button();
            NewButton.Content = "Authomate";
            NewButton.Margin = new Thickness(10);
            NewButton.Click += NewButton_Click;
            StakAutho.Children.Add(NewButton);
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            indexClic = !indexClic;
            if (indexClic == false)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LastSumm = ((sender as Button).DataContext as DataIndex).IndexerSumm;
            allSumm += LastSumm;
            TxtViewSumm.Text = allSumm.ToString();
            TxtViewSumm.ToolTip = "Прибавленно: " + LastSumm.ToString();
            if (int.Parse(TxtViewSumm.Text) > 3000000)
            {
                if (StakAutho.Children.Count == 0)
                { 
                    
                AddAutho();
                }
            }
            else
            {
                if (StakAutho.Children.Count != 0)
                {
                    StakAutho.Children.Clear();
                    timer.Stop();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            ClassSelectData.SaveUser(allSumm);
            NavigationService.GoBack();
        }
    }
}
