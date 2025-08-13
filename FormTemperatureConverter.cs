using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FormTemperatureConverter : Form
    {
        private Label lblTitle;
        private Label lblInput;
        private TextBox txtTemperature;
        private RadioButton rbCelsiusToFahrenheit;
        private RadioButton rbFahrenheitToCelsius;
        private Button btnConvert;
        private Label lblResult;
        private Button btnClose;

        public FormTemperatureConverter()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Temperature Converter";
            this.Size = new Size(450, 350);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "Temperature Converter";
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Location = new Point(120, 20);
            lblTitle.Size = new Size(210, 30);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Input Label
            lblInput = new Label();
            lblInput.Text = "Enter Temperature:";
            lblInput.Font = new Font("Segoe UI", 10);
            lblInput.Location = new Point(50, 70);
            lblInput.Size = new Size(130, 25);

            // Temperature TextBox
            txtTemperature = new TextBox();
            txtTemperature.Font = new Font("Segoe UI", 10);
            txtTemperature.Location = new Point(50, 95);
            txtTemperature.Size = new Size(350, 25);

            // Celsius to Fahrenheit RadioButton
            rbCelsiusToFahrenheit = new RadioButton();
            rbCelsiusToFahrenheit.Text = "Celsius to Fahrenheit";
            rbCelsiusToFahrenheit.Font = new Font("Segoe UI", 10);
            rbCelsiusToFahrenheit.Location = new Point(50, 140);
            rbCelsiusToFahrenheit.Size = new Size(160, 25);
            rbCelsiusToFahrenheit.Checked = true;

            // Fahrenheit to Celsius RadioButton
            rbFahrenheitToCelsius = new RadioButton();
            rbFahrenheitToCelsius.Text = "Fahrenheit to Celsius";
            rbFahrenheitToCelsius.Font = new Font("Segoe UI", 10);
            rbFahrenheitToCelsius.Location = new Point(230, 140);
            rbFahrenheitToCelsius.Size = new Size(160, 25);

            // Convert Button
            btnConvert = new Button();
            btnConvert.Text = "Convert";
            btnConvert.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnConvert.BackColor = Color.FromArgb(0, 120, 215);
            btnConvert.ForeColor = Color.White;
            btnConvert.FlatStyle = FlatStyle.Flat;
            btnConvert.Location = new Point(175, 180);
            btnConvert.Size = new Size(100, 35);
            btnConvert.Click += BtnConvert_Click;

            // Result Label
            lblResult = new Label();
            lblResult.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblResult.ForeColor = Color.FromArgb(16, 137, 62);
            lblResult.Location = new Point(50, 230);
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
            btnClose.Location = new Point(350, 280);
            btnClose.Size = new Size(80, 30);
            btnClose.Click += BtnClose_Click;

            // Add controls to form
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblInput);
            this.Controls.Add(txtTemperature);
            this.Controls.Add(rbCelsiusToFahrenheit);
            this.Controls.Add(rbFahrenheitToCelsius);
            this.Controls.Add(btnConvert);
            this.Controls.Add(lblResult);
            this.Controls.Add(btnClose);

            this.ResumeLayout(false);
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTemperature.Text))
                {
                    MessageBox.Show("Please enter a temperature value.", "Input Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtTemperature.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double temperature))
                {
                    MessageBox.Show("Please enter a valid numeric temperature.", "Input Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double result;
                string resultText;

                if (rbCelsiusToFahrenheit.Checked)
                {
                    // Celsius to Fahrenheit: F = (C × 9/5) + 32
                    result = (temperature * 9.0 / 5.0) + 32;
                    resultText = $"{temperature:F2}°C = {result:F2}°F";
                }
                else
                {
                    // Fahrenheit to Celsius: C = (F - 32) × 5/9
                    result = (temperature - 32) * 5.0 / 9.0;
                    resultText = $"{temperature:F2}°F = {result:F2}°C";
                }

                lblResult.Text = resultText;
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
