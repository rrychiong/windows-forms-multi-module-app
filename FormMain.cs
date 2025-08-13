using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FormMain : Form
    {
        private Label lblTitle;
        private Button btnTemperatureConverter;
        private Button btnCurrencyConverter;
        private Button btnCalculator;
        private Button btnEncryptionDecryption;
        private Button btnLogout;

        public FormMain()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Main Menu - Windows Forms App";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "Main Menu";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Location = new Point(180, 30);
            lblTitle.Size = new Size(140, 35);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Temperature Converter Button
            btnTemperatureConverter = new Button();
            btnTemperatureConverter.Text = "Temperature Converter";
            btnTemperatureConverter.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnTemperatureConverter.BackColor = Color.FromArgb(0, 120, 215);
            btnTemperatureConverter.ForeColor = Color.White;
            btnTemperatureConverter.FlatStyle = FlatStyle.Flat;
            btnTemperatureConverter.Location = new Point(150, 90);
            btnTemperatureConverter.Size = new Size(200, 45);
            btnTemperatureConverter.Click += BtnTemperatureConverter_Click;

            // Currency Converter Button
            btnCurrencyConverter = new Button();
            btnCurrencyConverter.Text = "Currency Converter";
            btnCurrencyConverter.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnCurrencyConverter.BackColor = Color.FromArgb(16, 137, 62);
            btnCurrencyConverter.ForeColor = Color.White;
            btnCurrencyConverter.FlatStyle = FlatStyle.Flat;
            btnCurrencyConverter.Location = new Point(150, 150);
            btnCurrencyConverter.Size = new Size(200, 45);
            btnCurrencyConverter.Click += BtnCurrencyConverter_Click;

            // Calculator Button
            btnCalculator = new Button();
            btnCalculator.Text = "Calculator";
            btnCalculator.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnCalculator.BackColor = Color.FromArgb(255, 140, 0);
            btnCalculator.ForeColor = Color.White;
            btnCalculator.FlatStyle = FlatStyle.Flat;
            btnCalculator.Location = new Point(150, 210);
            btnCalculator.Size = new Size(200, 45);
            btnCalculator.Click += BtnCalculator_Click;

            // Encryption/Decryption Button
            btnEncryptionDecryption = new Button();
            btnEncryptionDecryption.Text = "Encryption/Decryption";
            btnEncryptionDecryption.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnEncryptionDecryption.BackColor = Color.FromArgb(128, 57, 123);
            btnEncryptionDecryption.ForeColor = Color.White;
            btnEncryptionDecryption.FlatStyle = FlatStyle.Flat;
            btnEncryptionDecryption.Location = new Point(150, 270);
            btnEncryptionDecryption.Size = new Size(200, 45);
            btnEncryptionDecryption.Click += BtnEncryptionDecryption_Click;

            // Logout Button
            btnLogout = new Button();
            btnLogout.Text = "Logout";
            btnLogout.Font = new Font("Segoe UI", 10);
            btnLogout.BackColor = Color.FromArgb(220, 53, 69);
            btnLogout.ForeColor = Color.White;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(400, 330);
            btnLogout.Size = new Size(80, 30);
            btnLogout.Click += BtnLogout_Click;

            // Add controls to form
            this.Controls.Add(lblTitle);
            this.Controls.Add(btnTemperatureConverter);
            this.Controls.Add(btnCurrencyConverter);
            this.Controls.Add(btnCalculator);
            this.Controls.Add(btnEncryptionDecryption);
            this.Controls.Add(btnLogout);

            this.ResumeLayout(false);
        }

        private void BtnTemperatureConverter_Click(object sender, EventArgs e)
        {
            FormTemperatureConverter tempForm = new FormTemperatureConverter();
            tempForm.ShowDialog();
        }

        private void BtnCurrencyConverter_Click(object sender, EventArgs e)
        {
            FormCurrencyConverter currencyForm = new FormCurrencyConverter();
            currencyForm.ShowDialog();
        }

        private void BtnCalculator_Click(object sender, EventArgs e)
        {
            FormCalculator calculatorForm = new FormCalculator();
            calculatorForm.ShowDialog();
        }

        private void BtnEncryptionDecryption_Click(object sender, EventArgs e)
        {
            FormEncryptionDecryption encryptForm = new FormEncryptionDecryption();
            encryptForm.ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Application.Exit();
            base.OnFormClosed(e);
        }
    }
}
