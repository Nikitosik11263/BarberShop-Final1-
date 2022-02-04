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
namespace BarberShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для NewUserWindow1.xaml
    /// </summary>
    public partial class NewUserWindow1 : Window
    {
        public NewUserWindow1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();

            if (!string.IsNullOrWhiteSpace(tbFName.Text))
            {
                employee.FName = tbFName.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }

            if (!string.IsNullOrWhiteSpace(tbLName.Text))
            {
                employee.LName = tbLName.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели фамилию");
                return;
            }

            if (!string.IsNullOrWhiteSpace(tbMName.Text))
            {
                employee.MName = tbMName.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }

            if (!string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                employee.Email = tbEmail.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }

            if (!string.IsNullOrWhiteSpace(tbSeries.Text))
            {
                employee.PassSeries = tbSeries.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }

            if (!string.IsNullOrWhiteSpace(tbNumber.Text))
            {
                employee.PassNum = tbNumber.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }

            if (!string.IsNullOrWhiteSpace(tbTelef.Text))
            {
                employee.Phone = tbTelef.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }

            if (!string.IsNullOrWhiteSpace(tbLog.Text))
            {
                employee.Login = tbLog.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }

            if (!string.IsNullOrWhiteSpace(tbPass.Text))
            {
                employee.Password = tbPass.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }

            MessageBox.Show("Пользователь добавлен");
            context.Employee.Add(employee);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Hide();
            PersonalWindow personalWindow = new PersonalWindow();
            personalWindow.ShowDialog();
            this.Close();
        }

        private void tbTelef_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                (
                    textBox.Text.Where(ch => ch == '+' || (ch >= '0' && ch <= '9')).ToArray()
                );
            }
        }

        private void tbFName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                (
                    textBox.Text.Where(ch => ch == '-' ||(ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch<= 'Z') || (ch >= 'a' && ch <= 'z')).ToArray()
                );
            }
        }

        private void tbLName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                (
                    textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')).ToArray()
                );
            }
        }

        private void tbSeries_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                (
                    textBox.Text.Where(ch =>  (ch >= '0' && ch <= '9')).ToArray()
                );
            }
        }

        private void tbNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                (
                    textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                );
            }

        }
    }
}
