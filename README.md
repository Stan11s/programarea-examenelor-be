## Setting Up the SQL Server Database

This guide outlines the steps to create and populate an SQL Server database for use in an ASP.NET Core application, with migrations and an SQL script for data population.

---

### **1. Install SQL Server and Management Tools**
1. **Download and Install SQL Server**
   - Get SQL Server from the [official download page](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).
   - Choose the **Developer** or **Express** edition.
   - Install using the **Basic Installation** option and follow the setup prompts.

2. **Install SQL Server Management Studio (SSMS)**
   - Download SSMS from [here](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms).
   - Install SSMS to manage and interact with your database.

---

### **2. Create the Database**
1. **Create a Database in SSMS**
   - Launch SSMS and connect to your SQL Server instance.
   - In the **Object Explorer**, right-click **Databases** > **New Database**.
   - Enter a database name (e.g., `MyDatabase`) and click **OK**.

---

### **3. Run Migrations in ASP.NET Core**
1. **Install EF Core Tools**
   - Ensure `dotnet-ef` is installed globally:
     ```bash
     dotnet tool install --global dotnet-ef
     ```

2. **Add and Apply a Migration**
   - In your ASP.NET Core project directory, run:
     ```bash
     dotnet ef migrations add InitialCreate
     dotnet ef database update
     ```
   - This will apply your EF Core migration and create the database schema based on your `DbContext` and models.

---

### **4. Populate the Database**
1. **Prepare the Data Script**  
   - Use a SQL script file (e.g., `data.sql`) containing the necessary data for initial population.

2. **Import the Script into the Database**  
   - Open SSMS, connect to your database, and import the `data.sql` file to populate the database with the required records.

3. **Execute the Data Import**  
   - Ensure the `data.sql` script runs successfully, adding the initial data to the appropriate tables.

4. **Validate the Data**  
   - After importing, confirm that the data has been successfully added by inspecting the tables directly in SSMS.
