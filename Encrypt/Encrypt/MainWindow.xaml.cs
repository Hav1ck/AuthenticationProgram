using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

using System.Windows;
using System.Windows.Controls;


namespace Encryption
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        EncryptionSystem encryption = new EncryptionSystem();
        Account account = new Account();

        private void SignInTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Set the visibility of UsernamePlaceholder TextBlock to Collapsed
            SignInTextPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void SignInPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            // Set the visibility of PasswordPlaceholder TextBlock to Collapsed
            SignInPasswordPlaceholder.Visibility = Visibility.Collapsed;
        }
        private void SignInTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Show the placeholder if the text box is empty
            if (string.IsNullOrWhiteSpace(SignInTextBox.Text))
            {
                SignInTextPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void SignInPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            // Show the placeholder if the password box is empty
            if (string.IsNullOrWhiteSpace(SignInPasswordBox.Password))
            {
                SignInPasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void RegisterTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Set the visibility of UsernamePlaceholder TextBlock to Collapsed
            RegisterTextPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void RegisterPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            // Set the visibility of PasswordPlaceholder TextBlock to Collapsed
            RegisterPasswordPlaceholder.Visibility = Visibility.Collapsed;
        }
        private void RegisterTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Show the placeholder if the text box is empty
            if (string.IsNullOrWhiteSpace(RegisterTextBox.Text))
            {
                RegisterTextPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void RegisterPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            // Show the placeholder if the password box is empty
            if (string.IsNullOrWhiteSpace(RegisterPasswordBox.Password))
            {
                RegisterPasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }
        private void BackToMainMenu(object sender, RoutedEventArgs e)
        {
            RegisterTextBox.Text = "";
            RegisterPasswordBox.Password = "";
            SignInTextBox.Text = "";
            SignInPasswordBox.Password = "";

            RegisterHeader.Visibility = Visibility.Collapsed;
            RegisterDescription.Visibility = Visibility.Collapsed;
            RegisterTextBox.Visibility = Visibility.Collapsed;
            RegisterTextPlaceholder.Visibility = Visibility.Collapsed;
            RegisterPasswordBox.Visibility = Visibility.Collapsed;
            RegisterPasswordPlaceholder.Visibility = Visibility.Collapsed;
            RegisterButton.Visibility = Visibility.Collapsed;
            RegisterAgreement.Visibility = Visibility.Collapsed;
            RegisterAgreement2.Visibility = Visibility.Collapsed;
            RegisterStartButton.Visibility = Visibility.Visible;
            SignInStartButton.Visibility = Visibility.Visible;
            RegisterTextBorder.Visibility = Visibility.Collapsed;
            RegisterTextBorder2.Visibility = Visibility.Collapsed;
            RegisterPasswordBorder.Visibility = Visibility.Collapsed;
            RegisterPasswordBorder2.Visibility = Visibility.Collapsed;
            CenterFrame.Visibility = Visibility.Collapsed;
            SignInHeader.Visibility = Visibility.Collapsed;
            SignInDescription.Visibility = Visibility.Collapsed;
            SignInTextBox.Visibility = Visibility.Collapsed;
            SignInTextPlaceholder.Visibility = Visibility.Collapsed;
            SignInPasswordBox.Visibility = Visibility.Collapsed;
            SignInPasswordPlaceholder.Visibility = Visibility.Collapsed;
            SignInButton.Visibility = Visibility.Collapsed;
            SignInAgreement.Visibility = Visibility.Collapsed;
            SignInAgreement2.Visibility = Visibility.Collapsed;
            SignInTextBorder.Visibility = Visibility.Collapsed;
            SignInTextBorder2.Visibility = Visibility.Collapsed;
            SignInPasswordBorder.Visibility = Visibility.Collapsed;
            SignInPasswordBorder2.Visibility = Visibility.Collapsed;
            BackToMainMenuButton.Visibility = Visibility.Collapsed;
            SignInSuccess.Visibility = Visibility.Collapsed;
            RegisterError.Visibility = Visibility.Collapsed;
            MainBoxColor.Background = System.Windows.Media.Brushes.LightGray;
        }

        private void RegisterStartButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterHeader.Visibility = Visibility.Visible;
            RegisterDescription.Visibility = Visibility.Visible;
            RegisterTextBox.Visibility = Visibility.Visible;
            RegisterTextPlaceholder.Visibility = Visibility.Visible;
            RegisterPasswordBox.Visibility = Visibility.Visible;
            RegisterPasswordPlaceholder.Visibility = Visibility.Visible;
            RegisterButton.Visibility = Visibility.Visible;
            RegisterAgreement.Visibility = Visibility.Visible;
            RegisterAgreement2.Visibility = Visibility.Visible;
            RegisterStartButton.Visibility = Visibility.Collapsed;
            SignInStartButton.Visibility = Visibility.Collapsed;
            RegisterTextBorder.Visibility = Visibility.Visible;
            RegisterTextBorder2.Visibility = Visibility.Visible;
            RegisterPasswordBorder.Visibility = Visibility.Visible;
            RegisterPasswordBorder2.Visibility = Visibility.Visible;
            CenterFrame.Visibility = Visibility.Visible;
            BackToMainMenuButton.Visibility = Visibility.Visible;
            MainBoxColor.Background = System.Windows.Media.Brushes.DarkGray;
        }
        private void SignInStartButton_Click(object sender, RoutedEventArgs e)
        {
            SignInHeader.Visibility = Visibility.Visible;
            SignInDescription.Visibility = Visibility.Visible;
            SignInTextBox.Visibility = Visibility.Visible;
            SignInTextPlaceholder.Visibility = Visibility.Visible;
            SignInPasswordBox.Visibility = Visibility.Visible;
            SignInPasswordPlaceholder.Visibility = Visibility.Visible;
            SignInButton.Visibility = Visibility.Visible;
            SignInAgreement.Visibility = Visibility.Visible;
            SignInAgreement2.Visibility = Visibility.Visible;
            RegisterStartButton.Visibility = Visibility.Collapsed;
            SignInStartButton.Visibility = Visibility.Collapsed;
            SignInTextBorder.Visibility = Visibility.Visible;
            SignInTextBorder2.Visibility = Visibility.Visible;
            SignInPasswordBorder.Visibility = Visibility.Visible;
            SignInPasswordBorder2.Visibility = Visibility.Visible;
            CenterFrame.Visibility = Visibility.Visible;
            BackToMainMenuButton.Visibility = Visibility.Visible;
            MainBoxColor.Background = System.Windows.Media.Brushes.DarkGray;
        }
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string username = SignInTextBox.Text;
            string password = SignInPasswordBox.Password;
            login(username, password);
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string saltValue = encryption.salt();
            string username = RegisterTextBox.Text;
            string password = RegisterPasswordBox.Password;
            register(saltValue, username, password);
        }

        // Method to register a new user
        public void login(string username, string password)
        {
            try
            {
                // Read JSON file content
                string jsonData = File.ReadAllText(FilePath);

                // Deserialize JSON data into a list of Account objects
                List<Account> accounts = JsonSerializer.Deserialize<List<Account>>(jsonData);

                // Find the account with the provided username
                Account userAccount = accounts.Find(account => account.Name == username);

                if (userAccount != null)
                {
                    // Extract salt, random numbers, and final encrypted password
                    string saltValue = userAccount.Salt;
                    int[] randomNumbers = userAccount.RandomNumbers;
                    string finalEncryptedPassword = userAccount.EncryptedPassword;

                    // Append salt to the entered password
                    password += saltValue;

                    // Encrypt the entered password using the same process as during registration
                    string encryptedPassword = encryption.EncryptPassword(password, randomNumbers);
                    encryptedPassword = encryption.dqcr(encryptedPassword);
                    encryptedPassword = encryption.dqcr2(encryptedPassword);

                    // Check if the encrypted password matches the stored encrypted password
                    if (encryptedPassword == finalEncryptedPassword)
                    {
                        // UI changes for successful login
                        SignInSuccess.Visibility = Visibility.Visible;
                        SignInHeader.Visibility = Visibility.Collapsed;
                        SignInDescription.Visibility = Visibility.Collapsed;
                        SignInTextBox.Visibility = Visibility.Collapsed;
                        SignInTextPlaceholder.Visibility = Visibility.Collapsed;
                        SignInPasswordBox.Visibility = Visibility.Collapsed;
                        SignInPasswordPlaceholder.Visibility = Visibility.Collapsed;
                        SignInButton.Visibility = Visibility.Collapsed;
                        SignInAgreement.Visibility = Visibility.Collapsed;
                        SignInAgreement2.Visibility = Visibility.Collapsed;
                        SignInTextBorder.Visibility = Visibility.Collapsed;
                        SignInTextBorder2.Visibility = Visibility.Collapsed;
                        SignInPasswordBorder.Visibility = Visibility.Collapsed;
                        SignInPasswordBorder2.Visibility = Visibility.Collapsed;
                        CenterFrame.Visibility = Visibility.Collapsed;
                        RegisterError.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        // UI changes for incorrect password
                        RegisterError.Visibility = Visibility.Visible;
                        RegisterError.Foreground = System.Windows.Media.Brushes.Red;
                        RegisterError.Text = "Password incorrect";
                    }
                }
                else
                {
                    // UI changes for username not found
                    RegisterError.Visibility = Visibility.Visible;
                    RegisterError.Foreground = System.Windows.Media.Brushes.Red;
                    RegisterError.Text = "Username not found";
                }
            }
            catch (Exception ex)
            {
                // UI changes for error
                RegisterError.Visibility = Visibility.Visible;
                RegisterError.Foreground = System.Windows.Media.Brushes.Red;
                RegisterError.Text = "An error occurred";
            }
        }
        public void register(string saltValue, string username, string password)
        {
            try
            {
                // Read existing JSON data from file
                List<Account> accounts = new List<Account>();
                if (File.Exists(FilePath))
                {
                    string jsonData = File.ReadAllText(FilePath);
                    accounts = JsonSerializer.Deserialize<List<Account>>(jsonData);
                }

                // Check if the username already exists
                if (accounts.Exists(acc => acc.Name == username))
                {
                    // Username already exists, show error message
                    RegisterError.Visibility = Visibility.Visible;
                    RegisterError.Foreground = System.Windows.Media.Brushes.Red;
                    RegisterError.Text = "This username is already taken";
                    return;
                }

                // Append salt to the password
                password += saltValue;

                // Perform encryption using Caesar cipher
                (string encryptedPassword, int[] randomNumbers) = encryption.caesar(password);
                encryptedPassword = encryption.dqcr(encryptedPassword);
                encryptedPassword = encryption.dqcr2(encryptedPassword);

                // Create a new account object
                Account newAccount = new Account
                {
                    Name = username,
                    Salt = saltValue,
                    RandomNumbers = randomNumbers,
                    EncryptedPassword = encryptedPassword,
                    Date = DateTime.Now
                };

                // Add the new account to the list
                accounts.Add(newAccount);

                // Serialize the updated account list to JSON
                string json = JsonSerializer.Serialize(accounts);

                // Write the JSON data back to the file
                File.WriteAllText(FilePath, json);

                // Show success message
                RegisterError.Visibility = Visibility.Visible;
                RegisterError.Text = "Registration successful. Details saved in Data.json";
                RegisterError.Foreground = System.Windows.Media.Brushes.Green;
            }
            catch (Exception ex)
            {
                // Show error message
                RegisterError.Visibility = Visibility.Visible;
                RegisterError.Foreground = System.Windows.Media.Brushes.Red;
                RegisterError.Text = "An error occurred: " + ex.Message;
            }
        }

    string FilePath = "../../Data.json";
    }


}
