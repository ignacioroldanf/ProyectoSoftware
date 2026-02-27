USE master;
GO

-- Declaración de variables
DECLARE @NombreDB VARCHAR(50) = 'Diploma';
DECLARE @RutaSeguridad VARCHAR(255) = 'C:\Backups\';
DECLARE @FechaHora VARCHAR(20);
DECLARE @NombreArchivo VARCHAR(255);

-- Formato de fecha y hora
SET @FechaHora = FORMAT(GETDATE(), 'yyyyMMdd_HHmmss');

-- Nombre final
SET @NombreArchivo = @RutaSeguridad + @NombreDB + '_' + @FechaHora + '.bak';


-- LIMPIEZA DE LOGS

EXEC('ALTER DATABASE ' + @NombreDB + ' SET RECOVERY SIMPLE;');

EXEC('USE [' + @NombreDB + ']; DBCC SHRINKFILE (''Diploma_log'', 1);');

EXEC('ALTER DATABASE ' + @NombreDB + ' SET RECOVERY FULL;');


-- CREACIÓN DEL BACKUP COMPLETO
BACKUP DATABASE Diploma
TO DISK = @NombreArchivo
WITH FORMAT, 
     INIT, 
     NAME = 'Copia de Seguridad Completa de SAG', 
     SKIP, 
     NOREWIND, 
     NOUNLOAD, 
     STATS = 10;

PRINT 'Backup generado exitosamente en: ' + @NombreArchivo;
GO