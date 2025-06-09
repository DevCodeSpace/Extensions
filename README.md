# Extensions

**Extensions** is your comprehensive toolkit for .NET development, offering a rich collection of extension methods and utility functions designed to streamline your coding experience. Whether you're manipulating strings, working with dates, generating secure passwords, or handling Web3 operations, Utills-Nuget provides the tools you need to write cleaner, more efficient code.

![Plugin Banners](https://raw.githubusercontent.com/DevCodeSpace/.NetSocketHandler/refs/heads/main/assets/banner.jpg)

## ✨ Key Features

◆ 🎨 **Color manipulation and conversion utilities** <br>
◆ 📅 **Advanced date comparison and validation** <br>
◆ 📁 **File operations with async support** <br>
◆ 🔢 **Extended integer and numeric operations** <br>
◆ 📝 **Comprehensive string validation and manipulation** <br>
◆ 🌐 **Web3 utilities for blockchain development** <br>
◆ 🗄️ **Database connection and export utilities** <br>
◆ 🔐 **Secure password generation with customizable options**

## Table of Contents

- [Installation](#installation)
- [Quick Start](#quick-start)
- [API Reference](#api-reference)
  - [ColorExtensions](#colorextensions)
  - [DateComparisonExtensions](#datecomparisonextensions)
  - [FileExtensions](#fileextensions)
  - [IntExtension](#intextension)
  - [NumExtension](#numextension)
  - [StringExtensions](#stringextensions)
  - [Web3Utils](#web3utils)
  - [DbService](#dbservice)
  - [Password Generation](#password-generation)
- [Requirements](#requirements)
- [Contributing](#contributing)
- [License](#license)
- [Changelog](#changelog)

## Installation

### Package Manager Console
```powershell
Install-Package Utills
```

### .NET CLI
```bash
dotnet add package Utills
```

### PackageReference
```xml
<PackageReference Include="Utills" Version="x.x.x" />
```

## Quick Start

Once installed, import the `Utills` namespace to access all extension methods and utilities:

```csharp
using Utills;

// Example: String validation
string email = "user@example.com";
bool isValid = email.IsValidEmail(); // Returns true

// Example: Date operations
DateTime today = DateTime.Now;
bool isToday = today.IsToday(); // Returns true

// Example: Number operations
int number = 42;
bool isEven = number.IsEven(); // Returns true
```

## API Reference

### ColorExtensions

Work with colors effortlessly using these extension methods for color manipulation and conversion.

#### Methods

| Method | Description | Example |
|--------|-------------|---------|
| `ToHex()` | Convert color to hexadecimal | `Color.Red.ToHex()` → `"#FFFF0000"` |
| `Shade(int value)` | Create darker shade | `Color.Blue.Shade(200)` |
| `IsLight()` | Check if color is light | `Color.Yellow.IsLight()` → `true` |
| `TweenTo(Color, double)` | Interpolate between colors | `Color.Red.TweenTo(Color.Blue, 0.5)` |

```csharp
// Convert a color to its hexadecimal representation
string hexColor = Color.Red.ToHex(); // "#FFFF0000"

// Create a darker shade of blue
Color shadedColor = Color.Blue.Shade(200); 

// Check if a color is light
bool isLight = Color.Yellow.IsLight(); // true

// Interpolate between two colors
Color tweenColor = Color.Red.TweenTo(Color.Blue, 0.5);
```

### DateComparisonExtensions

Simplify date comparisons and manipulations with these convenient extension methods.

#### Methods

| Method | Description | Example |
|--------|-------------|---------|
| `IsBetween(DateTime, DateTime)` | Check if date is within range | `date.IsBetween(start, end)` |
| `IsToday()` | Check if date is today | `DateTime.Now.IsToday()` |
| `DateOnly()` | Get date without time | `DateTime.Now.DateOnly()` |
| `IsPast()` | Check if date is in the past | `someDate.IsPast()` |

```csharp
DateTime date = DateTime.Now;
DateTime startDate = DateTime.Now.AddDays(-1);
DateTime endDate = DateTime.Now.AddDays(1);

// Check if date is within range
bool isInRange = date.IsBetween(startDate, endDate); // true

// Check if date is today
bool isToday = DateTime.Now.IsToday(); // true

// Get date only (time set to 00:00:00)
DateTime dateOnly = DateTime.Now.DateOnly();

// Check if date is in the past
bool isPast = DateTime.Now.AddDays(-1).IsPast(); // true
```

### FileExtensions

Handle file operations with ease using these asynchronous file extension methods.

#### Methods

| Method | Description | Example |
|--------|-------------|---------|
| `GetMimeType()` | Get file MIME type | `"file.txt".GetMimeType()` |
| `ClearAsync()` | Clear file content | `await file.ClearAsync()` |
| `AppendStringAsync(string)` | Append text to file | `await file.AppendStringAsync(text)` |

```csharp
// Get MIME type of a file
string mimeType = "example.txt".GetMimeType(); // "text/plain"

// Clear file content asynchronously
FileInfo file = new FileInfo("example.txt");
await file.ClearAsync();

// Append text to file asynchronously
await file.AppendStringAsync("This is some text to append.");
```

### IntExtension

Extend integer functionality with mathematical operations and conversions.

#### Methods

| Method | Description | Example |
|--------|-------------|---------|
| `IsEven()` | Check if number is even | `4.IsEven()` → `true` |
| `Seconds()` | Convert to TimeSpan seconds | `10.Seconds()` |
| `RangeTo(int)` | Generate integer range | `1.RangeTo(5)` |
| `Digits()` | Get individual digits | `12345.Digits()` |

```csharp
// Check if integer is even
bool isEven = 4.IsEven(); // true

// Convert integer to TimeSpan (seconds)
TimeSpan time = 10.Seconds(); // TimeSpan of 10 seconds

// Generate range of integers
IEnumerable<int> range = 1.RangeTo(5); // [1, 2, 3, 4, 5]

// Get digits of an integer
List<int> digits = 12345.Digits(); // [1, 2, 3, 4, 5]
```

### NumExtension

Advanced numeric operations including clamping, rounding, and unit conversions.

#### Methods

| Method | Description | Example |
|--------|-------------|---------|
| `Clamp(T, T)` | Clamp value within range | `150.Clamp(0, 100)` → `100` |
| `RoundToDecimals(int)` | Round to decimal places | `3.14159.RoundToDecimals(2)` |
| `AsRadians()` | Convert degrees to radians | `180.0.AsRadians()` |
| `IsBetween(T, T)` | Check if value is between bounds | `5.0.IsBetween(2.0, 8.0)` |

```csharp
// Clamp number within range
decimal clampedValue = 150m.Clamp(0m, 100m); // 100

// Round to specific decimal places
double roundedValue = 3.14159.RoundToDecimals(2); // 3.14

// Convert degrees to radians
double radians = 180.0.AsRadians(); // π (3.141592653589793)

// Check if number is between values
bool isBetween = 5.0.IsBetween(2.0, 8.0); // true
```

### StringExtensions

Comprehensive string validation, formatting, and manipulation utilities.

#### Methods

| Method | Description | Example |
|--------|-------------|---------|
| `IsValidEmail()` | Validate email format | `"user@domain.com".IsValidEmail()` |
| `Capitalize()` | Capitalize first letter | `"hello".Capitalize()` → `"Hello"` |
| `Reverse()` | Reverse string | `"hello".Reverse()` → `"olleh"` |
| `IsPalindrome()` | Check if palindrome | `"madam".IsPalindrome()` → `true` |

```csharp
// Validate email address
bool isValidEmail = "test@example.com".IsValidEmail(); // true

// Capitalize first letter
string capitalizedString = "hello".Capitalize(); // "Hello"

// Reverse string
string reversedString = "hello".Reverse(); // "olleh"

// Check if string is palindrome
bool isPalindrome = "madam".IsPalindrome(); // true
```

### Web3Utils

Blockchain and Web3 development utilities for Ethereum and cryptocurrency operations.

#### Methods

| Method | Description | Example |
|--------|-------------|---------|
| `IsValidEthereumAddress()` | Validate Ethereum address | `address.IsValidEthereumAddress()` |
| `ToEther(BigInteger)` | Convert Wei to Ether | `Web3Utils.ToEther(wei)` |
| `GeneratePin(int)` | Generate PIN code | `Web3Utils.GeneratePin(6)` |

```csharp
// Validate Ethereum address
string address = "0x742d35Cc6634C0532925a3b8D20b2C06e0C2D446";
bool isValidAddress = address.IsValidEthereumAddress(); // true

// Convert Wei to Ether
BigInteger wei = BigInteger.Parse("1000000000000000000"); // 1 Ether in Wei
double ether = Web3Utils.ToEther(wei); // 1.0

// Generate random PIN code
string pin = Web3Utils.GeneratePin(6); // "123456" (random)
```

### DbService

Database utility functions for connection validation and data export operations.

#### Methods

| Method | Description | Return Type |
|--------|-------------|-------------|
| `IsValidConnectionString(string)` | Validate connection string | `bool` |
| `ExportTableToCsv(string, string, string)` | Export table to CSV | `bool` |

```csharp
// Validate connection string
string connectionString = "Data Source=localhost;Initial Catalog=MyDatabase;Integrated Security=True";
bool isValid = DbService.IsValidConnectionString(connectionString);

// Export table to CSV file
string tableName = "Users";
string filePath = @"C:\exports\users.csv";
bool exported = DbService.ExportTableToCsv(connectionString, tableName, filePath);
```

### Password Generation

Secure password generation with customizable complexity and character sets.

#### PasswordBuilder Class

```csharp
// Generate password with default settings
PasswordBuilder builder = new PasswordBuilder();
string password = builder.Generate(); // 12-character password

// Generate password with custom configuration
PasswordConfiguration config = new PasswordConfiguration(
    includeLowercase: true,
    includeUppercase: false, 
    includeNumbers: true,
    includeSymbols: false,
    length: 16,
    maxLength: 100
);
PasswordBuilder customBuilder = new PasswordBuilder(config);
string customPassword = customBuilder.Generate();

// Generate password with custom symbols
PasswordBuilder symbolBuilder = new PasswordBuilder();
symbolBuilder.WithCustomSymbols("!@#$%");
string symbolPassword = symbolBuilder.Generate();
```

#### PasswordConfiguration Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `IncludeLowercase` | `bool` | `true` | Include lowercase letters |
| `IncludeUppercase` | `bool` | `true` | Include uppercase letters |
| `IncludeNumbers` | `bool` | `true` | Include numeric digits |
| `IncludeSymbols` | `bool` | `true` | Include special symbols |
| `Length` | `int` | `12` | Password length |
| `MaxLength` | `int` | `128` | Maximum allowed length |

## Requirements

- **.NET Standard 2.0** or higher
- **.NET Framework 4.6.1** or higher  
- **.NET Core 2.0** or higher
- **.NET 5.0** or higher

## Code Contributors

![Plugin Banners](https://raw.githubusercontent.com/DevCodeSpace/.NetSocketHandler/refs/heads/main/assets/contributors.png)

⭐ **Star this repository if Extensions helped your project!**

---

<div align="center">
  <p>Made with DevCodeSpace ❤️</p>
  <p>
    <a href="https://github.com/yourusername/utills-nuget">GitHub Repository</a> •
    <a href="https://github.com/yourusername/utills-nuget/issues">Report Bug</a>
  </p>
</div>