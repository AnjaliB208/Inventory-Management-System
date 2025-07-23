# Inventory-Management-System

This Inventory Management System is a desktop application built using the .NET Framework with a Windows Forms front end and a SQL Server backend. It provides a complete solution for managing products, dealers, stock levels, purchases, and sales. Key features include secure admin login, real-time stock tracking, transaction recording, and detailed reporting. The system was developed as part of an academic case study, with a focus on usability, data accuracy, and clean interface design.

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

Detailed case study and documentation are available in the `/docs` folder.

## 📄 License

This project is intended for academic and educational use.

---

> ✅ *For a live walkthrough, screenshots, or enhancements, feel free to fork and contribute.*

