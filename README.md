# ⚽ Sports Competition DBMS (EPL)

## 📌 Project Overview

This project is a **Database Management System (DBMS)** designed to manage and organize data for a sports competition, specifically modeled around the **English Premier League (EPL)**.

The system serves as a centralized platform to handle:

* Teams and players
* Matches and results
* Referees and stadiums
* Performance statistics (team & player level)
  
---

## 🏗️ Tech Stack

* **Language:** C#
* **Framework:** WinForms (.NET)
* **Database:** SQL Server
* **Data Access:** ADO.NET
* **IDE:** Visual Studio

---

## 🗄️ Database Setup

### 🔹 Restore the Database

1. Open **SQL Server Management Studio (SSMS)**
2. Right-click **Databases → Restore Database**
3. Choose **Device → Add**
4. Select the provided `.bak` file
5. Set a database name (e.g., `EPL`)
6. Click **OK**

---

## 📁 Project Structure

```
/EPL
│
├── /Forms           # UI forms (WinForms)
├── /Models          # C# classes representing DB tables
├── /DataAccess      # Database connection & queries
├── /Utils           # Helper functions
│
├── App.config       # Connection string
├── Program.cs       # Entry point
└── README.md
```

---

## 🧠 Database Schema (Summary)

Main entities:

* **Teams**
* **Players**
* **Matches**
* **Referees**
* **Stadiums**
* **Managers**

Associative entities:

* **Player_Stats**
* **Team_Stats**
* **Manager_Previous_Team**

Relationships:

* 1:N → Teams → Players
* M:N → Players ↔ Matches (via Player_Stats)
* M:N → Teams ↔ Matches (via Team_Stats)
* 1:1 → Teams ↔ Managers

---

## 🪟 Application Features

### ✅ Forms (UI)

* Main Dashboard (Navigation)
* Team Management
* Player Management
* Match Management
* Statistics Viewer

### ✅ Functionalities

* **SELECT** → View data in tables
* **INSERT** → Add new records
* **UPDATE** → Modify existing data
* **DELETE** → Remove records

---

## 🔌 Database Connection

Connection string is stored in `App.config`:

```xml
<connectionStrings>
  <add name="DBConnection"
       connectionString="Data Source=.;Initial Catalog=EPL;Integrated Security=True"/>
</connectionStrings>
```

---

## ▶️ How to Run

1. Restore the database (.bak file)
2. Open the solution in Visual Studio
3. Update connection string if needed
4. Build and run the project
5. Start from **MainForm**

---

## 🎯 Future Improvements

* Search & filtering
* Advanced statistics dashboard
* Better UI/UX design
* Role-based access (admin/user)
* Charts & visual analytics

This project is for educational purposes.
