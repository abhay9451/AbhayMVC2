SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT INTO [dbo].[Employees] ([Id], [Name], [Email], [Mobile], [Gender], [Salary]) VALUES (1, N'Rahul Gandhi', N'pappu999@gmail.com', N'800098765', N'Male', CAST(234556.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Employees] ([Id], [Name], [Email], [Mobile], [Gender], [Salary]) VALUES (2, N'Narendra modi', N'modi43@gmail.com', N'876543234', N'Male', CAST(987654.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Employees] ([Id], [Name], [Email], [Mobile], [Gender], [Salary]) VALUES (3, N'Arvinda kejriwal ', N'kajriwal54@gamil.com', N'987654323', N'Male', CAST(87000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Employees] OFF
