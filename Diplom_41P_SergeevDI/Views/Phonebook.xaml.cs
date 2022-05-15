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

namespace Diplom_41P_SergeevDI.Views
{
    /// <summary>
    /// Логика взаимодействия для Phonebook.xaml
    /// </summary>
    public partial class Phonebook : Page
    {
        public Phonebook()
        {
            InitializeComponent();
            List<employees> s = Classes.BD.Data.employees.ToList();
            LVemplouess.ItemsSource = s;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Classes.PageSwitch.Frame.GoBack();
        }
    }
}
