using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FormCurrencyConverter : Form
    {
        private Label lblTitle;
        private Label lblAmount;
        private TextBox txtAmount;
        private Label lblFromCurrency;
        private ComboBox cmbFromCurrency;
        private Label lblToCurrency;
        private ComboBox cmbToCurrency;
        private Button btnConvert;
        private Label lblResult;
        private Button btnClose;

        // Exchange rates relative to USD
        private readonly Dictionary<string, double> exchangeRates = new Dictionary<string, double>
        {
            { "USD", 1.0 },      // US Dollar (base)
            { "EUR", 0.85 },     // Euro
            { "GBP", 0.73 },     // British Pound
            { "JPY", 110.0 },    // Japanese Yen
            { "CAD", 1.25 },     // Canadian Dollar
            { "AUD", 1.35 },     // Australian Dollar
            { "CHF", 0.92 },     // Swiss Franc
            { "CNY", 6.45 },     // Chinese Yuan
            { "INR", 74.5 },     // Indian Rupee
            { "PHP", 50.0 }      // Philippine Peso
        };

        public FormCurrencyConverter()
        {
            InitializeComponent();
            PopulateCurrencyComboBoxes();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Currency Converter";
            this.Size = new Size(450, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "Currency Converter";
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Location = new Point(130, 20);
            lblTitle.Size = new Size(190, 30);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Amount Label
            lblAmount = new Label();
            lblAmount.Text = "Amount:";
            lblAmount.Font = new Font("Segoe UI", 10);
            lblAmount.Location = new Point(50, 70);
            lblAmount.Size = new Size(60, 25);

            // Amount TextBox
            txtAmount = new TextBox();
            txtAmount.Font = new Font("Segoe UI", 10);
            txtAmount.Location = new Point(50, 95);
            txtAmount.Size = new Size(350, 25);

            // From Currency Label
            lblFromCurrency = new Label();
            lblFromCurrency.Text = "From Currency:";
            lblFromCurrency.Font = new Font("Segoe UI", 10);
            lblFromCurrency.Location = new Point(50, 140);
            lblFromCurrency.Size = new Size(100, 25);

            // From Currency ComboBox
            cmbFromCurrency = new ComboBox();
            cmbFromCurrency.Font = new Font("Segoe UI", 10);
            cmbFromCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFromCurrency.Location = new Point(50, 165);
            cmbFromCurrency.Size = new Size(150, 25);

            // To Currency Label
            lblToCurrency = new Label();
            lblToCurrency.Text = "To Currency:";
            lblToCurrency.Font = new Font("Segoe UI", 10);
            lblToCurrency.Location = new Point(250, 140);
            lblToCurrency.Size = new Size(100, 25);

            // To Currency ComboBox
            cmbToCurrency = new ComboBox();
            cmbToCurrency.Font = new Font("Segoe UI", 10);
            cmbToCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbToCurrency.Location = new Point(250, 165);
            cmbToCurrency.Size = new Size(150, 25);

            // Convert Button
            btnConvert = new Button();
            btnConvert.Text = "Convert";
            btnConvert.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnConvert.BackColor = Color.FromArgb(16, 137, 62);
            btnConvert.ForeColor = Color.White;
            btnConvert.FlatStyle = FlatStyle.Flat;
            btnConvert.Location = new Point(175, 210);
            btnConvert.Size = new Size(100, 35);
            btnConvert.Click += BtnConvert_Click;

            // Result Label
            lblResult = new Label();
            lblResult.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblResult.ForeColor = Color.FromArgb(16, 137, 62);
            lblResult.Location = new Point(50, 260);
            lblResult.Size = new Size(350, 40);
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            lblResult.BorderStyle = BorderStyle.FixedSingle;
            lblResult.BackColor = Color.FromArgb(248, 249, 250);

            // Close Button
            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Font = new Font("Segoe UI", 10);
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(350, 320);
            btnClose.Size = new Size(80, 30);
            btnClose.Click += BtnClose_Click;

            // Add controls to form
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblAmount);
            this.Controls.Add(txtAmount);
            this.Controls.Add(lblFromCurrency);
            this.Controls.Add(cmbFromCurrency);
            this.Controls.Add(lblToCurrency);
            this.Controls.Add(cmbToCurrency);
            this.Controls.Add(btnConvert);
            this.Controls.Add(lblResult);
            this.Controls.Add(btnClose);

            this.ResumeLayout(false);
        }

        private void PopulateCurrencyComboBoxes()
        {
            foreach (var currency in exchangeRates.Keys)
            {
                cmbFromCurrency.Items.Add(currency);
                cmbToCurrency.Items.Add(currency);
            }

            // Set default selections
            cmbFromCurrency.SelectedIndex = 0; // USD
            cmbToCurrency.SelectedIndex = 1;   // EUR
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAmount.Text))
                {
                    MessageBox.Show("Please enter an amount to convert.", "Input Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtAmount.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double amount))
                {
                    MessageBox.Show("Please enter a valid numeric amount.", "Input Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (amount < 0)
                {
                    MessageBox.Show("Amount cannot be negative.", "Input Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbFromCurrency.SelectedItem == null || cmbToCurrency.SelectedItem == null)
                {
                    MessageBox.Show("Please select both currencies.", "Selection Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string fromCurrency = cmbFromCurrency.SelectedItem.ToString();
                string toCurrency = cmbToCurrency.SelectedItem.ToString();

                // Convert to USD first, then to target currency
                double amountInUSD = amount / exchangeRates[fromCurrency];
                double convertedAmount = amountInUSD * exchangeRates[toCurrency];

                lblResult.Text = $"{amount:F2} {fromCurrency} = {convertedAmount:F2} {toCurrency}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during conversion: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
