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
using BarberShop.EF;
using BarberShop.Windows;

namespace BarberShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для RecordWindow.xaml
    /// </summary>
    public partial class RecordWindow : Window
    {
        List<EF.Client> listClient = new List<EF.Client>();

        List<string> listForSort = new List<string>()
                {
                "По умолчанию",
                "По фамилии",
                "По имени",
                "По отчеству",
                };
        public RecordWindow()
        {
            InitializeComponent();
            AllClient.ItemsSource = context.Client.ToList();
            cmbSortServ.ItemsSource = listForSort;
            cmbSortServ.SelectedIndex = 0;
            Filter();
        }

        private void Filter()
        {
            listClient = ClassEntities.context.Client.ToList();
            listClient = listClient.
            Where(i => i.LName.Contains(txtSearchServ.Text)
            || i.FName.Contains(txtSearchServ.Text)
            || i.LName.Contains(txtSearchServ.Text)).ToList();

            switch (cmbSortServ.SelectedIndex)
            {
                case 0:
                    listClient = listClient.OrderBy(i => i.ID).ToList();
                    break;

                case 1:
                    listClient = listClient.OrderBy(i => i.LName).ToList();
                    break;

                case 2:
                    listClient = listClient.OrderBy(i => i.FName).ToList();
                    break;

                case 3:
                    listClient = listClient.OrderBy(i => i.LName).ToList();
                    break;

                default:
                    listClient = listClient.OrderBy(i => i.ID).ToList();
                    break;
            }
            if (listClient.Count == 0)
            {
                MessageBox.Show("Записей нет");
            }
            AllClient.ItemsSource = listClient;

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
            RecordServiceWindow1 newRecordServiceWindow1 = new RecordServiceWindow1();
            newRecordServiceWindow1.ShowDialog();
            this.Close();
        }

        private void AllClient_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var resClick = MessageBox.Show("Вы уверены?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                try
                {

                    if (resClick == MessageBoxResult.Yes)
                    {
                        EF.Employee userDel = new EF.Employee();

                        if (!(AllClient.SelectedItem is EF.Employee))
                        {
                            MessageBox.Show("Запись не выбрана");
                            return;
                        }

                        userDel = (AllClient.SelectedItem as EF.Employee);

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

        private void cmbSortServ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txtSearchServ_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
