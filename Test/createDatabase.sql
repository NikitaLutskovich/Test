-- Проверяем, существует ли база данных 

IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'DatabaseName')
BEGIN
    -- Создаем новую базу данных
    CREATE DATABASE DatabaseName;
    PRINT 'Database DatabaseName created successfully.';
END
ELSE
BEGIN
    PRINT 'Database DatabaseName already exists.';
END

