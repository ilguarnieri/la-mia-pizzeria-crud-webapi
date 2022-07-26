SET IDENTITY_INSERT [dbo].[pizzas] ON
INSERT INTO [dbo].[pizzas] ([Id], [name], [ingredients], [photo], [price], [CategoryId]) VALUES (1, N'Pizza Margherita', N'Pomodori pelati,Mozzarella di bufala,Basilico,Olio EVO', N'/img/margherita.jpg', CAST(4.50 AS Decimal(5, 2)), 1)
INSERT INTO [dbo].[pizzas] ([Id], [name], [ingredients], [photo], [price], [CategoryId]) VALUES (2, N'Pizza Speck e Gorgonzola', N'Fior di latte d''Agerola,Speck IGP,Gorgonzola,Basilico,Olio EVO', N'/img/speck.jpg', CAST(8.00 AS Decimal(5, 2)), 3)
INSERT INTO [dbo].[pizzas] ([Id], [name], [ingredients], [photo], [price], [CategoryId]) VALUES (3, N'Pizza Calabria', N'Pomodori pelati,Fior di latte d''Agerola,''Nduja di Spilinfa,Caciocavallo,Basilico,Olio EVO', N'/img/calabria.jpg', CAST(6.50 AS Decimal(5, 2)), 2)
INSERT INTO [dbo].[pizzas] ([Id], [name], [ingredients], [photo], [price], [CategoryId]) VALUES (4, N'Pizza Vegghy', N'Pomodori pelati,Melanzane,Scaglie di ricotta,Basilico,Olio EVO', N'/img/sicilia.jpg', CAST(7.50 AS Decimal(5, 2)), 5)
INSERT INTO [dbo].[pizzas] ([Id], [name], [ingredients], [photo], [price], [CategoryId]) VALUES (5, N'Pizza Puglia', N'Datterini  gialli,Capocollo di Martina Franca,Burrata pugliese,Olive,Tarallo sbriciolato,Basilico,Olio EVO', N'/img/puglia.jpg', CAST(8.50 AS Decimal(5, 2)), 2)
INSERT INTO [dbo].[pizzas] ([Id], [name], [ingredients], [photo], [price], [CategoryId]) VALUES (6, N'Pizza Pistardella', N'Fior di latte d''Agerola,Mortadella IGP,Granella di pistacchio,Basilico,Olio EVO', N'/img/emilia.jpg', CAST(7.00 AS Decimal(5, 2)), 4)
INSERT INTO [dbo].[pizzas] ([Id], [name], [ingredients], [photo], [price], [CategoryId]) VALUES (7, N'Pizza Favolosa', N'Pomodoro,Mozzarella,Pancetta,Funghi  porcini,Origano,Olio EVO', NULL, CAST(6.80 AS Decimal(5, 2)), 3)
SET IDENTITY_INSERT [dbo].[pizzas] OFF



SET IDENTITY_INSERT [dbo].[categories] ON
INSERT INTO [dbo].[categories] ([Id], [Name]) VALUES (1, N'Classiche')
INSERT INTO [dbo].[categories] ([Id], [Name]) VALUES (2, N'Regionali')
INSERT INTO [dbo].[categories] ([Id], [Name]) VALUES (3, N'Speciali')
INSERT INTO [dbo].[categories] ([Id], [Name]) VALUES (4, N'Bianche')
INSERT INTO [dbo].[categories] ([Id], [Name]) VALUES (5, N'Vegetariane')
SET IDENTITY_INSERT [dbo].[categories] OFF
