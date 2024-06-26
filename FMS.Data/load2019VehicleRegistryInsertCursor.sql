--Author: Snele, Cloudcode PNG Limted, 24/03/2019

Declare 
	@acquisitionDate date, 
	@registrationNumber varchar(10),
	@makeId int,
	@modelId int,
	@operationalStatusId int,
	@financialStatusId int,
	@centerId int,
	@conditionId int,
	@typeId int,
	@engineNumber varchar(50),
	@chassisNumber varchar(50),
	@bosRecommedation int,
	@mileage varchar(20),
	@comment varchar(200)


-- declare a cursor
DECLARE insert_cursor CURSOR FOR 
SELECT [AcquisitionDate]
	,[RegistrationNumber]
	,[VehicleMakeId]
	,[VehicleModelId]
	,[OperationStatusId]
	,[FinancialStatusId]
	,[CenterId]
	,[ConditionId]
	,[VehicleTypeId]
	,[EngineNumber]
	,[ChassisNumber]      
	,[BOSRecommendation]    
	,[Mileage]
	,[Comment]
FROM [FleetManagement].[dbo].[2019VehicleRegisterUpload]
 
-- open cursor and fetch first row into variables
OPEN insert_cursor
FETCH NEXT FROM insert_cursor into 
	@acquisitionDate, 
	@registrationNumber,
	@makeId,
	@modelId,
	@operationalStatusId,
	@financialStatusId,
	@centerId,
	@conditionId,
	@typeId,
	@engineNumber,
	@chassisNumber,
	@bosRecommedation,
	@mileage,
	@comment
 
-- check for a new row
WHILE @@FETCH_STATUS = 0
BEGIN
	begin transaction;

	begin try
		Insert into [dbo].[MstVehicleTest]([AcquisitionDate]
			,[RegistrationNumber]
			,[MadeId]
			,[ModelId]
			,[StatusId]
			,[FinancialStatusId]
			,[CenterId]
			,[ConditionId]
			,[VehicleTypeId]
			,[EngineNumber]
			,[ChassisNumber]
			,[BOS_Recommendation]
			,[CurrentMileage]
			,[Comments]
			,CreatedBy
			,CreatedDate)	
		values(@acquisitionDate, 
			@registrationNumber,
			@makeId,
			@modelId,
			@operationalStatusId,
			@financialStatusId,
			@centerId,
			@conditionId,
			@typeId,
			@engineNumber,
			@chassisNumber,
			cast(@bosRecommedation as bit),
			cast(@mileage as int),
			@comment,
			'sutherland.nele@cloudcode.com.pg',
			getdate())
   end try

   begin catch
	   print 'Error for: ' + @registrationNumber	
	   IF @@TRANCOUNT > 0
		 ROLLBACK TRANSACTION;

   end catch

   IF @@TRANCOUNT > 0
		COMMIT TRANSACTION;


	FETCH NEXT FROM insert_cursor into 
		@acquisitionDate, 
		@registrationNumber,
		@makeId,
		@modelId,
		@operationalStatusId,
		@financialStatusId,
		@centerId,
		@conditionId,
		@typeId,
		@engineNumber,
		@chassisNumber,
		@bosRecommedation,
		@mileage,
		@comment
END
close insert_cursor
Deallocate insert_cursor
GO
