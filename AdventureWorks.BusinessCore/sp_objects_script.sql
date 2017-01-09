USE AdventureWorks2012

GO

IF ( OBJECT_ID('dbo.usp_Shift_SelectAll') IS NOT NULL ) 
   DROP PROCEDURE dbo.usp_Shift_SelectAll
GO

CREATE PROCEDURE dbo.usp_Shift_SelectAll        
AS
BEGIN 
     SET NOCOUNT ON 

     SELECT 
            ShiftID                   ,
            Name                     ,
            StartTime                    ,
            EndTime            
     FROM   HumanResources.Shift (NOLOCK) 

END 

GO

IF ( OBJECT_ID('dbo.usp_Employee_SelectAll') IS NOT NULL ) 
   DROP PROCEDURE dbo.usp_Employee_SelectAll
GO

CREATE PROCEDURE dbo.usp_Employee_SelectAll        
AS
BEGIN 
     SET NOCOUNT ON 

     SELECT 
            BusinessEntityID,
			NationalIDNumber,
			LoginID,	
			JobTitle,
			BirthDate,
			MaritalStatus,
			Gender,
			HireDate           
     FROM   HumanResources.Employee (NOLOCK) 

END 

GO

