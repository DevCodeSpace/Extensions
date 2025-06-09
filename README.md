# Utills-Nuget

<img src="./Images/preview.png" alt="Utills-Nuget Cover Image" width="600" height="150">

[![NuGet Version](https://img.shields.io/nuget/v/Utills)](https://www.nuget.org/packages/Utills)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Utills)](https://www.nuget.org/packages/Utills)

## Description

Utills-Nuget is your go-to toolkit for .NET development, offering a rich set of extension methods and utility functions designed to streamline your coding experience. Whether you're manipulating strings, working with dates, or generating secure passwords, Utills-Nuget provides the tools you need to write cleaner, more efficient code. Dive in and discover how Utills-Nuget can simplify your .NET projects!

## Table of Contents

- [Description](#description)
- [Installation](#installation)
- [Usage](#usage)
- [Utilities](#utilities)
  - [ColorExtensions](#colorextensions)
  - [DateComparisonExtensions](#datecomparisonextensions)
  - [FileExtensions](#fileextensions)
  - [IntExtension](#intextension)
  - [NumExtension](#numextension)
  - [StringExtensions](#stringextensions)
  - [Web3Utils](#web3utils)
- [Contributing](#contributing)
- [License](#license)

## Installation

You can install Utills-Nuget via NuGet Package Manager:

```powershell
Install-Package Utills
```

Or via the .NET CLI:

```bash
dotnet add package Utills
```

## Usage

Once installed, you can use the extension methods and utility functions in your .NET project by importing the `Utills` namespace:

```csharp
using Utills;
```

## Utilities

### ColorExtensions

Provides extension methods for working with colors, allowing you to manipulate and convert colors easily.

```csharp
// Example 1: Convert a color to its hexadecimal representation
string hexColor = Color.Red.ToHex(); // Returns "#FFFF0000"

// Example 2: Shade a color
Color shadedColor = Color.Blue.Shade(200); // Returns a darker shade of blue

// Example 3: Check if a color is light
bool isLight = Color.Yellow.IsLight(); // Returns true

// Example 4: Tween between two colors
Color startColor = Color.Red;
Color endColor = Color.Blue;
Color tweenColor = startColor.TweenTo(endColor, 0.5); // Returns a color halfway between red and blue
```

### DateComparisonExtensions

Provides extension methods for comparing dates, making it easier to perform common date-related checks and manipulations.

```csharp
// Example 1: Check if a date is within a specified range
DateTime date = DateTime.Now;
DateTime startDate = DateTime.Now.AddDays(-1);
DateTime endDate = DateTime.Now.AddDays(1);
bool isInRange = date.IsBetween(startDate, endDate); // Returns true

// Example 2: Check if a date is today
bool isToday = DateTime.Now.IsToday(); // Returns true

// Example 3: Get the date only part of a DateTime
DateTime dateOnly = DateTime.Now.DateOnly(); // Returns DateTime.Now with the time set to 00:00:00

// Example 4: Check if a date is in the past
bool isPast = DateTime.Now.AddDays(-1).IsPast(); // Returns true
```

### FileExtensions

Provides extension methods for working with files, providing functionalities such as copying, clearing, and monitoring file changes.

```csharp
// Example 1: Get the MIME type of a file
string mimeType = "example.txt".GetMimeType(); // Returns "text/plain"

// Example 2: Clear a file's content asynchronously
FileInfo file = new FileInfo("example.txt");
await file.ClearAsync();

// Example 3: Append text to a file asynchronously
await file.AppendStringAsync("This is some text to append.");
```

### IntExtension

Provides extension methods for working with integers, offering functionalities such as checking divisibility, generating ranges, and converting to time spans.

```csharp
// Example 1: Check if an integer is even
int number = 4;
bool isEven = number.IsEven(); // Returns true

// Example 2: Convert an integer to a TimeSpan (seconds)
TimeSpan time = 10.Seconds(); // Returns a TimeSpan of 10 seconds

// Example 3: Generate a range of integers
IEnumerable<int> range = 1.RangeTo(5); // Returns [1, 2, 3, 4, 5]

// Example 4: Get the digits of an integer
List<int> digits = 12345.Digits(); // Returns [1, 2, 3, 4, 5]
```

### NumExtension

Provides extension methods for working with numbers, including clamping, rounding, and converting between degrees and radians.

```csharp
// Example 1: Clamp a number within a specified range
decimal value = 150;
decimal min = 0;
decimal max = 100;
decimal clampedValue = value.Clamp(min, max); // Returns 100

// Example 2: Round a number to a specific number of decimal places
double roundedValue = 3.14159.RoundToDecimals(2); // Returns 3.14

// Example 3: Convert degrees to radians
double radians = 180.0.AsRadians(); // Returns 3.141592653589793

// Example 4: Check if a number is between two values
bool isBetween = 5.0.IsBetween(2.0, 8.0); // Returns true
```

### StringExtensions

Provides extension methods for working with strings, offering functionalities such as validation, formatting, and manipulation.

```csharp
// Example 1: Check if a string is a valid email address
string email = "test@example.com";
bool isValidEmail = email.IsValidEmail(); // Returns true

// Example 2: Capitalize the first letter of a string
string capitalizedString = "hello".Capitalize(); // Returns "Hello"

// Example 3: Reverse a string
string reversedString = "hello".Reverse(); // Returns "olleh"

// Example 4: Check if a string is a palindrome
bool isPalindrome = "madam".IsPalindrome(); // Returns true
```

### Web3Utils

Provides utility functions for working with Web3, including address validation, Ether conversion, and PIN code generation.

```csharp
// Example 1: Validate an Ethereum address
string address = "0x12345...";
bool isValidAddress = address.IsValidEthereumAddress(); // Returns true or false

// Example 2: Convert Wei to Ether
BigInteger wei = BigInteger.Parse("1000000000000000000"); // 1 Ether in Wei
double ether = Web3Utils.ToEther(wei); // Returns 1.0

// Example 3: Generate a random PIN code
string pin = Web3Utils.GeneratePin(6); // Returns a 6-digit PIN code
```

## DbService

Provides utility functions for working with databases, including connection validation and data export.

```csharp
// Example 1: Validate a connection string
string connectionString = "Data Source=localhost;Initial Catalog=MyDatabase;Integrated Security=True";
bool isValid = DbService.IsValidConnectionString(connectionString); // Returns true or false

// Example 2: Export a table to a CSV file
string tableName = "MyTable";
string filePath = "C:\\MyTable.csv";
bool exported = DbService.ExportTableToCsv(connectionString, tableName, filePath); // Returns true or false
```

## Password Generation

Provides utility functions for generating passwords using `PasswordBuilder` and `PasswordConfiguration`.

```csharp
// Example 1: Generate a password with default settings
PasswordBuilder builder = new PasswordBuilder();
string password = builder.Generate(); // Returns a password with default settings (lowercase, uppercase, numbers, symbols, length 12)

// Example 2: Generate a password with custom settings
PasswordConfiguration config = new PasswordConfiguration(true, false, true, false, 16, 100); // lowercase, no uppercase, numbers, no symbols, length 16
PasswordBuilder builder2 = new PasswordBuilder(config);
string password2 = builder2.Generate(); // Returns a password with custom settings

// Example 3: Generate a password with custom symbols
PasswordBuilder builder3 = new PasswordBuilder();
builder3.WithCustomSymbols("!@#");
string password3 = builder3.Generate(); // Returns a password with custom symbols
```

## Contributing

We'd love for you to contribute to Utills-Nuget! Got a cool extension method idea? Found a bug? Submit a pull request and help us make Utills-Nuget even better!

## License

This project is licensed under the [MIT License](LICENSE).
