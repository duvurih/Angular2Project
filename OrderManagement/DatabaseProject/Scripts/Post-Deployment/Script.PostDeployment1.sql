/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:r .\dbo.Categories.Table.sql
GO

:r .\dbo.Customers.Table.sql
GO

:r .\dbo.Suppliers.Table.sql
GO

:r .\dbo.Products.Table.sql
GO


:r .\dbo.Orders.Table.sql
GO

:r ".\dbo.Order Details.Table.sql"
GO

print 'Post Deployment Scripts Executed!...'
