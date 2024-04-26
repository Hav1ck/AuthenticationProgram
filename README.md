# Authentication Program

This is a simple authentication program built using C# and WPF (Windows Presentation Foundation). It allows users to register new accounts and sign in to existing ones.

## Features

- User registration with username and password
- Password encryption using a combination of Caesar cipher and additional transformations
- User sign-in with verification of username and password
- Simple and intuitive graphical user interface (GUI)

## Requirements

- .NET Core 3.1 SDK or later
- Visual Studio (recommended) or any other C# IDE
- System.Text.Json package (included by default in Visual Studio, but may need to be installed manually in other IDEs)

## Installation

1. **Clone the Repository**: Clone this repository to your local machine.

```bash
git clone https://github.com/your-username/AuthenticationProgram.git
Install System.Text.Json Package: The project relies on the System.Text.Json package for JSON serialization and deserialization. You may need to install it manually via NuGet Package Manager.
dotnet add package System.Text.Json
Usage
Build and Run: Open the project in Visual Studio (or your preferred IDE) and build/run the application.
Registration: Click on the "Register" button to create a new account. Enter a username and password, then click "Register". If successful, a success message will be displayed.
Sign In: After registration, or if you already have an account, click on the "Sign in" button. Enter your username and password, then click "Sign in". If the credentials are correct, a success message will be displayed, indicating a successful login.
Contributing
Contributions are welcome! If you find any bugs or have suggestions for improvements, feel free to open an issue or create a pull request.

License
This project is licensed under the MIT License.
