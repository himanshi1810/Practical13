# Practical 13
# DataBase Connection Setup
In this practical I use Code First Approach

**Step 1 : Add your Data source in connection String in web.config file** 
```csharp
<connectionStrings>
<add name="EmployeeDB"
connectionString="Data Source=DESKTOP-G05APNP\SQLEXPRESS;Initial Catalog=EmployeeManagement;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"
providerName="System.Data.SqlClient" />
</connectionStrings>
```
**Step 2 : In package manager console write below command to reflect in your database**
```csharp
Update-Database
```
