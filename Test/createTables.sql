-- »спользуем созданную базу данных
USE DatabaseName;

-- —оздаем таблицу дл€ организаций, если ее еще не существует
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Organizations')
BEGIN
    CREATE TABLE Organizations
    (
        OrganizationID INT PRIMARY KEY IDENTITY(1,1),
        Name NVARCHAR(255) NOT NULL,
        TIN NVARCHAR(255) NOT NULL,
        ActualAddress NVARCHAR(255) NOT NULL,
        LegalAddress NVARCHAR(255) NOT NULL
    );

    PRINT 'Table Organizations created successfully.';
END
ELSE
BEGIN
    PRINT 'Table Organizations already exists.';
END

-- —оздаем таблицу дл€ сотрудников, если ее еще не существует
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Employees')
BEGIN
    CREATE TABLE Employees
    (
        EmployeeID INT PRIMARY KEY IDENTITY(1,1),
        OrganizationName NVARCHAR(255) NOT NULL,
        Surname NVARCHAR(255) NOT NULL,
        Name NVARCHAR(255) NOT NULL,
        Patronymic NVARCHAR(255) NOT NULL,
        Birthday DATETIME NOT NULL,
        PassportSeries NVARCHAR(255) NOT NULL,
        PassportNumber NVARCHAR(255) NOT NULL
       
    );

    PRINT 'Table Employees created successfully.';
END
ELSE
BEGIN
    PRINT 'Table Employees already exists.';
END