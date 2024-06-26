/*

db_upgrade.sql

author: Sutherland Nele
date: 24th October 2018
purpose: DB Changes. Backup database copy and run on current prod database when doing uat or going 
	     live with the upgraded system 

*/
--1. Drop FK (FK_Vehicle_Vehicle) on MstVehicle table that refers to itself

ALTER TABLE [dbo].[MstVehicle] DROP CONSTRAINT [FK_Vehicle_Vehicle]
GO

--2. Drop Duplicate FKs to Center table
ALTER TABLE [dbo].[MstVehicle] DROP CONSTRAINT [FK_Vehicle_Center1]
GO

--3. Rename unused view - User
EXEC sp_rename 'DBO.User', 'OldUser'; --Caution: Changing any part of an object name could break scripts and stored procedures.
GO




/****** 4. BEGIN Create New ASP.Net Identity Tables for the application******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Claim](
    [ClaimId] [int] IDENTITY(1,1) NOT NULL,
    [UserId] [uniqueidentifier] NOT NULL,
    [ClaimType] [nvarchar](max) NULL,
    [ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
    [ClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExternalLogin]    Script Date: 1/12/2015 11:14:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExternalLogin](
    [LoginProvider] [nvarchar](128) NOT NULL,
    [ProviderKey] [nvarchar](128) NOT NULL,
    [UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.ExternalLogin] PRIMARY KEY CLUSTERED 
(
    [LoginProvider] ASC,
    [ProviderKey] ASC,
    [UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 1/12/2015 11:14:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
    [RoleId] [uniqueidentifier] NOT NULL,
    [Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.Role] PRIMARY KEY CLUSTERED 
(
    [RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 1/12/2015 11:14:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
    [UserId] [uniqueidentifier] NOT NULL,
    [Email] [nvarchar](128) NULL,
    [EmailConfirmed] [bit]  NOT NULL,
    [PasswordHash] [nvarchar](max) NULL,
    [SecurityStamp] [nvarchar](max) NULL,
    [PhoneNumber] [nvarchar](max) NULL,
    [PhoneNumberConfirmed] [bit]  NOT NULL,
    [TwoFactorEnabled] [bit]  NOT NULL,
    [LockoutEndDateUtc] [datetime] NULL,
    [LockoutEnabled] [bit]  NOT NULL,
    [AccessFailedCount] [int] NOT NULL,
    [UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
    [UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 1/12/2015 11:14:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
    [UserId] [uniqueidentifier] NOT NULL,
    [RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.UserRole] PRIMARY KEY CLUSTERED 
(
    [UserId] ASC,
    [RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Claim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserClaim_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Claim] CHECK CONSTRAINT [FK_dbo.UserClaim_dbo.User_UserId]
GO
ALTER TABLE [dbo].[ExternalLogin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserLogin_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExternalLogin] CHECK CONSTRAINT [FK_dbo.UserLogin_dbo.User_UserId]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRole_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_dbo.UserRole_dbo.User_UserId]
GO

/****** END Create New ASP.Net Identity Tables for the application******/


/****** 6. Add-Hoc DMLs - Part of EF 6 Migrations ******/
INSERT INTO [dbo].[MstSystemParameterCode]
           ([ParameterCode])
     VALUES
           ('InsuranceType')
GO

CREATE INDEX [IX_AcquisitionTypeId] ON [dbo].[MstVehicle]([AcquisitionTypeId])
CREATE INDEX [IX_InsuranceTypeId] ON [dbo].[MstVehicle]([InsuranceTypeId])
ALTER TABLE [dbo].[MstVehicle] ADD CONSTRAINT [FK_dbo.MstVehicle_dbo.MstSystemParameters_AcquisitionTypeId] FOREIGN KEY ([AcquisitionTypeId]) REFERENCES [dbo].[MstSystemParameters] ([Id])
ALTER TABLE [dbo].[MstVehicle] ADD CONSTRAINT [FK_dbo.MstVehicle_dbo.MstSystemParameters_InsuranceTypeId] FOREIGN KEY ([InsuranceTypeId]) REFERENCES [dbo].[MstSystemParameters] ([Id])
DECLARE @var2 nvarchar(128)
SELECT @var2 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.MstVehicle')
AND col_name(parent_object_id, parent_column_id) = 'CurrentAllocationId';
IF @var2 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[MstVehicle] DROP CONSTRAINT [' + @var2 + ']')
ALTER TABLE [dbo].[MstVehicle] DROP COLUMN [CurrentAllocationId]

-- NOTE Importantly: Renaming columns will cause the column to loose all it's existing value

ALTER TABLE [dbo].[User] ADD [LastLoginTime] [datetime]
ALTER TABLE [dbo].[User] ADD [RegistrationDate] [datetime]
ALTER TABLE [dbo].[MstCenter] ADD [MaxVehicleServiceCapacityPerMonth] [int]

--Note !!: confirm with ppl before running below
--update [FleetManagement].[dbo].[MstCenter]
--set MaxVehicleServiceCapacityPerMonth = 10

ALTER TABLE [dbo].[MstService] ADD [ServiceJobNumber] [varchar](12)

--Note: Confirm and run below to update service job # column for existing services
update t1
set t1.ServiceJobNumber = t2.ServiceJobNumber
from [FleetManagement].[dbo].[MstService] as t1
inner join 
	(select Id, (left(s1,5) + right('00' + convert(varchar,jobnum),3) + right(s1,4)) as ServiceJobNumber  from
	(select ID
		,s1
		,startdate 
		,row_number() over (partition by s1 order by startdate asc) as jobnum
	from
	(SELECT id
		  ,'S' + CONVERT(varchar,CenterId) + right('0' + convert(varchar,month([StartDate])),2) + right(convert(varchar,year([StartDate])),2) as S1
		  ,StartDate	    
	  FROM [FleetManagement].[dbo].[MstService]
	  where VehicleId is not null) rs1) rs2) as t2
on t1.Id = t2.Id



--confirm and run code below !! to fix fk intergrity error on makey fueldistributorid fk to contactdetails table

set identity_insert [dbo].[MstContactDetail] on
go

INSERT INTO [dbo].[MstContactDetail]
           (Id
		   ,[ContactName]
           ,[Contacttype]
           ,[ContactPerson]
           ,[PostalAddress]
           ,[StreetAddress]
           ,[Facsimile]
           ,[Email]
           ,[Telephone]
           ,[Fax]
           ,[Website]
           ,[Mobile]
           ,[Comments]
           ,[IsDriver]
           ,[SupplierType]
           ,[DateOfBirth]
           ,[Gender]
           ,[LicenceNumber]
           ,[LicanceClass]
           ,[LicenceExpiryDate]
           ,[PPLPermitNumber]
           ,[CenterId]
           ,[PPLPermitIssueDate])
     VALUES
           (181		   
		   ,'Niugini Oil'
           ,39
           ,''
           ,''
           ,''
           ,''
           ,''
           ,''
           ,''
           ,''
           ,''
            ,''
           ,0
           ,228
           ,NULL
           ,NULL
           ,''
           ,''
           ,NULL
           ,''
           ,NULL
           ,NULL)
GO

set identity_insert [dbo].[MstContactDetail] off
go

update [FleetManagement].[dbo].[MstVehicleRefuel]
set FuelDistributorId = 1056
where [FuelDistributorId] = 180
go

set identity_insert [dbo].[MstContactDetail] on
go
INSERT INTO [dbo].[MstContactDetail]
           (Id
		   ,[ContactName]
           ,[Contacttype]
           ,[ContactPerson]
           ,[PostalAddress]
           ,[StreetAddress]
           ,[Facsimile]
           ,[Email]
           ,[Telephone]
           ,[Fax]
           ,[Website]
           ,[Mobile]
           ,[Comments]
           ,[IsDriver]
           ,[SupplierType]
           ,[DateOfBirth]
           ,[Gender]
           ,[LicenceNumber]
           ,[LicanceClass]
           ,[LicenceExpiryDate]
           ,[PPLPermitNumber]
           ,[CenterId]
           ,[PPLPermitIssueDate])
     VALUES
           (183		   
		   ,'Motor Care (POM)'
           ,39
           ,''
           ,''
           ,''
           ,''
           ,''
           ,''
           ,''
           ,''
           ,''
            ,''
           ,0
           ,228
           ,NULL
           ,NULL
           ,''
           ,''
           ,NULL
           ,''
           ,NULL
           ,NULL)
GO

set identity_insert [dbo].[MstContactDetail] off
go

CREATE INDEX [IX_FuelDistributorId] ON [dbo].[MstVehicleRefuel]([FuelDistributorId])
ALTER TABLE [dbo].[MstVehicleRefuel] ADD CONSTRAINT [FK_dbo.MstVehicleRefuel_dbo.MstContactDetail_FuelDistributorId] FOREIGN KEY ([FuelDistributorId]) REFERENCES [dbo].[MstContactDetail] ([Id])


ALTER TABLE [dbo].[MstVehicleRefuel] ADD [VoucherNumber] [varchar](12)
ALTER TABLE [dbo].[MstVehicleRefuel] ADD [VoucherReceiptNumber] [varchar](50)
ALTER TABLE [dbo].[MstVehicleRefuel] ADD [IsVoucherAcquitted] [bit] NOT NULL DEFAULT 0
ALTER TABLE [dbo].[MstCenter] ADD [MaxVehicleFuelVoucherCapacityPerMonth] [int]

--Note !!: confirm with ppl before running below
update [FleetManagement].[dbo].[MstCenter]
set [MaxVehicleFuelVoucherCapacityPerMonth] = 100

update t1
set t1.VoucherNumber = t2.FuelVoucherNumber,
t1.IsVoucherAcquitted = 1,
t1.VoucherReceiptNumber = '*** Not Available ***'
from [FleetManagement].[dbo].[MstVehicleRefuel] as t1
inner join 
	(select Id, (left(s1,5) + right('00' + convert(varchar,vnum),3) + right(s1,4)) as FuelVoucherNumber  from
	(select ID
		,s1
		,[Date] 
		,row_number() over (partition by s1 order by [Date] asc) as vnum
	from
	(SELECT id
		  ,'F' + CONVERT(varchar,CenterId) + right('0' + convert(varchar,month([Date])),2) + right(convert(varchar,year([Date])),2) as S1
		  ,[Date]	    
	  FROM [FleetManagement].[dbo].[MstVehicleRefuel]
	  ) rs1) rs2) as t2
on t1.Id = t2.Id

DECLARE @var0 nvarchar(128)
SELECT @var0 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.MstVehicleRefuel')
AND col_name(parent_object_id, parent_column_id) = 'IsVoucherAcquitted';
IF @var0 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[MstVehicleRefuel] DROP CONSTRAINT [' + @var0 + ']')
ALTER TABLE [dbo].[MstVehicleRefuel] ALTER COLUMN [IsVoucherAcquitted] [bit] NULL
go
--Alter Report Views
ALTER VIEW [dbo].[VehicleActivitiesHistoryService]
AS
SELECT     dbo.MstVehicle.RegistrationNumber AS [Registration Number], dbo.MstService.StartDate, dbo.MstService.Description, dbo.MstService.Cost, 
                      dbo.MstSystemParameters.ParameterName AS ServiceType, dbo.MstVehicle.Id
FROM         dbo.MstVehicle INNER JOIN
                      dbo.MstService ON dbo.MstVehicle.Id = dbo.MstService.VehicleId INNER JOIN
                      dbo.MstSystemParameters ON dbo.MstService.ServiceTypeId = dbo.MstSystemParameters.Id
WHERE     (dbo.MstSystemParameters.ParameterCodeId = 7) --service type

GO


CREATE INDEX [IX_Gender] ON [dbo].[MstContactDetail]([Gender])
ALTER TABLE [dbo].[MstContactDetail] ADD CONSTRAINT [FK_dbo.MstContactDetail_dbo.MstSystemParameters_Gender] FOREIGN KEY ([Gender]) REFERENCES [dbo].[MstSystemParameters] ([Id])
go

ALTER TABLE [dbo].[MstCenter] ADD [CenterCode] [varchar](2) NOT NULL DEFAULT ''
go


-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION GetCenterCode
(
	-- Add the parameters for the function here
	@CenterNumber int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	Declare @CenterCode varchar(2)

	-- Add the T-SQL statements to compute the return value here
	SELECT @CenterCode = centercode from MstCenter where CenterNumber = @CenterNumber

	-- Return the result of the function
	RETURN @CenterCode

END
GO

--Need to confirm and update center code below
 update dbo.MstCenter
 set centercode ='30' where CenterNumber = 4026 
 go 
 update dbo.MstCenter
 set centercode ='30' where CenterNumber = 4027 
 go 
 update dbo.MstCenter
 set centercode ='30' where CenterNumber = 4053 
 go 
 update dbo.MstCenter
 set centercode ='36' where CenterNumber = 4030 
 go 
 update dbo.MstCenter
 set centercode ='37' where CenterNumber = 4057 
 go 
 update dbo.MstCenter
 set centercode ='40' where CenterNumber = 4058 
 go 
 update dbo.MstCenter
 set centercode ='40' where CenterNumber = 4016 
 go 
 update dbo.MstCenter
 set centercode ='41' where CenterNumber = 4018 
 go 
 update dbo.MstCenter
 set centercode ='42' where CenterNumber = 4008 
 go 
 update dbo.MstCenter
 set centercode ='43' where CenterNumber = 4015 
 go 
 update dbo.MstCenter
 set centercode ='44' where CenterNumber = 4023 
 go 
 update dbo.MstCenter
 set centercode ='45' where CenterNumber = 4010 
 go 
 update dbo.MstCenter
 set centercode ='46' where CenterNumber = 4033 
 go 
 update dbo.MstCenter
 set centercode ='47' where CenterNumber = 4020 
 go 
 update dbo.MstCenter
 set centercode ='47' where CenterNumber = 4009 
 go 
 update dbo.MstCenter
 set centercode ='47' where CenterNumber = 4056 
 go 
 update dbo.MstCenter
 set centercode ='49' where CenterNumber = 4060 
 go 
 update dbo.MstCenter
 set centercode ='49' where CenterNumber = 4002 
 go 
 update dbo.MstCenter
 set centercode ='49' where CenterNumber = 4021 
 go 
 update dbo.MstCenter
 set centercode ='50' where CenterNumber = 4032 
 go 
 update dbo.MstCenter
 set centercode ='51' where CenterNumber = 4029 
 go 
 update dbo.MstCenter
 set centercode ='52' where CenterNumber = 4000 
 go 
 update dbo.MstCenter
 set centercode ='53' where CenterNumber = 4019 
 go 
 update dbo.MstCenter
 set centercode ='54' where CenterNumber = 4007 
 go 
 update dbo.MstCenter
 set centercode ='56' where CenterNumber = 4031 
 go 
 update dbo.MstCenter
 set centercode ='60' where CenterNumber = 4025 
 go 
 update dbo.MstCenter
 set centercode ='60' where CenterNumber = 4028 
 go 
 update dbo.MstCenter
 set centercode ='60' where CenterNumber = 4022 
 go 
 update dbo.MstCenter
 set centercode ='60' where CenterNumber = 4062 
 go 
 update dbo.MstCenter
 set centercode ='60' where CenterNumber = 4059 
 go 
 update dbo.MstCenter
 set centercode ='62' where CenterNumber = 4001 
 go 
 update dbo.MstCenter
 set centercode ='63' where CenterNumber = 4006 
 go 
 update dbo.MstCenter
 set centercode ='64' where CenterNumber = 4012 
 go 
 update dbo.MstCenter
 set centercode ='65' where CenterNumber = 4024 
 go 
 update dbo.MstCenter
 set centercode ='66' where CenterNumber = 4005 
 go 
 update dbo.MstCenter
 set centercode ='70' where CenterNumber = 4014 
 go 
 update dbo.MstCenter
 set centercode ='71' where CenterNumber = 4011 
 go 
 update dbo.MstCenter
 set centercode ='72' where CenterNumber = 4061 
 go 
 update dbo.MstCenter
 set centercode ='73' where CenterNumber = 4004 
 go 
 update dbo.MstCenter
 set centercode ='74' where CenterNumber = 4017 
 go 
 update dbo.MstCenter
 set centercode ='75' where CenterNumber = 4013 
 go 
 update dbo.MstCenter
 set centercode ='77' where CenterNumber = 4003 
 go 




--Note: Confirm and run below to update service job # column for existing services
update t1
set t1.ServiceJobNumber = t2.ServiceJobNumber
from [FleetManagement].[dbo].[MstService] as t1
inner join 
	(select Id, (left(s1,3) + right('00' + convert(varchar,jobnum),3) + right(s1,4)) as ServiceJobNumber  from
	(select ID
		,s1
		,startdate 
		,row_number() over (partition by s1 order by startdate asc) as jobnum
	from
	(SELECT id
		  ,'S' + CONVERT(varchar,dbo.GetCenterCode(CenterId)) + right('0' + convert(varchar,month([StartDate])),2) + right(convert(varchar,year([StartDate])),2) as S1
		  ,StartDate	    
	  FROM [FleetManagement].[dbo].[MstService]
	  where VehicleId is not null) rs1) rs2) as t2
on t1.Id = t2.Id

--Note: Confirm and run below to update voucher # column for existing services
update t1
set t1.VoucherNumber = t2.FuelVoucherNumber,
t1.IsVoucherAcquitted = 1,
t1.VoucherReceiptNumber = '*** Not Available ***'
from [FleetManagement].[dbo].[MstVehicleRefuel] as t1
inner join 
	(select Id, (left(s1,3) + right('00' + convert(varchar,vnum),3) + right(s1,4)) as FuelVoucherNumber  from
	(select ID
		,s1
		,[Date] 
		,row_number() over (partition by s1 order by [Date] asc) as vnum
	from
	(SELECT id
		  ,'F' + CONVERT(varchar,dbo.GetCenterCode(CenterId)) + right('0' + convert(varchar,month([Date])),2) + right(convert(varchar,year([Date])),2) as S1
		  ,[Date]	    
	  FROM [FleetManagement].[dbo].[MstVehicleRefuel]
	  ) rs1) rs2) as t2
on t1.Id = t2.Id

--update string length of voucher and service job number from 12 back to 10 as per BR
DECLARE @var0 nvarchar(128)
SELECT @var0 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.MstService')
AND col_name(parent_object_id, parent_column_id) = 'ServiceJobNumber';
IF @var0 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[MstService] DROP CONSTRAINT [' + @var0 + ']')
ALTER TABLE [dbo].[MstService] ALTER COLUMN [ServiceJobNumber] [varchar](10) NULL
DECLARE @var1 nvarchar(128)
SELECT @var1 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.MstVehicleRefuel')
AND col_name(parent_object_id, parent_column_id) = 'VoucherNumber';
IF @var1 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[MstVehicleRefuel] DROP CONSTRAINT [' + @var1 + ']')
ALTER TABLE [dbo].[MstVehicleRefuel] ALTER COLUMN [VoucherNumber] [varchar](10) NULL
go
--add audit capture fields - 20/03/2019
ALTER TABLE [dbo].[MstCompliance] ADD [CreatedBy] [varchar](50)
go
ALTER TABLE [dbo].[MstCompliance] ADD [CreatedDate] [datetime]
go
ALTER TABLE [dbo].[MstCompliance] ADD [LastUpdatedBy] [varchar](50)
go
ALTER TABLE [dbo].[MstCompliance] ADD [LastUpdatedDate] [datetime]
go
ALTER TABLE [dbo].[MstVehicle] ADD [CreatedBy] [varchar](50)
go
ALTER TABLE [dbo].[MstVehicle] ADD [CreatedDate] [datetime]
go
ALTER TABLE [dbo].[MstVehicle] ADD [LastUpdatedBy] [varchar](50)
go
ALTER TABLE [dbo].[MstVehicle] ADD [LastUpdatedDate] [datetime]
go
ALTER TABLE [dbo].[MstService] ADD [CreatedBy] [varchar](50)
go
ALTER TABLE [dbo].[MstService] ADD [CreatedDate] [datetime]
go
ALTER TABLE [dbo].[MstService] ADD [LastUpdatedBy] [varchar](50)
go
ALTER TABLE [dbo].[MstService] ADD [LastUpdatedDate] [datetime]
go
ALTER TABLE [dbo].[MstVehicleRefuel] ADD [CreatedBy] [varchar](50)
go
ALTER TABLE [dbo].[MstVehicleRefuel] ADD [CreatedDate] [datetime]
go
ALTER TABLE [dbo].[MstVehicleRefuel] ADD [LastUpdatedBy] [varchar](50)
go
ALTER TABLE [dbo].[MstVehicleRefuel] ADD [LastUpdatedDate] [datetime]
go
ALTER TABLE [dbo].[MstIncident] ADD [CreatedBy] [varchar](50)
go
ALTER TABLE [dbo].[MstIncident] ADD [CreatedDate] [datetime]
go
ALTER TABLE [dbo].[MstIncident] ADD [LastUpdatedBy] [varchar](50)
go
ALTER TABLE [dbo].[MstIncident] ADD [LastUpdatedDate] [datetime]
go
--Application Permissions Control Related
--select action.ActionId, action.Description ActionName,
--	interface.InterfaceId, interface.Description InterfaceName
--	,menu.MenuId, menu.Description MenuDescription
--FROM [FleetManagement].[dbo].[AppActions] action left outer join 
-- [FleetManagement].[dbo].AppInterface interface on action.InterfaceId = interface.InterfaceId left outer join
-- [FleetManagement].[dbo].AppMenus menu on interface.MenuId = menu.MenuId



UPDATE [dbo].[AppInterface]
   SET [Description] = 'VEHICLE_REGISTER'      
 WHERE InterfaceId = 28
GO

INSERT INTO [dbo].[AppInterface]
           ([Description]
           ,[MenuId])
     VALUES
           ('VIEW_BOS_VEHICLES'
           ,1)
GO

UPDATE [dbo].[AppActions]
   SET [Description] = 'DISPOSE_VEHICLE'     
 WHERE ActionId = 3
GO

INSERT INTO [dbo].[AppActions]
           ([Description]
           ,[InterfaceId])
     VALUES
           ('VIEW_BOS_VEHICLES'
           ,42)
GO


--Add View Vehicles Functionality
INSERT INTO [dbo].[AppActions]
           ([Description]
           ,[InterfaceId])
     VALUES
           ('VIEW_VEHICLES'
           ,28)
GO
--Rename Manage Vehicle Registry
UPDATE [dbo].[AppActions]
   SET [Description] = 'UPDATE_VEHICLE_REGISTRY'     
 WHERE ActionId = 2
GO

-- Remove Manage Fuel Voucher Action
delete from AppRoleActionAccess
where ActionId = 87
go
DELETE FROM  [dbo].[AppActions]
WHERE ActionId = 87
GO

--Update View Fuel Voucher to Acquit and move to Fuel Register Interface
UPDATE [dbo].[AppActions]
   SET [Description] = 'ACQUIT_FUEL_VOUCHER'
	   , InterfaceId = 1     
 WHERE ActionId = 88
GO

--Remove Fuel Voucher Interface
delete from AppRoleInterfaceAccess
where InterfaceId = 33
go
DELETE FROM  [dbo].AppInterface
WHERE InterfaceId = 33
GO

-- Remove Staff and Supplier Action - Both come under Contacts Management
delete from AppRoleActionAccess
where ActionId in (26,27,28,29,30,31)
go
DELETE FROM  [dbo].[AppActions]
where ActionId in (26,27,28,29,30,31)
GO

INSERT INTO [dbo].[MstSystemParameterCode]
           ([ParameterCode])
     VALUES('SMTPServer')
GO

INSERT INTO [dbo].[MstSystemParameterCode]
           ([ParameterCode])
     VALUES('SMTPPort')
GO


INSERT INTO [dbo].[MstSystemParameterCode]
           ([ParameterCode])
     VALUES('SMTPUser')
GO

INSERT INTO [dbo].[MstSystemParameterCode]
           ([ParameterCode])
     VALUES('SMTPPassword')
GO
INSERT INTO [dbo].[MstSystemParameterCode]
           ([ParameterCode])
     VALUES('SysAdminEmail')
GO

declare @smtpServerId int, @smtpPortId int, @smtpUserId int, @smtpPasswordId int, @appIssueTypeId int,@sysAdminEmailId int

select @smtpServerId = id from [dbo].[MstSystemParameterCode] 
where [ParameterCode] = 'SMTPServer'
--print @smtpServerId

select @smtpPortId = id from [dbo].[MstSystemParameterCode] 
where [ParameterCode] = 'SMTPPort'
--print @smtpPortId


select @smtpUserId = id from [dbo].[MstSystemParameterCode] 
where [ParameterCode] = 'SMTPUser'
--print @smtpPortId
USE [FleetManagement]

select @smtpPasswordId = id from [dbo].[MstSystemParameterCode] 
where [ParameterCode] = 'SMTPPassword'
--print @smtpPortId
USE [FleetManagement]

select @appIssueTypeId = id from [dbo].[MstSystemParameterCode] 
where [ParameterCode] = 'AppIssueType'
--print @smtpPortId
select @sysAdminEmailId = id 
from [dbo].[MstSystemParameterCode] 
where [ParameterCode] = 'SysAdminEmail'

INSERT INTO [dbo].[MstSystemParameters]
           ([ParameterCodeId]
           ,[ParameterName]
           ,[IsHardCoded])
     VALUES
           (@smtpServerId
           ,'smtp.office365.com'
           ,0)

INSERT INTO [dbo].[MstSystemParameters]
           ([ParameterCodeId]
           ,[ParameterName]
           ,[IsHardCoded])
     VALUES
           (@smtpPortId
           ,'587'
           ,0)


INSERT INTO [dbo].[MstSystemParameters]
           ([ParameterCodeId]
           ,[ParameterName]
           ,[IsHardCoded])
     VALUES
           (@smtpUserId
           ,''
           ,0)


INSERT INTO [dbo].[MstSystemParameters]
           ([ParameterCodeId]
           ,[ParameterName]
           ,[IsHardCoded])
     VALUES
           (@smtpPasswordId
           ,''
           ,0)

INSERT INTO [dbo].[MstSystemParameters]
           ([ParameterCodeId]
           ,[ParameterName]
           ,[IsHardCoded])
     VALUES
           (@sysAdminEmailId
           ,'solomon.mallick@pngpower.com.pg'
           ,0)
--insert app issues types

INSERT INTO [dbo].[MstSystemParameters]
           ([ParameterCodeId]
           ,[ParameterName]
           ,[IsHardCoded])
     VALUES
           (@appIssueTypeId
           ,'Password Reset Request'
           ,0)

INSERT INTO [dbo].[MstSystemParameters]
           ([ParameterCodeId]
           ,[ParameterName]
           ,[IsHardCoded])
     VALUES
           (@appIssueTypeId
           ,'Report Application Error'
           ,0)

INSERT INTO [dbo].[MstSystemParameters]
           ([ParameterCodeId]
           ,[ParameterName]
           ,[IsHardCoded])
     VALUES
           (@appIssueTypeId
           ,'Application Access Request'
           ,0)

INSERT INTO [dbo].[MstSystemParameters]
           ([ParameterCodeId]
           ,[ParameterName]
           ,[IsHardCoded])
     VALUES
           (@appIssueTypeId
           ,'Unauthorized Access Request'
           ,0)

INSERT INTO [dbo].[MstSystemParameters]
           ([ParameterCodeId]
           ,[ParameterName]
           ,[IsHardCoded])
     VALUES
           (@appIssueTypeId
           ,'Application Usage Training Request'
           ,0)

INSERT INTO [dbo].[MstSystemParameters]
           ([ParameterCodeId]
           ,[ParameterName]
           ,[IsHardCoded])
     VALUES
           (@appIssueTypeId
           ,'Application Enhancement Request'
           ,0)

INSERT INTO [dbo].[MstSystemParameters]
           ([ParameterCodeId]
           ,[ParameterName]
           ,[IsHardCoded])
     VALUES
           (@appIssueTypeId
           ,'Application Permission Request'
           ,0)



GO

CREATE TABLE [dbo].[AppIssue] (
    [Id] [int] NOT NULL IDENTITY,
    [AppIssueTypeId] [int],
    [Description] [nvarchar](max),
    CONSTRAINT [PK_dbo.AppIssue] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_AppIssueTypeId] ON [dbo].[AppIssue]([AppIssueTypeId])
ALTER TABLE [dbo].[AppIssue] ADD CONSTRAINT [FK_dbo.AppIssue_dbo.MstSystemParameters_AppIssueTypeId] FOREIGN KEY ([AppIssueTypeId]) REFERENCES [dbo].[MstSystemParameters] ([Id])
GO

ALTER TABLE [dbo].[AppIssue] ADD [CreatedBy] [nvarchar](max)
ALTER TABLE [dbo].[AppIssue] ADD [CreatedDate] [datetime]
ALTER TABLE [dbo].[AppIssue] ADD [HasBeenResolved] [bit]
DECLARE @var0 nvarchar(128)
SELECT @var0 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.AppIssue')
AND col_name(parent_object_id, parent_column_id) = 'Description';
IF @var0 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[AppIssue] DROP CONSTRAINT [' + @var0 + ']')
ALTER TABLE [dbo].[AppIssue] ALTER COLUMN [Description] [varchar](2000) NULL
go