# ⚽ English Premier League (EPL) Database Management System

## 📌 Project Overview
This project is a robust, desktop-based **Database Management System (DBMS)** designed to manage and organize comprehensive data for a sports competition modeled around the **English Premier League (EPL)**. 

Moving beyond basic CRUD operations, this system serves as a centralized platform to handle complex relational data, including team standings, player performance, injury reports, managerial histories, and match scheduling.

---

## 🏗️ Tech Stack & Architecture
* **Language:** C# 
* **Framework:** WinForms (.NET Framework 4.7.2)
* **Database:** Microsoft SQL Server
* **Data Access:** ADO.NET using **Stored Procedures** (for enhanced security and execution plan caching).
* **Architecture:** N-Tier architecture utilizing the **Repository Pattern** and **ViewModels** to separate database logic from UI components.

---

## 📁 Project Structure
```text
/EPL
│
├── /Forms           # UI forms with modern styling (Main Dashboard, Management, Stats)
├── /Models          # Domain entities mirroring database tables
├── /ViewModels      # Data Transfer Objects for mapping foreign keys to readable strings
├── /DataAccess      # Repository layer interacting with SQL Stored Procedures
├── /Utils           # Helper classes (e.g., DatabaseHelper, UIHelper for unified styling)
├── /Scripts         # SQL schema and Stored Procedure generation scripts
│
├── App.config       # SQL Server Connection string configuration
└── Program.cs       # Application Entry point

```

---

## 🧠 Database Schema Highlights

The relational database is highly normalized and comprises 10 primary tables:

* **Core Entities:** `Teams`, `Players`, `Matches`, `Referees`, `Stadiums`, `Managers`
* **Associative/Tracking Entities:** `Player_Stats`, `Team_Stats`, `Player_Injuries`, `Manager_Previous_Teams`

**Key Relationships:**

* `1:N` — Teams to Players / Teams to Managers
* `M:N` — Players to Matches (tracked via `Player_Stats`)
* `M:N` — Teams to Matches (tracked via `Team_Stats`)

---

## 🪟 Application Features

### 📊 Comprehensive UI Dashboards (11 Forms)

* **Main Navigation Hub:** Dynamic dashboard tracking live total counts for Teams, Players, and Matches.
* **Management Suite:** Full CRUD interfaces for Players, Teams, Matches, Managers, Stadiums, and Referees.
* **Statistical Reports Suite:**
* **League Standings:** Calculates points, possession, and shots across the season.
* **Top Performers:** Aggregates Golden Boot/Playmaker stats (Goals, Assists, Minutes).
* **Injury Reports:** Tracks player availability and total days out.
* **Managerial Career History:** Dynamic grids showing historical clubs managed.



### ⚙️ Advanced Functionalities

* **Search & Filtering:** Retrieve specific records via ID or dynamically populated dropdowns.
* **UI/UX Polish:** Centralized `UIHelper` for consistent color palettes, placeholder text, flat styling, and dynamic grid auto-sizing.
* **Memory Safety:** Implementation of `using` blocks and secure form-navigation handling to prevent memory leaks.
* **SQL Injection Protection:** 100% of database interactions are routed through parameterized Stored Procedures.

---

## ▶️ How to Run

1. **Setup the Database:**
* Open **SQL Server Management Studio (SSMS)**.
* Create a new database named `EPL`.
* Open and execute the `database.sql` script to create the tables and seed initial data.
* Open and execute the `storedProcedures.sql` script to generate the required backend logic.


2. **Configure the Application:**
* Open the solution in Visual Studio.
* Open `App.config` and update the `Data Source` in the connection string to match your local SQL Server instance name.


3. **Run:**
* Build the solution and click **Start**. The application will launch from the `MainForm` dashboard.



---

## 🎯 Future Enhancements

While the current system covers advanced data management, future iterations could explore:

* **Data Exporting:** Add functionality to export league standings and statistical reports to PDF, Excel, or CSV formats.
* **Role-Based Access Control (RBAC):** Implement login screens to separate "Admin" privileges (Insert/Update/Delete) from "Guest/Fan" privileges (Read-Only statistics viewing).
* **ORM Migration:** Upgrade the data access layer from pure ADO.NET to **Entity Framework Core** for database-agnostic operations.
* **Visual Analytics:** Integrate charting libraries (like LiveCharts) to visually graph team possession trends or player goal distributions over time.
* **API Integration:** Migrate the backend to a RESTful Web API (.NET Core) to allow mobile apps or web frontends to consume the EPL data.
