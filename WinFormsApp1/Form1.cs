using System.Text.Json;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Product> products;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "products.json");
                
                if (!File.Exists(jsonPath))
                {
                    MessageBox.Show("Файл products.json не знайдено!", "Помилка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string jsonContent = File.ReadAllText(jsonPath);
                products = JsonSerializer.Deserialize<List<Product>>(jsonContent);

                if (products != null)
                {
                    foreach (var product in products)
                    {
                        checkedListBoxProducts.Items.Add($"{product.Name} - {product.Price:F2} ₴ ({product.Category})");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження товарів: {ex.Message}", "Помилка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAddToCart_Click(object sender, EventArgs e)
        {
            if (checkedListBoxProducts.CheckedItems.Count == 0)
            {
                MessageBox.Show("Будь ласка, оберіть товари для додавання до кошика!", 
                    "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridViewCart.Rows.Clear();

            foreach (var checkedItem in checkedListBoxProducts.CheckedItems)
            {
                int index = checkedListBoxProducts.Items.IndexOf(checkedItem);
                var product = products[index];

                // Перевіряємо чи товар вже є в кошику
                bool exists = false;
                foreach (DataGridViewRow row in dataGridViewCart.Rows)
                {
                    if (row.Cells[0].Value?.ToString() == product.Name)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    dataGridViewCart.Rows.Add(product.Name, product.Price.ToString("F2"), "1");
                }
            }

            CalculateTotal();
        }

        private void DataGridViewCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2) // Колонка "Кількість"
            {
                var cell = dataGridViewCart.Rows[e.RowIndex].Cells[e.ColumnIndex];
                
                if (cell.Value != null)
                {
                    string value = cell.Value.ToString();
                    
                    // Перевірка на коректність введення
                    if (!int.TryParse(value, out int quantity) || quantity < 0)
                    {
                        MessageBox.Show("Будь ласка, введіть коректну кількість (ціле невід'ємне число)!", 
                            "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cell.Value = "1";
                    }
                    else if (quantity == 0)
                    {
                        // Видаляємо товар якщо кількість 0
                        dataGridViewCart.Rows.RemoveAt(e.RowIndex);
                    }
                }

                CalculateTotal();
            }
        }

        private void CalculateTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[2].Value != null)
                {
                    decimal price = decimal.Parse(row.Cells[1].Value.ToString());
                    int quantity = int.Parse(row.Cells[2].Value.ToString());
                    total += price * quantity;
                }
            }

            labelTotalAmount.Text = $"{total:F2} ₴";
        }

        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.Rows.Count == 0)
            {
                MessageBox.Show("Кошик порожній! Додайте товари перед перетворенням.", 
                    "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = decimal.Parse(labelTotalAmount.Text.Replace(" ₴", ""));
            string amountInWords = NumberToWordsUA.Convert(total);
            labelAmountInWords.Text = amountInWords;
        }

        private void ButtonSaveReceipt_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.Rows.Count == 0)
            {
                MessageBox.Show("Кошик порожній! Додайте товари перед збереженням чека.", 
                    "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                FileName = $"Чек_{DateTime.Now:yyyyMMdd_HHmmss}.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine("═══════════════════════════════════════════");
                        writer.WriteLine("              КАСОВИЙ ЧЕК");
                        writer.WriteLine("═══════════════════════════════════════════");
                        writer.WriteLine($"Дата: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                        writer.WriteLine("═══════════════════════════════════════════");
                        writer.WriteLine();

                        writer.WriteLine($"{"Товар",-30} {"Ціна",10} {"Кільк.",7} {"Сума",10}");
                        writer.WriteLine(new string('─', 61));

                        decimal total = 0;
                        foreach (DataGridViewRow row in dataGridViewCart.Rows)
                        {
                            string name = row.Cells[0].Value.ToString();
                            decimal price = decimal.Parse(row.Cells[1].Value.ToString());
                            int quantity = int.Parse(row.Cells[2].Value.ToString());
                            decimal sum = price * quantity;
                            total += sum;

                            writer.WriteLine($"{name,-30} {price,10:F2} {quantity,7} {sum,10:F2}");
                        }

                        writer.WriteLine(new string('─', 61));
                        writer.WriteLine($"{"РАЗОМ:",-48} {total,10:F2} ₴");
                        writer.WriteLine();
                        writer.WriteLine($"Сума прописом: {NumberToWordsUA.Convert(total)}");
                        writer.WriteLine();
                        writer.WriteLine("═══════════════════════════════════════════");
                    }

                    MessageBox.Show("Чек успішно збережено!", "Успіх", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка збереження чека: {ex.Message}", "Помилка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
