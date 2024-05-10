/****** Script for SelectTopNRows command from SSMS  ******/
select action.ActionId, action.Description ActionName,
	interface.InterfaceId, interface.Description InterfaceName
	,menu.MenuId, menu.Description MenuDescription
FROM [FleetManagement].[dbo].[AppActions] action left outer join 
 [FleetManagement].[dbo].AppInterface interface on action.InterfaceId = interface.InterfaceId left outer join
 [FleetManagement].[dbo].AppMenus menu on interface.MenuId = menu.MenuId
where menu.MenuId = 1






