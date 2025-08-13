```markdown
# Detailed Implementation Plan for Windows Forms C# Application

This plan details creating a multi-window Windows Forms application in C# for Visual Studio that includes Log-in, Main Menu, Temperature Converter, Currency Converter, Calculator, and Encryption/Decryption modules.

---

## 1. Program.cs
- **Purpose:** Serve as the application entry point.
- **Steps:**
  - Add the [STAThread] attribute.
  - Call Application.EnableVisualStyles() and Application.SetCompatibleTextRenderingDefault(false).
  - Set the startup form to FormLogin.

---

## 2. DatabaseHelper.cs
- **Purpose:** Manage SQLite database operations.
- **Steps:**
  - Create a static class named DatabaseHelper.
  - Implement InitializeDatabase() to check for or create a "users.db" SQLite file and create a "Users" table (columns: Id (INTEGER PRIMARY KEY), Username (TEXT UNIQUE), PasswordHash (TEXT)).
  - Add CreateUser(string username, string password) that validates non-empty inputs, enforces password complexity (minimum 8 characters with at least one uppercase, one lowercase, and one number), hashes the password, and inserts the record.
  - Add ValidateUser(string username, string password) that queries the database, compares the hashed password, and returns validation results.
  - Use try-catch blocks for error handling and display MessageBox errors if database operations fail.

---

## 3. FormLogin.cs
- **Purpose:** Enable user log-in and account creation.
- **UI Elements:**
  - Labels and TextBoxes for Username and Password (set PasswordChar, e.g., '*').
  - “Login” and “Create Account” buttons.
  - A Label for error messages.
- **Steps:**
  - On form load, call DatabaseHelper.InitializeDatabase().
  - In the Login event handler:
    - Validate non-blank inputs.
    - Call ValidateUser; if invalid, increment a failure counter.
    - After 3 failed attempts, display an error MessageBox and exit the application.
    - On success, open FormMain and hide FormLogin.
  - In the Create Account event handler:
    - Validate inputs including password complexity.
    - Call CreateUser and display confirmation or error messages.

---

## 4. FormMain.cs
- **Purpose:** Serve as the main navigation hub.
- **UI Elements:**
  - Modern styled buttons (using clear typography, uniform colors, and proper spacing) for:
    - Temperature Converter
    - Currency Converter
    - Calculator
    - Encryption/Decryption
- **Steps:**
  - Implement event handlers for each button to open the corresponding module form (modal or new window).

---

## 5. FormTemperatureConverter.cs
- **Purpose:** Convert temperature units.
- **UI Elements:**
  - A TextBox for temperature input.
  - Two RadioButtons to select conversion: Celsius to Fahrenheit and Fahrenheit to Celsius.
  - A “Convert” button.
  - A Label for displaying the result.
- **Steps:**
  - Validate numeric input.
  - On conversion click:
    - Compute (C × 9/5 + 32) for Celsius to Fahrenheit.
    - Compute ((F – 32) × 5/9) for Fahrenheit to Celsius.
  - Display results and handle invalid entries with error messages.

---

## 6. FormCurrencyConverter.cs
- **Purpose:** Convert currency amounts.
- **UI Elements:**
  - A TextBox for amount input.
  - Two ComboBoxes for “From Currency” and “To Currency” (populate with options like USD, EUR, GBP).
  - A “Convert” button.
  - A Label for the result.
- **Steps:**
  - Validate that the amount is numeric.
  - Use a hardcoded dictionary for conversion rates.
  - Perform the conversion and update the result Label.
  - Provide error feedback if the input is invalid.

---

## 7. FormCalculator.cs
- **Purpose:** Perform arithmetic operations.
- **UI Elements:**
  - Two TextBoxes for numerical inputs.
  - Buttons for operations: Add, Subtract, Multiply, and Divide.
  - A Label to display the calculation result.
- **Steps:**
  - Validate numeric inputs before calculation.
  - In event handlers, perform the selected arithmetic operation.
  - Implement division-by-zero checks and show appropriate error messages.

---

## 8. FormEncryptionDecryption.cs
- **Purpose:** Encrypt and decrypt text using the Vigenere Cipher.
- **UI Elements:**
  - A TextBox for user input (plaintext or ciphertext).
  - Two buttons: “Encrypt” and “Decrypt”.
  - A multi-line TextBox for output.
- **Steps:**
  - Implement the Vigenere Cipher using a default key of "ABCDEFGHIJKLMNOPQRSTUVWXYZ".
  - On “Encrypt” click, encrypt the text (ignore case and non-letter characters as needed).
  - On “Decrypt” click, reverse the process.
  - Validate that the input is not empty and provide user-friendly error messages on failure.

---

## Additional Best Practices and Integration
- Ensure every UI module uses a consistent and modern design (clean fonts, subtle colors, ample spacing).
- Validate all user inputs and wrap database and conversion operations in try-catch blocks.
- Use MessageBox dialogs to notify users of errors or confirmation messages.
- Install the required SQLite NuGet package (System.Data.SQLite or Microsoft.Data.Sqlite) and reference it in the project.
- Test each module individually and then perform integration testing in Visual Studio.

---

**Summary:**  
The solution involves creating a C# Windows Forms application with separate forms for login, main menu, temperature conversion, currency conversion, calculator, and Vigenere cipher encryption/decryption. DatabaseHelper.cs manages SQLite operations and user validations, ensuring password complexity and non-blank inputs. Each form is designed with a modern UI and proper error handling using try-catch blocks and MessageBox alerts. User authentication enforces a maximum of three failed attempts before exit. Modular event handlers enable each form to operate independently while ensuring a cohesive application flow. This plan details file creation, UI element specification, and integration testing steps essential for a robust real-world application.
