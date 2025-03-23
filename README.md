# Minimal API with ASP.NET Core - Safe Storage of App Secrets

This project demonstrates how to securely read **app secrets** using **ASP.NET Core Minimal API**. It uses the local **User Secrets** manager for storing sensitive information during development, following Microsoft's recommended approach.

## 📋 Project Overview

- **Language**: C# (.NET 9.0 or later)
- **Purpose**: Safely store and access development secrets (e.g., API keys) without hardcoding them.
- **Feature**: Reads a secret (`ServiceApiKey`) from the local secrets manager and exposes it via a `/reveal-secret` endpoint.

## 📂 Project Structure

```
├── Program.cs
└── README.md
```

## 🛠️ Prerequisites

Ensure the following are installed on your system:

- .NET 9.0 SDK or later: [Download .NET](https://dotnet.microsoft.com/download)

## 📜 Code Explanation

`Program.cs`:

```csharp
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/reveal-secret", (IConfiguration config) =>
{
    var apiKey = config["ServiceApiKey"];
    return apiKey ?? "Secret not found";
});

app.Run();
```

This minimal API reads the `ServiceApiKey` from the **User Secrets** and returns it when you call the `/reveal-secret` endpoint.

## 🔐 Managing Secrets

1. **Initialize User Secrets**

Run this command in the project root to enable **User Secrets**:

```bash
    dotnet user-secrets init
```

2. **Add a Secret**

Store the `ServiceApiKey` securely using the following command:

```bash
    dotnet user-secrets set "ServiceApiKey" "YourSuperSecretKey"
```

3. **Location of Secrets**

On Windows, secrets are stored in:

```
%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json
```

On Linux/macOS:

```
$HOME/.microsoft/usersecrets/<user_secrets_id>/secrets.json
```

Example `secrets.json` file:

```json
{
  "ServiceApiKey": "YourSuperSecretKey"
}
```

> **Note:** The `user_secrets_id` is defined in the `.csproj` file after initialization.

## ▶️ Running the Application

1. Build and run the API:

```bash
    dotnet run
```

2. Access the secret by calling the endpoint:

```bash
    curl https://localhost:5001/reveal-secret
```

Expected output:

```
YourSuperSecretKey
```

## 📚 References

- Official Documentation: [Safe storage of app secrets in development in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=windows)

## 🧹 Cleaning Up

To remove the stored secret:

```bash
    dotnet user-secrets remove "ServiceApiKey"
```

Or to clear all secrets:

```bash
    dotnet user-secrets clear
```

## 📌 Notes

- **Do not** store secrets in `appsettings.json` for production.
- Use **Azure Key Vault** or other secure stores for production environments.

## License
[![MIT License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

This project is licensed under the MIT License. See the [`LICENSE`](LICENSE) file for details.