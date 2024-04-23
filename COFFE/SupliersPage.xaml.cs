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
using System.Text.RegularExpressions;

namespace COFFE
{

    public partial class SupliersPage : Page
    {
        private Coffee_EmbrasureEntities con = new Coffee_EmbrasureEntities();

        public SupliersPage()
        {
            InitializeComponent();
            SupliersDatagrid.ItemsSource = con.Suppliers.ToList();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CompanyTextBox.Text) || string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(NomerTextBox.Text) || string.IsNullOrWhiteSpace(AdresTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            if (!IsLettersOnly(CompanyTextBox.Text) || !IsLettersOnly(NameTextBox.Text))
            {
                MessageBox.Show("Название компании и имя должны содержать только буквы.");
                return;
            }

            if (!IsPhoneNumberValid(NomerTextBox.Text))
            {
                MessageBox.Show("Номер телефона должен содержать только цифры и иметь длину 12 символов.");
                return;
            }

            if (!IsEmailValid(EmailTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите корректный адрес электронной почты.");
                return;
            }

            if (!IsAddressValid(AdresTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите корректный адрес.");
                return;
            }

            Suppliers suppliers = new Suppliers();
            suppliers.CompanyName = CompanyTextBox.Text.Length > 20 ? CompanyTextBox.Text.Substring(0, 20) : CompanyTextBox.Text;
            suppliers.ContactName = NameTextBox.Text.Length > 20 ? NameTextBox.Text.Substring(0, 20) : NameTextBox.Text;
            suppliers.Phone = NomerTextBox.Text.Length > 20 ? NomerTextBox.Text.Substring(0, 20) : NomerTextBox.Text;
            suppliers.Email = EmailTextBox.Text.Length > 20 ? EmailTextBox.Text.Substring(0, 20) : EmailTextBox.Text;
            suppliers.ADDRESS_Suppliers = AdresTextBox.Text.Length > 20 ? AdresTextBox.Text.Substring(0, 20) : AdresTextBox.Text;

            con.Suppliers.Add(suppliers);
            con.SaveChanges();
            SupliersDatagrid.ItemsSource = con.Suppliers.ToList();
        }

        private bool IsLettersOnly(string input)
        {
            Regex regex = new Regex("^[A-Za-zА-Яа-я\\s]+$");
            return !string.IsNullOrWhiteSpace(input) && regex.IsMatch(input);
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            Regex regex = new Regex("^[0-9]{11}$");
            return regex.IsMatch(phoneNumber);
        }

        private bool IsEmailValid(string email)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
            return regex.IsMatch(email);
        }

        private bool IsAddressValid(string address)
        {
            Regex regex = new Regex(@"^[a-zA-Zа-яА-Я0-9\s.,]{1,20}$");
            return regex.IsMatch(address);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (SupliersDatagrid.SelectedItems != null)
            {
                foreach (var selectedItem in SupliersDatagrid.SelectedItems)
                {
                    Suppliers suppliers = selectedItem as Suppliers;
                    if (suppliers != null)
                    {
                        con.Suppliers.Remove(suppliers);
                    }
                }
                con.SaveChanges();
                SupliersDatagrid.ItemsSource = con.Suppliers.ToList();
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            if (SupliersDatagrid.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(CompanyTextBox.Text) || string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(NomerTextBox.Text) || string.IsNullOrWhiteSpace(AdresTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                    return;
                }

                if (!IsLettersOnly(CompanyTextBox.Text) || !IsLettersOnly(NameTextBox.Text))
                {
                    MessageBox.Show("Название компании и имя должны содержать только буквы.");
                    return;
                }

                if (!IsPhoneNumberValid(NomerTextBox.Text))
                {
                    MessageBox.Show("Номер телефона должен содержать только цифры и иметь длину 12 символов.");
                    return;
                }

                if (!IsEmailValid(EmailTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите корректный адрес электронной почты.");
                    return;
                }

                if (!IsAddressValid(AdresTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите корректный адрес.");
                    return;
                }

                Suppliers suppliers = SupliersDatagrid.SelectedItem as Suppliers;
                suppliers.CompanyName = CompanyTextBox.Text.Length > 20 ? CompanyTextBox.Text.Substring(0, 20) : CompanyTextBox.Text;
                suppliers.ContactName = NameTextBox.Text.Length > 20 ? NameTextBox.Text.Substring(0, 20) : NameTextBox.Text;
                suppliers.Phone = NomerTextBox.Text.Length > 20 ? NomerTextBox.Text.Substring(0, 20) : NomerTextBox.Text;
                suppliers.Email = EmailTextBox.Text.Length > 20 ? EmailTextBox.Text.Substring(0, 20) : EmailTextBox.Text;
                suppliers.ADDRESS_Suppliers = AdresTextBox.Text.Length > 20 ? AdresTextBox.Text.Substring(0, 20) : AdresTextBox.Text;
                con.SaveChanges();
                SupliersDatagrid.ItemsSource = con.Suppliers.ToList();
            }
        }

        private void SupliersDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SupliersDatagrid.SelectedItem != null)
            {
                Suppliers selectedSupplier = SupliersDatagrid.SelectedItem as Suppliers;
                CompanyTextBox.Text = selectedSupplier.CompanyName;
                NameTextBox.Text = selectedSupplier.ContactName;
                NomerTextBox.Text = selectedSupplier.Phone;
                EmailTextBox.Text = selectedSupplier.Email;
                AdresTextBox.Text = selectedSupplier.ADDRESS_Suppliers;
            }
        }

    }

}
