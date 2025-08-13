using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FormLogin : Form
    {
        private int failedAttempts = 0;
        private const int MaxFailedAttempts = 3;

        private Label lblTitle;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCreateAccount;
        private Label lblError;

        public FormLogin()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Login - Windows Forms App";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "User Login";
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Location = new Point(150, 30);
            lblTitle.Size = new Size(120, 30);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Username Label
            lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Font = new Font("Segoe UI", 10);
            lblUsername.Location = new Point(50, 80);
            lblUsername.Size = new Size(80, 25);

            // Username TextBox
            txtUsername = new TextBox();
            txtUsername.Font = new Font("Segoe UI", 10);
            txtUsername.Location = new Point(50, 105);
            txtUsername.Size = new Size(300, 25);

            // Password Label
            lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Font = new Font("Segoe UI", 10);
            lblPassword.Location = new Point(50, 140);
            lblPassword.Size = new Size(80, 25);

            // Password TextBox
            txtPassword = new TextBox();
            txtPassword.Font = new Font("Segoe UI", 10);
            txtPassword.Location = new Point(50, 165);
            txtPassword.Size = new Size(300, 25);
            txtPassword.PasswordChar = '*';
            txtPassword.KeyPress += TxtPassword_KeyPress;

            // Login Button
            btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnLogin.BackColor = Color.FromArgb(0, 120, 215);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Location = new Point(50, 210);
            btnLogin.Size = new Size(140, 35);
            btnLogin.Click += BtnLogin_Click;

            // Create Account Button
            btnCreateAccount = new Button();
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.Font = new Font("Segoe UI", 10);
            btnCreateAccount.BackColor = Color.FromArgb(240, 240, 240);
            btnCreateAccount.ForeColor = Color.FromArgb(64, 64, 64);
            btnCreateAccount.FlatStyle = FlatStyle.Flat;
            btnCreateAccount.Location = new Point(210, 210);
            btnCreateAccount.Size = new Size(140, 35);
            btnCreateAccount.Click += BtnCreateAccount_Click;

            // Error Label
            lblError = new Label();
            lblError.Font = new Font("Segoe UI", 9);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(50, 260);
            lblError.Size = new Size(300, 40);
            lblError.TextAlign = ContentAlignment.MiddleCenter;

            // Add controls to form
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnCreateAccount);
            this.Controls.Add(lblError);

            this.ResumeLayout(false);
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Username and password cannot be blank.";
                return;
            }

            if (DatabaseHelper.ValidateUser(txtUsername.Text.Trim(), txtPassword.Text))
            {
                // Successful login
                FormMain mainForm = new FormMain();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                failedAttempts++;
                lblError.Text = $"Invalid username or password. Attempts remaining: {MaxFailedAttempts - failedAttempts}";

                if (failedAttempts >= MaxFailedAttempts)
                {
                    MessageBox.Show("Maximum login attempts exceeded. Application will now close.", 
                        "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                txtPassword.Clear();
            }
        }

        private void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Username and password cannot be blank.";
                return;
            }

            if (DatabaseHelper.CreateUser(txtUsername.Text.Trim(), txtPassword.Text))
            {
                txtUsername.Clear();
                txtPassword.Clear();
                lblError.Text = "";
            }
        }
    }
}
