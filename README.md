# RSGymPT_v2

A back-end application for managing clients and users for RSGym's new personal trainer at-home service.

## 🔧 Technologies

- ASP.NET Core 6 (MVC)
- PostgreSQL (with Entity Framework Core)
- .NET Console App for user administration
- C# (.NET 9 SDK on macOS)
- Razor Views + CSS for UI
- Manual EF Core Migrations (Model-First approach)

## 📁 Project Structure

- `RSGymPT.Clients/` – Web module for managing clients and payments.
- `RSGymPT.UsersConsole/` – Console module for managing app users.
- `RSGymPT.Utils/` – Shared utility library.

## 📝 Features

### Client Management (Web)

- Register new clients
- Track and categorize subscriptions (monthly, single-use)
- Handle payments with or without loyalty discounts
- Razor views and styled index pages

### User Administration (Console)

- Create and manage users
- Role-based access (admin, power user, simple user)
- Colored menus and user context
- In-memory data with LINQ (no database)

## 📌 Notes

- PostgreSQL is used as a replacement for SQL Server (for macOS compatibility).
- The project follows a **model-first** approach with manual EF migrations.
- No Docker or Azure used (due to platform limitations).

## 🚀 Getting Started

Make sure you have:
- .NET 9 SDK
- PostgreSQL installed and running
- `dotnet-ef` CLI installed

Clone the repo and run:
```bash
dotnet restore
