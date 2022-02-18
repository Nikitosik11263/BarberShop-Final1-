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
using System.Windows.Shapes;
using static BarberShop.ClassEntities;
using BarberShop.Windows;

namespace BarberShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для PersonalWindow.xaml
    /// </summary>
    /// 

    //  List<string> ListForSort = new List<string>()
    // {
    //   "По умолчанию",
    // "По Фамилии",
    //"По Имени"
    //};
    public partial class PersonalWindow : Window
    {
        List<EF.Employee> listEmployee = new List<EF.Employee>();

        List<string> listForSort = new List<string>()
                {
                "По умолчанию",
                "По фамилии",
                "По имени",
                "По отчеству",
                };

   

        public PersonalWindow()
        {
            InitializeComponent();
            AllPersonalTwo.ItemsSource = context.Employee.ToList();
            cmbSort.ItemsSource = listForSort;
            cmbSort.SelectedIndex = 0;
            Filter();
        }

        private void Filter()
        {
            listEmployee = ClassEntities.context.Employee.ToList();
            listEmployee = listEmployee.
            Where(i => i.LName.Contains(txtSearch.Text)
            || i.FName.Contains(txtSearch.Text)
            || i.MName.Contains(txtSearch.Text)).ToList();

            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    listEmployee = listEmployee.OrderBy(i => i.ID).ToList();
                    break;

                case 1:
                    listEmployee = listEmployee.OrderBy(i => i.LName).ToList();
                    break;

                case 2:
                    listEmployee = listEmployee.OrderBy(i => i.FName).ToList();
                    break;

                case 3:
                    listEmployee = listEmployee.OrderBy(i => i.MName).ToList();
                    break;

                default:
                    listEmployee = listEmployee.OrderBy(i => i.ID).ToList();
                    break;
            }
            if (listEmployee.Count == 0)
            {
                MessageBox.Show("Записей нет");
            }
           AllPersonalTwo.ItemsSource = listEmployee;

        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            NewUserWindow1 newUserWindow1 = new NewUserWindow1();
            newUserWindow1.ShowDialog();
            this.Close();
        }

        private void AllPersonal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var resClick = MessageBox.Show("Вы уверены?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                try
                {

                    if (resClick == MessageBoxResult.Yes)
                    {
                        EF.Employee userDel = new EF.Employee();

                        if (!(AllPersonalTwo.SelectedItem is EF.Employee))
                        {
                            MessageBox.Show("Запись не выбрана");
                            return;
                        }

                        userDel = (AllPersonalTwo.SelectedItem as EF.Employee);

                        //MessageBox.Show(userDel.LName);
                        ClassEntities.context.Employee.Remove(userDel);
                        ClassEntities.context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
