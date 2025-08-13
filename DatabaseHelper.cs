using System;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString = "Data Source=users.db;Version=3;";

        public static void InitializeDatabase()
        {
            try
            {
                if (!File.Exists("users.db"))
                {
                    SQLiteConnection.CreateFile("users.db");
                }

                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT UNIQUE NOT NULL,
                            PasswordHash TEXT NOT NULL
                        )";
                    
                    using (var command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database initialization error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool CreateUser(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Username and password cannot be blank.", "Validation Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!IsPasswordComplex(password))
                {
                    MessageBox.Show("Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one number.", 
                        "Password Complexity Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string hashedPassword = HashPassword(password);

                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO Users (Username, PasswordHash) VALUES (@username, @password)";
                    
                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", hashedPassword);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("User account created successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (SQLiteException ex) when (ex.ErrorCode == SQLiteErrorCode.Constraint)
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating user: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool ValidateUser(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    return false;
                }

                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT PasswordHash FROM Users WHERE Username = @username";
                    
                    using (var command = new SQLiteCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        var result = command.ExecuteScalar();
                        
                        if (result != null)
                        {
                            string storedHash = result.ToString();
                            return VerifyPassword(password, storedHash);
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error validating user: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static bool IsPasswordComplex(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasUpper = Regex.IsMatch(password, @"[A-Z]");
            bool hasLower = Regex.IsMatch(password, @"[a-z]");
            bool hasNumber = Regex.IsMatch(password, @"[0-9]");

            return hasUpper && hasLower && hasNumber;
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private static bool VerifyPassword(string password, string hash)
        {
            string hashOfInput = HashPassword(password);
            return hashOfInput.Equals(hash);
        }
    }
}
