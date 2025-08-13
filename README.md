# Windows Forms Application - Multi-Module System

A comprehensive C# Windows Forms application featuring multiple modules including user authentication, converters, calculator, and encryption/decryption functionality.

## Features

### 🔐 Login Module
- Username/password validation with SQLite database
- User account creation with password complexity requirements
- Password masking during input
- Maximum 3 failed login attempts before application exit
- Secure password hashing using SHA256

### 🏠 Main Menu
- Clean, modern navigation interface
- Access to all application modules
- Logout functionality

### 🌡️ Temperature Converter
- Convert between Celsius and Fahrenheit
- Input validation and error handling
- Real-time conversion results

### 💱 Currency Converter
- Support for 10 major currencies (USD, EUR, GBP, JPY, CAD, AUD, CHF, CNY, INR, PHP)
- Hardcoded exchange rates for demonstration
- Dropdown selection for source and target currencies

### 🧮 Calculator
- Basic arithmetic operations (Add, Subtract, Multiply, Divide)
- Division by zero protection
- Input validation for numeric values
- Clear functionality

### 🔒 Encryption/Decryption Module
- Vigenere Cipher implementation
- Uses full alphabet (A-Z) as encryption key
- Supports both encryption and decryption
- Preserves non-alphabetic characters

## Requirements

- **Visual Studio 2019 or later**
- **.NET 6.0 or later**
- **Windows OS** (Windows Forms requirement)

## Installation & Setup

### Step 1: Open in Visual Studio
1. Download/extract all the project files to a folder
2. Open **Visual Studio**
3. Click **File** → **Open** → **Project/Solution**
4. Navigate to the project folder and select `WindowsFormsApp.csproj`
5. Click **Open**

### Step 2: Restore NuGet Packages
1. In Visual Studio, right-click on the **Solution** in Solution Explorer
2. Select **Restore NuGet Packages**
3. Wait for the SQLite package to be downloaded and installed

### Step 3: Build the Project
1. Press **Ctrl+Shift+B** or go to **Build** → **Build Solution**
2. Ensure there are no build errors

### Step 4: Run the Application
1. Press **F5** or click the **Start** button
2. The login form will appear

## Usage Instructions

### First Time Setup
1. **Create an Account:**
   - Enter a username and password
   - Password must be at least 8 characters with uppercase, lowercase, and number
   - Click "Create Account"

2. **Login:**
   - Enter your credentials
   - Click "Login"
   - You have 3 attempts before the application closes

### Using the Modules

#### Temperature Converter
- Enter a temperature value
- Select conversion type (Celsius to Fahrenheit or vice versa)
- Click "Convert" to see results

#### Currency Converter
- Enter amount to convert
- Select source and target currencies from dropdowns
- Click "Convert" to see exchange rate calculation

#### Calculator
- Enter two numbers
- Click the desired operation button (+, -, ×, ÷)
- View results in the result area
- Use "Clear" to reset

#### Encryption/Decryption
- Enter text in the input area
- Click "Encrypt" to encrypt the text using Vigenere cipher
- Click "Decrypt" to decrypt cipher text
- Uses full alphabet (A-Z) as the encryption key

## Technical Details

### Database
- **SQLite** database (`users.db`) created automatically
- **Users table** with columns: Id, Username, PasswordHash
- Passwords are hashed using **SHA256** for security

### Password Requirements
- Minimum 8 characters
- At least one uppercase letter (A-Z)
- At least one lowercase letter (a-z)
- At least one number (0-9)

### Security Features
- Password hashing (SHA256)
- SQL injection protection using parameterized queries
- Input validation on all forms
- Maximum login attempts limit

## Project Structure

```
WindowsFormsApp/
├── WindowsFormsApp.csproj          # Project file
├── Program.cs                      # Application entry point
├── DatabaseHelper.cs               # SQLite database operations
├── FormLogin.cs                    # Login form
├── FormMain.cs                     # Main navigation form
├── FormTemperatureConverter.cs     # Temperature conversion
├── FormCurrencyConverter.cs        # Currency conversion
├── FormCalculator.cs               # Calculator functionality
├── FormEncryptionDecryption.cs     # Vigenere cipher
└── README.md                       # This file
```

## Troubleshooting

### Common Issues

1. **SQLite Package Missing:**
   - Right-click project → Manage NuGet Packages
   - Install `System.Data.SQLite`

2. **Build Errors:**
   - Ensure .NET 6.0 or later is installed
   - Check that all files are in the same directory
   - Rebuild solution (Build → Rebuild Solution)

3. **Database Issues:**
   - Delete `users.db` file if it exists and restart the application
   - Check file permissions in the project directory

4. **Form Display Issues:**
   - Ensure Windows Forms is enabled in project properties
   - Check that `UseWindowsForms` is set to `true` in the .csproj file

## Development Notes

- All forms use modern, clean UI design with consistent styling
- Error handling implemented throughout with try-catch blocks
- Input validation on all user inputs
- Responsive design elements with proper spacing and typography
- Modal dialogs for converter and utility forms

## License

This project is for educational purposes. Feel free to modify and extend as needed.
