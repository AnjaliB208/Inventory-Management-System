# Inventory-Management-System
Inventory Management System built using .NET Framework and Windows Forms. Features admin login, product and dealer management, purchase/sales tracking, stock updates, and detailed reports. Implements SQL Server backend with a clean UI and error validation.

A Windows Forms-based Inventory Management System developed using the .NET Framework and Microsoft SQL Server. It provides a comprehensive solution for managing products, dealers, purchases, sales, stock levels, and report generation. This project was developed as a case study for academic purposes.

## 👨‍💻 Team Members
- Anjali Biju (20BSIT056)  
- Mit Vyas (20BSIT071)  
- Nidhi Khatri (20BSIT094)

## 📌 Features

- **Admin Login** – Authenticated access to system features
- **Product Management** – Add, edit, delete product entries
- **Stock Management** – Auto-update stock levels on purchase and sale
- **Dealer Management** – Maintain dealer contact and company details
- **Purchase & Sales Modules** – Track transactions with auto-calculations
- **Unit Management** – Define and update product units (kg, gram, etc.)
- **Comprehensive Reports** – Generate reports on purchases, sales, and stock
- **Input Validation** – Ensures accurate and required data entry

## 🗂️ Technologies Used

- C#
- .NET Framework (WinForms)
- Microsoft SQL Server
- Windows Forms (MDI architecture)

## 🗃️ Database Overview

Database: `Inventory_Database.mdf`

Includes tables:
- `User_detail` – Admin login details
- `Product_name`, `Units`, `Stock` – Product and inventory
- `Dealer_info` – Dealer records
- `Purchase_master` – Purchase records
- `Order_user`, `Order_item` – Sales transactions

## 🛠️ Setup Instructions

1. Clone this repo.
2. Open the solution file in Visual Studio.
3. Ensure SQL Server is installed.
4. Attach the provided `Inventory_Database.mdf` file to your SQL Server.
5. Update the connection string in `Login_Form.cs` and other files if needed.
6. Run the project.

## 📊 Report Types

- **Purchase Report** – Filter by date range
- **Sales Report** – Filter by payment type
- **Stock Report** – Real-time inventory overview

## 🧾 Documentation

Detailed case study and documentation are available in the `/docs` or `/paper` folder.

## 📄 License

This project is intended for academic and educational use.

---

> ✅ *For a live walkthrough, screenshots, or enhancements, feel free to fork and contribute.*

