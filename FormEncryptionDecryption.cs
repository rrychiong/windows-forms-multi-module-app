using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FormEncryptionDecryption : Form
    {
        private Label lblTitle;
        private Label lblInput;
        private TextBox txtInput;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private Label lblOutput;
        private TextBox txtOutput;
        private Button btnClear;
        private Button btnClose;

        // Using all letters of the alphabet as the key for Vigenere Cipher
        private readonly string vigenereKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public FormEncryptionDecryption()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Encryption/Decryption - Vigenere Cipher";
            this.Size = new Size(500, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "Vigenere Cipher Encryption/Decryption";
            lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Location = new Point(80, 20);
            lblTitle.Size = new Size(340, 30);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Input Label
            lblInput = new Label();
            lblInput.Text = "Input Text:";
            lblInput.Font = new Font("Segoe UI", 10);
            lblInput.Location = new Point(30, 70);
            lblInput.Size = new Size(80, 25);

            // Input TextBox
            txtInput = new TextBox();
            txtInput.Font = new Font("Segoe UI", 10);
            txtInput.Location = new Point(30, 95);
            txtInput.Size = new Size(440, 80);
            txtInput.Multiline = true;
            txtInput.ScrollBars = ScrollBars.Vertical;

            // Encrypt Button
            btnEncrypt = new Button();
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnEncrypt.BackColor = Color.FromArgb(128, 57, 123);
            btnEncrypt.ForeColor = Color.White;
            btnEncrypt.FlatStyle = FlatStyle.Flat;
            btnEncrypt.Location = new Point(150, 190);
            btnEncrypt.Size = new Size(90, 35);
            btnEncrypt.Click += BtnEncrypt_Click;

            // Decrypt Button
            btnDecrypt = new Button();
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnDecrypt.BackColor = Color.FromArgb(220, 53, 69);
            btnDecrypt.ForeColor = Color.White;
            btnDecrypt.FlatStyle = FlatStyle.Flat;
            btnDecrypt.Location = new Point(260, 190);
            btnDecrypt.Size = new Size(90, 35);
            btnDecrypt.Click += BtnDecrypt_Click;

            // Output Label
            lblOutput = new Label();
            lblOutput.Text = "Output Text:";
            lblOutput.Font = new Font("Segoe UI", 10);
            lblOutput.Location = new Point(30, 240);
            lblOutput.Size = new Size(90, 25);

            // Output TextBox
            txtOutput = new TextBox();
            txtOutput.Font = new Font("Segoe UI", 10);
            txtOutput.Location = new Point(30, 265);
            txtOutput.Size = new Size(440, 80);
            txtOutput.Multiline = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.ReadOnly = true;
            txtOutput.BackColor = Color.FromArgb(248, 249, 250);

            // Clear Button
            btnClear = new Button();
            btnClear.Text = "Clear";
            btnClear.Font = new Font("Segoe UI", 10);
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.ForeColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(30, 370);
            btnClear.Size = new Size(80, 30);
            btnClear.Click += BtnClear_Click;

            // Close Button
            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Font = new Font("Segoe UI", 10);
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(390, 370);
            btnClose.Size = new Size(80, 30);
            btnClose.Click += BtnClose_Click;

            // Add controls to form
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblInput);
            this.Controls.Add(txtInput);
            this.Controls.Add(btnEncrypt);
            this.Controls.Add(btnDecrypt);
            this.Controls.Add(lblOutput);
            this.Controls.Add(txtOutput);
            this.Controls.Add(btnClear);
            this.Controls.Add(btnClose);

            this.ResumeLayout(false);
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtInput.Text))
                {
                    MessageBox.Show("Please enter text to encrypt.", "Input Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string encryptedText = VigenereEncrypt(txtInput.Text, vigenereKey);
                txtOutput.Text = encryptedText;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during encryption: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtInput.Text))
                {
                    MessageBox.Show("Please enter text to decrypt.", "Input Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string decryptedText = VigenereDecrypt(txtInput.Text, vigenereKey);
                txtOutput.Text = decryptedText;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during decryption: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string VigenereEncrypt(string plaintext, string key)
        {
            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char c in plaintext.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    // Get the shift value from the key
                    int shift = key[keyIndex % key.Length] - 'A';
                    
                    // Encrypt the character
                    int encryptedChar = ((c - 'A') + shift) % 26;
                    result.Append((char)(encryptedChar + 'A'));
                    
                    keyIndex++;
                }
                else
                {
                    // Non-alphabetic characters are not encrypted
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        private string VigenereDecrypt(string ciphertext, string key)
        {
            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char c in ciphertext.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    // Get the shift value from the key
                    int shift = key[keyIndex % key.Length] - 'A';
                    
                    // Decrypt the character
                    int decryptedChar = ((c - 'A') - shift + 26) % 26;
                    result.Append((char)(decryptedChar + 'A'));
                    
                    keyIndex++;
                }
                else
                {
                    // Non-alphabetic characters are not decrypted
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtOutput.Clear();
            txtInput.Focus();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
