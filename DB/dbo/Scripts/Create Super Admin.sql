
DECLARE @userId INT;
INSERT [dbo].[AspNetUsers] ([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp],   
[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled],   
[AccessFailedCount], [UserName],[WorkerId])   
VALUES (N'admin@gmail.com', 1,   
N'ALkHGax/i5KBYWJ7q4jhJmMKmm2quBtnnqS8KcmLWd2kQpN6FaGVulDmmX12s7YAyQ==',   
N'a7bc5c5c-6169-4911-b935-6fc4df01d313', NULL, 0, 0, NULL, 0, 0, N'Admin',null)
SET @userId = SCOPE_IDENTITY()

DECLARE @roleId INT;
Insert [dbo].[AspNetRoles] values ('Super Admin',null)
SET @roleId = SCOPE_IDENTITY()
Insert [dbo].[AspNetUserRoles] values (@userId,@roleId)
INSERT [dbo].[Lookups] VALUES (N'Create', N'Create'),(N'Edit', N'Edit'),(N'Delete', N'Delete'),(N'List', N'List'),(N'Export', N'Export')
INSERT [dbo].[PermissionEntities]   VALUES (N'Organization', N'Organization'),(N'Worker', N'Worker'),(N'Consumption Items', N'ConsumptionItems'),(N'Purchase Order', N'PurchaseOrder'),(N'UOM', N'UOM'),(N'Warehouse', N'Warehouse'),(N'LookUp', N'LookUp'),(N'Permission Entity', N'Permission_Entity')
,(N'Role', N'Role'),
(N'Role Permission Map', N'Role_Permission_Map'),
(N'Entity Lookup Map', N'Entity_Lookup_Map'),
(N'Vendor', N'Vendor'),
(N'Category', N'Category'),
(N'UOM Conversion', N'UOM_Conversion'),
(N'Items', N'Items'),
(N'Item Type', N'Item_Type'),
(N'Item Category', N'Item_Category'),
(N'Item Consumption', N'Item_Consumption'),
(N'Inventory Adjustment', N'Inventory_Adjustment'),
(N'Consumption Report', N'Consumption_Report'),
(N'On-Hand Report', N'On-Hand_Report'),
(N'Purchase Enquiry Report', N'Purchase_Enquiry_Report')
INSERT [dbo].[PermissionEntityLookUps]  VALUES ((Select Top 1 Id from PermissionEntities Where Name = 'Organization'), (Select Top 1 Id from LookUps Where Name = 'Create')),
((Select Top 1 Id from PermissionEntities Where Name = 'Organization'), (Select Top 1 Id from LookUps Where Name = 'List')),
((Select Top 1 Id from PermissionEntities Where Name = 'Organization'), (Select Top 1 Id from LookUps Where Name = 'Delete')),
((Select Top 1 Id from PermissionEntities Where Name = 'Organization'), (Select Top 1 Id from LookUps Where Name = 'Edit')),
((Select Top 1 Id from PermissionEntities Where Name = 'Role Permission Map'), (Select Top 1 Id from LookUps Where Name = 'Create')),
((Select Top 1 Id from PermissionEntities Where Name = 'Role Permission Map'), (Select Top 1 Id from LookUps Where Name = 'List')),
((Select Top 1 Id from PermissionEntities Where Name = 'Role Permission Map'), (Select Top 1 Id from LookUps Where Name = 'Edit')),
((Select Top 1 Id from PermissionEntities Where Name = 'Role Permission Map'), (Select Top 1 Id from LookUps Where Name = 'Delete')),
((Select Top 1 Id from PermissionEntities Where Name = 'Entity Lookup Map'), (Select Top 1 Id from LookUps Where Name = 'Create')),
((Select Top 1 Id from PermissionEntities Where Name = 'Entity Lookup Map'), (Select Top 1 Id from LookUps Where Name = 'List')),
((Select Top 1 Id from PermissionEntities Where Name = 'Entity Lookup Map'), (Select Top 1 Id from LookUps Where Name = 'Edit')),
((Select Top 1 Id from PermissionEntities Where Name = 'Entity Lookup Map'), (Select Top 1 Id from LookUps Where Name = 'Delete'))
Insert into Role_PermissionEntityLookUps Values (1,@roleId),(2,@roleId),(3,@roleId),(4,@roleId),(5,@roleId),(6,@roleId),(7,@roleId),(8,@roleId),(9,@roleId),(10,@roleId),(11,@roleId),(12,@roleId)

Select * from AspNetUsers