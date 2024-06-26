/****** Script for SelectTopNRows command from SSMS  ******/
-- NOTE Importantly: Renaming columns will cause the column to loose all it's existing value

ALTER TABLE [dbo].[User] ADD [LastLoginTime] [datetime]
ALTER TABLE [dbo].[User] ADD [RegistrationDate] [datetime]
ALTER TABLE [dbo].[MstCenter] ADD [MaxVehicleServiceCapacityPerMonth] [int]

--Note !!: confirm with ppl before running below
--update [FleetManagement].[dbo].[MstCenter]
--set MaxVehicleServiceCapacityPerMonth = 10

ALTER TABLE [dbo].[MstService] ADD [ServiceJobNumber] [varchar](12)

--Note: Confirm and run below to update service job # column for existing services
--update t1
--set t1.ServiceJobNumber = t2.ServiceJobNumber
--from [FleetManagement].[dbo].[MstService] as t1
--inner join 
--	(select Id, (left(s1,5) + right('00' + convert(varchar,jobnum),3) + right(s1,4)) as ServiceJobNumber  from
--	(select ID
--		,s1
--		,startdate 
--		,row_number() over (partition by s1 order by startdate asc) as jobnum
--	from
--	(SELECT id
--		  ,'S' + CONVERT(varchar,CenterId) + right('0' + convert(varchar,month([StartDate])),2) + right(convert(varchar,year([StartDate])),2) as S1
--		  ,StartDate	    
--	  FROM [FleetManagement].[dbo].[MstService]
--	  where VehicleId is not null) rs1) rs2) as t2
--on t1.Id = t2.Id

--sample code to backup table
--select * into tableddmmyyyy from table
--go

--confirm and run code below !! to fix fk intergrity error on makey fueldistributorid fk to contactdetails table

--set identity_insert [dbo].[MstContactDetail] on
--go

--INSERT INTO [dbo].[MstContactDetail]
--           (Id
--		   ,[ContactName]
--           ,[Contacttype]
--           ,[ContactPerson]
--           ,[PostalAddress]
--           ,[StreetAddress]
--           ,[Facsimile]
--           ,[Email]
--           ,[Telephone]
--           ,[Fax]
--           ,[Website]
--           ,[Mobile]
--           ,[Comments]
--           ,[IsDriver]
--           ,[SupplierType]
--           ,[DateOfBirth]
--           ,[Gender]
--           ,[LicenceNumber]
--           ,[LicanceClass]
--           ,[LicenceExpiryDate]
--           ,[PPLPermitNumber]
--           ,[CenterId]
--           ,[PPLPermitIssueDate])
--     VALUES
--           (181		   
--		   ,'Niugini Oil'
--           ,39
--           ,''
--           ,''
--           ,''
--           ,''
--           ,''
--           ,''
--           ,''
--           ,''
--           ,''
--            ,''
--           ,0
--           ,228
--           ,NULL
--           ,NULL
--           ,''
--           ,''
--           ,NULL
--           ,''
--           ,NULL
--           ,NULL)
--GO

--set identity_insert [dbo].[MstContactDetail] off
--go

--update [FleetManagement].[dbo].[MstVehicleRefuel]
--set FuelDistributorId = 1056
--where [FuelDistributorId] = 180
--go

--set identity_insert [dbo].[MstContactDetail] on
--go
--INSERT INTO [dbo].[MstContactDetail]
--           (Id
--		   ,[ContactName]
--           ,[Contacttype]
--           ,[ContactPerson]
--           ,[PostalAddress]
--           ,[StreetAddress]
--           ,[Facsimile]
--           ,[Email]
--           ,[Telephone]
--           ,[Fax]
--           ,[Website]
--           ,[Mobile]
--           ,[Comments]
--           ,[IsDriver]
--           ,[SupplierType]
--           ,[DateOfBirth]
--           ,[Gender]
--           ,[LicenceNumber]
--           ,[LicanceClass]
--           ,[LicenceExpiryDate]
--           ,[PPLPermitNumber]
--           ,[CenterId]
--           ,[PPLPermitIssueDate])
--     VALUES
--           (183		   
--		   ,'Motor Care (POM)'
--           ,39
--           ,''
--           ,''
--           ,''
--           ,''
--           ,''
--           ,''
--           ,''
--           ,''
--           ,''
--            ,''
--           ,0
--           ,228
--           ,NULL
--           ,NULL
--           ,''
--           ,''
--           ,NULL
--           ,''
--           ,NULL
--           ,NULL)
--GO

--set identity_insert [dbo].[MstContactDetail] off
--go

CREATE INDEX [IX_FuelDistributorId] ON [dbo].[MstVehicleRefuel]([FuelDistributorId])
ALTER TABLE [dbo].[MstVehicleRefuel] ADD CONSTRAINT [FK_dbo.MstVehicleRefuel_dbo.MstContactDetail_FuelDistributorId] FOREIGN KEY ([FuelDistributorId]) REFERENCES [dbo].[MstContactDetail] ([Id])


ALTER TABLE [dbo].[MstVehicleRefuel] ADD [VoucherNumber] [varchar](12)
ALTER TABLE [dbo].[MstVehicleRefuel] ADD [VoucherReceiptNumber] [varchar](50)
ALTER TABLE [dbo].[MstVehicleRefuel] ADD [IsVoucherAcquitted] [bit] NOT NULL DEFAULT 0
ALTER TABLE [dbo].[MstCenter] ADD [MaxVehicleFuelVoucherCapacityPerMonth] [int]

--Note !!: confirm with ppl before running below
--update [FleetManagement].[dbo].[MstCenter]
--set [MaxVehicleFuelVoucherCapacityPerMonth] = 100

--update t1
--set t1.VoucherNumber = t2.FuelVoucherNumber,
--t1.IsVoucherAcquitted = 1,
--t1.VoucherReceiptNumber = '*** Not Available ***'
--from [FleetManagement].[dbo].[MstVehicleRefuel] as t1
--inner join 
--	(select Id, (left(s1,5) + right('00' + convert(varchar,vnum),3) + right(s1,4)) as FuelVoucherNumber  from
--	(select ID
--		,s1
--		,[Date] 
--		,row_number() over (partition by s1 order by [Date] asc) as vnum
--	from
--	(SELECT id
--		  ,'F' + CONVERT(varchar,CenterId) + right('0' + convert(varchar,month([Date])),2) + right(convert(varchar,year([Date])),2) as S1
--		  ,[Date]	    
--	  FROM [FleetManagement].[dbo].[MstVehicleRefuel]
--	  ) rs1) rs2) as t2
--on t1.Id = t2.Id

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
