
INSERT [dbo].[AspNetUsers] ([Id],[Email], [EmailConfirmed], [PasswordHash], [SecurityStamp],   
[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled],   
[AccessFailedCount], [UserName],[OrganizationId],[WorkerId])   
VALUES (1,N'admin@gmail.com', 1,   
N'ALkHGax/i5KBYWJ7q4jhJmMKmm2quBtnnqS8KcmLWd2kQpN6FaGVulDmmX12s7YAyQ==',   
N'a7bc5c5c-6169-4911-b935-6fc4df01d313', NULL, 0, 0, NULL, 0, 0, N'Admin',null,null)



Alter Table WOrker
Drop column OrganizationId