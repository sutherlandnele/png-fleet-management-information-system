/****** Script for SelectTopNRows command from SSMS  ******/
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





