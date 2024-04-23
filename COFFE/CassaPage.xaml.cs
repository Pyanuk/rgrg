using Microsoft.Win32;
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

namespace COFFE
{

    public partial class CassaPage : Page
    {
        Coffee_EmbrasureEntities con = new Coffee_EmbrasureEntities();
        int totalAmount = 0;
        private int receiptIDCounter = 1;
        public CassaPage()
        {
            InitializeComponent();
            LoadData();
            LoadReceiptIDCounter();
        }

        private void LoadReceiptIDCounter()
        {

            if (File.Exists("Квитанция.txt"))
            {
                string savedCounter = File.ReadAllText("Квитанция.txt");
                receiptIDCounter = int.Parse(savedCounter);
            }
        }

        private void SaveReceiptIDCounter()
        {

            File.WriteAllText("Квитанция.txt", receiptIDCounter.ToString());
        }

        private void LoadData()
        {
            CoffeDatagrid.ItemsSource = con.Type_Coffee.ToList();
            ProductsDatagrid.ItemsSource = con.Products.ToList();   
        }

        private void CoffeDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CoffeDatagrid.SelectedItem != null)
            {
                var selectedCoffee = CoffeDatagrid.SelectedItem as Type_Coffee;
                AddToCartListBox(selectedCoffee.Type_Coffee_Name, (int)selectedCoffee.PRICE_Type_Coffee);
            }
            else
            {
                CartListBox.Items.Clear(); 
            }
        }

        private void ProductsDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsDatagrid.SelectedItem != null)
            {
                var selectedProduct = ProductsDatagrid.SelectedItem as Products;
                AddToCartListBox(selectedProduct.ProductName, (int)selectedProduct.Price);
            }
            else
            {
                CartListBox.Items.Clear(); 
            }
        }

        private void AddToCartListBox(string name, int price)
        {
            ListBoxItem item = new ListBoxItem();
            item.Content = $"{name} - {price}";
            CartListBox.Items.Add(item);

            totalAmount += price;
            TotalAmountTextBox.Text = totalAmount.ToString();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CartListBox.SelectedItem != null)
            {

                string itemInfo = (CartListBox.SelectedItem as ListBoxItem).Content.ToString();
                string[] parts = itemInfo.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                int itemPrice = int.Parse(parts[1]);
                CartListBox.Items.Remove(CartListBox.SelectedItem);
                totalAmount -= itemPrice;
                TotalAmountTextBox.Text = totalAmount.ToString();
            }
        }

        private int GetNextReceiptID()
        {
            return receiptIDCounter++;
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(PaidAmountTextBox.Text, out int paidAmount))
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (paidAmount < totalAmount)
            {
                MessageBox.Show("Внесенная сумма меньше общей суммы к оплате.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            StringBuilder receipt = new StringBuilder();
            int change = paidAmount - totalAmount;

            receipt.AppendLine("COFFE");
            receipt.AppendLine($"Кассовый чек №{GetNextReceiptID()}");


            foreach (ListBoxItem item in CartListBox.Items)
            {
                string itemInfo = item.Content.ToString();
                string[] parts = itemInfo.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                string itemName = parts[0];
                int itemPrice = int.Parse(parts[1]);

                receipt.AppendLine($"{itemName} - {itemPrice}");
            }

            receipt.AppendLine($"\nИтого к оплате: {totalAmount}");
            receipt.AppendLine($"Внесено: {paidAmount}");
            receipt.AppendLine($"Сдача: {change}");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FileName = "Чек.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    sw.Write(receipt.ToString());
                }
                MessageBox.Show("Чек сохранен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            MessageBox.Show(receipt.ToString(), "Чек", MessageBoxButton.OK);

            SaveReceiptIDCounter();
        }

    }
}
