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
using Diplom_41P_SergeevDI.Classes;

namespace Diplom_41P_SergeevDI.Views
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    /// 
    
        
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                employees CurrentUser = BD.Data.employees.FirstOrDefault(x => x.login == txtLogin.Text && x.password == txtPassword.Password);
                if (CurrentUser != null)
                {
                    MessageBox.Show("Вы вошли как обычный пользователь");
                    PageSwitch.Frame.Navigate(new MainPage(CurrentUser));
                }
                else
                {
                    MessageBox.Show("такого пользователя нет");
                }
            }
            catch
            {
                MessageBox.Show("какая-то неизвестная ошибка");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageSwitch.Frame.Navigate(new AddUserPage());
        }
    }
    
}
