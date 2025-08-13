using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FormCalculator : Form
    {
        private Label lblTitle;
        private Label lblFirstNumber;
        private TextBox txtFirstNumber;
        private Label lblSecondNumber;
        private TextBox txtSecondNumber;
        private Button btnAdd;
        private Button btnSubtract;
        private Button btnMultiply;
        private Button btnDivide;
        private Label lblResult;
        private Button btnClear;
        private Button btnClose;

        public FormCalculator()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Calculator";
            this.Size = new Size(450, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "Calculator";
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Location = new Point(170, 20);
            lblTitle.Size = new Size(110, 30);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // First Number Label
            lblFirstNumber = new Label();
            lblFirstNumber.Text = "First Number:";
            lblFirstNumber.Font = new Font("Segoe UI", 10);
            lblFirstNumber.Location = new Point(50, 70);
            lblFirstNumber.Size = new Size(100, 25);

            // First Number TextBox
            txtFirstNumber = new TextBox();
            txtFirstNumber.Font = new Font("Segoe UI", 10);
            txtFirstNumber.Location = new Point(50, 95);
            txtFirstNumber.Size = new Size(350, 25);

            // Second Number Label
            lblSecondNumber = new Label();
            lblSecondNumber.Text = "Second Number:";
            lblSecondNumber.Font = new Font("Segoe UI", 10);
            lblSecondNumber.Location = new Point(50, 130);
            lblSecondNumber.Size = new Size(110, 25);

            // Second Number TextBox
            txtSecondNumber = new TextBox();
            txtSecondNumber.Font = new Font("Segoe UI", 10);
            txtSecondNumber.Location = new Point(50, 155);
            txtSecondNumber.Size = new Size(350, 25);

            // Add Button
            btnAdd = new Button();
            btnAdd.Text = "Add (+)";
            btnAdd.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnAdd.BackColor = Color.FromArgb(40, 167, 69);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(50, 200);
            btnAdd.Size = new Size(80, 40);
            btnAdd.Click += BtnAdd_Click;

            // Subtract Button
            btnSubtract = new Button();
            btnSubtract.Text = "Subtract (-)";
            btnSubtract.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnSubtract.BackColor = Color.FromArgb(220, 53, 69);
            btnSubtract.ForeColor = Color.White;
            btnSubtract.FlatStyle = FlatStyle.Flat;
            btnSubtract.Location = new Point(140, 200);
            btnSubtract.Size = new Size(80, 40);
            btnSubtract.Click += BtnSubtract_Click;

            // Multiply Button
            btnMultiply = new Button();
            btnMultiply.Text = "Multiply (×)";
            btnMultiply.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnMultiply.BackColor = Color.FromArgb(0, 123, 255);
            btnMultiply.ForeColor = Color.White;
            btnMultiply.FlatStyle = FlatStyle.Flat;
            btnMultiply.Location = new Point(230, 200);
            btnMultiply.Size = new Size(80, 40);
            btnMultiply.Click += BtnMultiply_Click;

            // Divide Button
            btnDivide = new Button();
            btnDivide.Text = "Divide (÷)";
            btnDivide.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnDivide.BackColor = Color.FromArgb(255, 193, 7);
            btnDivide.ForeColor = Color.Black;
            btnDivide.FlatStyle = FlatStyle.Flat;
            btnDivide.Location = new Point(320, 200);
            btnDivide.Size = new Size(80, 40);
            btnDivide.Click += BtnDivide_Click;

            // Result Label
            lblResult = new Label();
            lblResult.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblResult.ForeColor = Color.FromArgb(40, 167, 69);
            lblResult.Location = new Point(50, 260);
            lblResult.Size = new Size(350, 50);
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            lblResult.BorderStyle = BorderStyle.FixedSingle;
            lblResult.BackColor = Color.FromArgb(248, 249, 250);
            lblResult.Text = "Result will appear here";

            // Clear Button
            btnClear = new Button();
            btnClear.Text = "Clear";
            btnClear.Font = new Font("Segoe UI", 10);
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.ForeColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(50, 370);
            btnClear.Size = new Size(80, 30);
            btnClear.Click += BtnClear_Click;

            // Close Button
            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Font = new Font("Segoe UI", 10);
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(320, 370);
            btnClose.Size = new Size(80, 30);
            btnClose.Click += BtnClose_Click;

            // Add controls to form
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblFirstNumber);
            this.Controls.Add(txtFirstNumber);
            this.Controls.Add(lblSecondNumber);
            this.Controls.Add(txtSecondNumber);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnSubtract);
            this.Controls.Add(btnMultiply);
            this.Controls.Add(btnDivide);
            this.Controls.Add(lblResult);
            this.Controls.Add(btnClear);
            this.Controls.Add(btnClose);

            this.ResumeLayout(false);
        }

        private bool ValidateInputs(out double firstNumber, out double secondNumber)
        {
            firstNumber = 0;
            secondNumber = 0;

            if (string.IsNullOrWhiteSpace(txtFirstNumber.Text) || string.IsNullOrWhiteSpace(txtSecondNumber.Text))
            {
                MessageBox.Show("Please enter both numbers.", "Input Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!double.TryParse(txtFirstNumber.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out firstNumber))
            {
                MessageBox.Show("Please enter a valid first number.", "Input Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!double.TryParse(txtSecondNumber.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out secondNumber))
            {
                MessageBox.Show("Please enter a valid second number.", "Input Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs(out double firstNumber, out double secondNumber))
                {
                    double result = firstNumber + secondNumber;
                    lblResult.Text = $"{firstNumber} + {secondNumber} = {result}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during addition: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSubtract_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs(out double firstNumber, out double secondNumber))
                {
                    double result = firstNumber - secondNumber;
                    lblResult.Text = $"{firstNumber} - {secondNumber} = {result}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during subtraction: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMultiply_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs(out double firstNumber, out double secondNumber))
                {
                    double result = firstNumber * secondNumber;
                    lblResult.Text = $"{firstNumber} × {secondNumber} = {result}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during multiplication: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDivide_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs(out double firstNumber, out double secondNumber))
                {
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("Cannot divide by zero.", "Division Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    double result = firstNumber / secondNumber;
                    lblResult.Text = $"{firstNumber} ÷ {secondNumber} = {result}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during division: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtFirstNumber.Clear();
            txtSecondNumber.Clear();
            lblResult.Text = "Result will appear here";
            txtFirstNumber.Focus();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
