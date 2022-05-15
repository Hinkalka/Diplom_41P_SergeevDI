using System;
using System.Collections.Generic;
using System.IO;
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
using Diplom_41P_SergeevDI.Classes;

namespace Diplom_41P_SergeevDI.Views
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage(employees CurrentUser)
        {
            InitializeComponent();
            FormatId();
            try
            {
                
                tbV.Text = CurrentUser.name;
                List<employees> LUTT = BD.Data.employees.Where(x => x.id == CurrentUser.id).ToList();
            }
            catch
            {
                MessageBox.Show("информации о вас нет в системе");
            }
        }
        void FormatId()
        {
            var DT = DateTime.Now;
            tbTime.Text = DT.ToString("dddd, dd MMMM yyyy");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageSwitch.Frame.Navigate(new Authorization());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageSwitch.Frame.Navigate(new Phonebook());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PageSwitch.Frame.Navigate(new Chat());
        }
    }
}
