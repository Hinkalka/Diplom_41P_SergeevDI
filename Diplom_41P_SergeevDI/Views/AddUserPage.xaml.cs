using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Diplom_41P_SergeevDI.Classes;
namespace Diplom_41P_SergeevDI.Views
{
    /// <summary>
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            InitializeComponent();
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageSwitch.Frame.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            employees logPass = new employees() {id=+3, name = txtName.Text, surname = txtSurname.Text, patronymic = txtPatronumic.Text, position = txtPosition.Text, phone = txtPhone.Text, image = txtImage.Text, login = txtLogin.Text, password = txtPassword.Text };//создать новую запись
            BD.Data.employees.Add(logPass);

            BD.Data.SaveChanges();//сонхронизировать с сервером
            System.Windows.MessageBox.Show("Данные записаны успешно");//обратная связь с пользователем
        }
    }
}
