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

IF ( OBJECT_ID('dbo.usp_Employee_SelectSingle') IS NOT NULL ) 
   DROP PROCEDURE dbo.usp_Employee_SelectSingle
GO

CREATE PROCEDURE dbo.usp_Employee_SelectSingle        
(@employeeID int)
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
     WHERE BusinessEntityID = @employeeID

END
GO

IF ( OBJECT_ID('dbo.usp_Employee_Update') IS NOT NULL ) 
   DROP PROCEDURE dbo.usp_Employee_Update
GO

CREATE PROCEDURE dbo.usp_Employee_Update
       @businessEntityID INT,
	   @nationalIDNumber INT,
	   @loginID varchar(255),
	   @jobTitle varchar(255),
	   @birthDate datetime,
	   @maritalStatus char,
	   @gender char,
	   @hireDate
  AS
BEGIN
     UPDATE HumanResources.Employee 
     SET 
			BusinessEntityID = @businessEntityID,
			NationalIDNumber = @nationalIDNumber,
			LoginID = @loginID,	
			JobTitle = @jobTitle,
			BirthDate = @birthDate,
			MaritalStatus = @maritalStatus,
			Gender = @gender,
			HireDate = @hiredate  
     WHERE BusinessEntityID = @businessEntityID
END
GO

