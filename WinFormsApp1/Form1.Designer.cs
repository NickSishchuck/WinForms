namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            checkedListBoxProducts = new CheckedListBox();
            dataGridViewCart = new DataGridView();
            ProductName = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            labelTotal = new Label();
            labelTotalAmount = new Label();
            buttonConvert = new Button();
            labelAmountInWords = new Label();
            buttonAddToCart = new Button();
            buttonSaveReceipt = new Button();
            labelProducts = new Label();
            labelCart = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).BeginInit();
            SuspendLayout();
            // 
            // checkedListBoxProducts
            // 
            checkedListBoxProducts.CheckOnClick = true;
            checkedListBoxProducts.FormattingEnabled = true;
            checkedListBoxProducts.Location = new Point(20, 50);
            checkedListBoxProducts.Name = "checkedListBoxProducts";
            checkedListBoxProducts.Size = new Size(280, 300);
            checkedListBoxProducts.TabIndex = 0;
            // 
            // dataGridViewCart
            // 
            dataGridViewCart.AllowUserToAddRows = false;
            dataGridViewCart.AllowUserToDeleteRows = false;
            dataGridViewCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCart.Columns.AddRange(new DataGridViewColumn[] { ProductName, Price, Quantity });
            dataGridViewCart.Location = new Point(320, 50);
            dataGridViewCart.Name = "dataGridViewCart";
            dataGridViewCart.Size = new Size(450, 300);
            dataGridViewCart.TabIndex = 1;
            dataGridViewCart.CellValueChanged += DataGridViewCart_CellValueChanged;
            // 
            // ProductName
            // 
            ProductName.HeaderText = "Назва товару";
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            ProductName.Width = 180;
            // 
            // Price
            // 
            Price.HeaderText = "Ціна за од.";
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.Width = 100;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Кількість";
            Quantity.Name = "Quantity";
            Quantity.Width = 100;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelTotal.Location = new Point(320, 370);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(133, 21);
            labelTotal.TabIndex = 2;
            labelTotal.Text = "Загальна сума:";
            // 
            // labelTotalAmount
            // 
            labelTotalAmount.AutoSize = true;
            labelTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelTotalAmount.ForeColor = Color.Green;
            labelTotalAmount.Location = new Point(460, 370);
            labelTotalAmount.Name = "labelTotalAmount";
            labelTotalAmount.Size = new Size(54, 21);
            labelTotalAmount.TabIndex = 3;
            labelTotalAmount.Text = "0.00 ₴";
            // 
            // buttonConvert
            // 
            buttonConvert.Font = new Font("Segoe UI", 10F);
            buttonConvert.Location = new Point(320, 410);
            buttonConvert.Name = "buttonConvert";
            buttonConvert.Size = new Size(200, 35);
            buttonConvert.TabIndex = 4;
            buttonConvert.Text = "Перетворити";
            buttonConvert.UseVisualStyleBackColor = true;
            buttonConvert.Click += ButtonConvert_Click;
            // 
            // labelAmountInWords
            // 
            labelAmountInWords.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            labelAmountInWords.Location = new Point(320, 460);
            labelAmountInWords.Name = "labelAmountInWords";
            labelAmountInWords.Size = new Size(450, 60);
            labelAmountInWords.TabIndex = 5;
            // 
            // buttonAddToCart
            // 
            buttonAddToCart.Font = new Font("Segoe UI", 10F);
            buttonAddToCart.Location = new Point(20, 360);
            buttonAddToCart.Name = "buttonAddToCart";
            buttonAddToCart.Size = new Size(280, 35);
            buttonAddToCart.TabIndex = 6;
            buttonAddToCart.Text = "Додати до кошика";
            buttonAddToCart.UseVisualStyleBackColor = true;
            buttonAddToCart.Click += ButtonAddToCart_Click;
            // 
            // buttonSaveReceipt
            // 
            buttonSaveReceipt.Font = new Font("Segoe UI", 10F);
            buttonSaveReceipt.Location = new Point(540, 410);
            buttonSaveReceipt.Name = "buttonSaveReceipt";
            buttonSaveReceipt.Size = new Size(230, 35);
            buttonSaveReceipt.TabIndex = 7;
            buttonSaveReceipt.Text = "Зберегти чек";
            buttonSaveReceipt.UseVisualStyleBackColor = true;
            buttonSaveReceipt.Click += ButtonSaveReceipt_Click;
            // 
            // labelProducts
            // 
            labelProducts.AutoSize = true;
            labelProducts.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelProducts.Location = new Point(20, 20);
            labelProducts.Name = "labelProducts";
            labelProducts.Size = new Size(157, 20);
            labelProducts.TabIndex = 8;
            labelProducts.Text = "Товари в наявності:";
            // 
            // labelCart
            // 
            labelCart.AutoSize = true;
            labelCart.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelCart.Location = new Point(320, 20);
            labelCart.Name = "labelCart";
            labelCart.Size = new Size(130, 20);
            labelCart.TabIndex = 9;
            labelCart.Text = "Кошик покупця:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 540);
            Controls.Add(labelCart);
            Controls.Add(labelProducts);
            Controls.Add(buttonSaveReceipt);
            Controls.Add(buttonAddToCart);
            Controls.Add(labelAmountInWords);
            Controls.Add(buttonConvert);
            Controls.Add(labelTotalAmount);
            Controls.Add(labelTotal);
            Controls.Add(dataGridViewCart);
            Controls.Add(checkedListBoxProducts);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Касовий апарат";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBoxProducts;
        private DataGridView dataGridViewCart;
        private Label labelTotal;
        private Label labelTotalAmount;
        private Button buttonConvert;
        private Label labelAmountInWords;
        private Button buttonAddToCart;
        private Button buttonSaveReceipt;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Quantity;
        private Label labelProducts;
        private Label labelCart;
    }
}
