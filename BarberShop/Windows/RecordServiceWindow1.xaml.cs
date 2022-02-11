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
using BarberShop.EF;
using static BarberShop.ClassEntities;

namespace BarberShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для RecordServiceWindow1.xaml
    /// </summary>
    public partial class RecordServiceWindow1 : Window
    {
        public RecordServiceWindow1()
        {
            InitializeComponent();
            
        }

        private void tbFNameRS_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                (
                    textBox.Text.Where(ch => ch == '-' || (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')).ToArray()
                );
            }
        }

    

        private void tbLNameRS_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                (
                    textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')).ToArray()
                );
            }
        }

     

        private void tbTelefRS_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                (
                    textBox.Text.Where(ch => ch == '+' || (ch >= '0' && ch <= '9')).ToArray()
                );
            }
        }

        private void btnAddRS_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();

            if (!string.IsNullOrWhiteSpace(tbFNameRS.Text))
            {
                client.FName = tbFNameRS.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }

            if (!string.IsNullOrWhiteSpace(tbLNameRS.Text))
            {
                client.LName = tbLNameRS.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели фамилию");
                return;
            }

            

            if (!string.IsNullOrWhiteSpace(tbEmailRS.Text))
            {
                client.Email = tbEmailRS.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели почту");
                return;
            }

            

            if (!string.IsNullOrWhiteSpace(tbTelefRS.Text))
            {
                client.Phone = tbTelefRS.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели телефон");
                return;
            }

            

            MessageBox.Show("Пользователь добавлен");
            ClassEntities.context.Client.Add(client);
            try
            {
                ClassEntities.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Hide();
            RecordWindow recordWindow = new RecordWindow();
            recordWindow.ShowDialog();
            this.Close();
        }
    }
    }

