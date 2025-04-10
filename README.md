# Practical 13: Employee Database Application

This document provides setup instructions for Practical 13, focusing on database configuration and initialization.

## Prerequisites

### Database Setup

```sql
CREATE DATABASE EmployeeManagement
USE EmployeeManagement
```

### Connection String Configuration

Add the following connection string to your `web.config` file:

```xml
<connectionStrings>
<add name="EmployeeDB"
connectionString="Data Source=DESKTOP-G05APNP\SQLEXPRESS;Initial Catalog=EmployeeManagement;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"
providerName="System.Data.SqlClient" />
</connectionStrings>
```

> **Note:** Modify the connection string according to your SQL Server configuration if needed.

## Database Migration

For each project, you need to apply the migrations to create the database schema:

1. Open the Package Manager Console (Tools > NuGet Package Manager > Package Manager Console)
2. Select the appropriate project in the "Default project" dropdown
3. Run the following command:
   ```
   Update-Database
   ```

This command will apply all pending migrations and create the necessary tables in your EmployeeManagement database.
