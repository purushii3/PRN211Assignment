CREATE DATABASE KoiFish;
GO
USE KoiFish;
GO

CREATE TABLE [dbo].[users](
	[userID] [int] IDENTITY(1,1) PRIMARY KEY,
	[userName] [nvarchar](50)  NOT NULL ,
	[fullName] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[roleID] [nvarchar](50) NOT NULL,
	[birthday] date NOT NULL,
	[address] [nvarchar](200) NULL,
	[phone] [nvarchar](11) NOT NULL,
	[status] bit NOT NULL
);
INSERT INTO [dbo].[users] ([userName], [fullName], [password], [address], [birthday], [phone], [roleID], [status])
VALUES 
	('Tu', N'Cam Tu', '1', N'Ben Tre', '2003-05-04', '0707064154', 'AD' , 1),
	('Nguyen', N'User Two', '1', N'789 Pine St, CityC', '1990-07-22', '1239874560', 'US', 1),
    ('Admin', N'Chu page', '1', N'123 Main St, CityA', '2003-08-09', '12345678901', 'AD', 1),
	('John', N'John Doe', '1', N'123 Main St, CityA', '2003-08-09', '12345678901', 'US', 1),
	('Teo', N'Teo', 'password123', N'456 Oak St, CityB', '1995-02-15', '9876543210', 'US', 1),
    ('Man', N'User Three', '1', N'Ho Chi Minh', '1988-11-30', '6543217890', 'US', 1),
    ('Hieu', N'User Four', 'pass123word', N'202 Elm St, CityE', '1992-04-18', '7890123456', 'US', 0),
    ('Kiet', N'Kiet', 'pass456word', N'303 Birch St, CityF', '1998-09-03', '3456789012', 'US', 1),
    ('user6', N'Ti', 'pass789word', N'404 Cedar St, CityG','1993-12-05', '9012345678', 'US', 1),
    ('user7', N'User Seven', 'pass789word', N'Ho Chi Minh', '1991-06-10', '5678901234', 'US', 1);

CREATE TABLE [Service](
	[serviceID] [int] IDENTITY(1,1) PRIMARY KEY,
	[serviceName] [nvarchar](100) NOT NULL,
	[priceConsign] FLOAT NULL
);
INSERT INTO [Service] ([serviceName], [priceConsign])
VALUES
('Buy Fish', 0),
('Consign Fish', 20.5);


CREATE TABLE [dbo].[orders]( 
 	[orderID] [nvarchar] (40) NOT NULL, 
 	[date] [date] NOT NULL, 
 	[userID] [int] NOT NULL,
	[serviceID] [int] NOT NULL,
 	[totalMoney] float NULL, 
	[status] bit not null,
 CONSTRAINT [PK_order] PRIMARY KEY ([orderID]),
 CONSTRAINT [FK_order_user] FOREIGN KEY ([userID])
 REFERENCES [dbo].[users] ([userID]) ON DELETE NO ACTION,
 CONSTRAINT [FK_order_service] FOREIGN KEY ([serviceID])
 REFERENCES [dbo].[Service] ([serviceID]) ON DELETE NO ACTION
);

CREATE TABLE Category(
	[categoryID] [int] IDENTITY(1,1) PRIMARY KEY,
	[categoryName] [nvarchar](100) NOT NULL,
);
INSERT INTO [Category] ([categoryName])
VALUES 
('Utsuri'),
('Kohaku'),
('Showa'),
('Asagi'),
('Shusui');


CREATE TABLE [dbo].[koiFish](
	[koiFishID] [int] IDENTITY(1,1) NOT NULL,
	[koiFishName] [nvarchar](100) NOT NULL,
	[koiFishImage][nvarchar](100) NOT NULL,
	[koiFishQuantity] int NULL,
	[koiFishPrice] float NULL,
	[origin] [nvarchar](100),
	[healthStatus] int,
	[awardCertificate] [nvarchar](100),
	[weight] float NULL,
	[length] float NULL,
	[status] bit not null,
	[categoryID] [int] not null,
	CONSTRAINT [PK_koiFish] PRIMARY KEY([koiFishID]),
	CONSTRAINT [FK_Category] FOREIGN KEY ([categoryID]) REFERENCES [dbo].[Category]([categoryID])
);
INSERT INTO [koiFish] ([koiFishName], [koiFishImage], [koiFishQuantity], [koiFishPrice], [origin], [healthStatus], [awardCertificate], [weight], [length], [status], [categoryID])
VALUES 
('Koi Sanke', 'image_sanke.jpg', 10, 1500.00, 'Japan', 1, 'Yes', 2.5, 40, 1, 1),
('Koi Kohaku', 'image_kohaku.jpg', 5, 2000.00, 'Japan', 1, 'Yes', 3.0, 50, 1, 2),
('Koi Showa', 'image_showa.jpg', 7, 1800.00, 'Japan', 1, 'No', 2.8, 45, 1, 3),
('Koi Asagi', 'image_asagi.jpg', 8, 2200.00, 'Japan', 1, 'Yes', 3.2, 48, 1, 4),
('Koi Shusui', 'image_shusui.jpg', 6, 1750.00, 'Japan', 1, 'No', 2.9, 43, 1, 5),
('Koi Goshiki', 'image_goshiki.jpg', 12, 2500.00, 'Japan', 1, 'Yes', 3.5, 55, 1, 2),
('Koi Utsurimono', 'image_utsurimono.jpg', 15, 2300.00, 'Japan', 1, 'No', 3.1, 52, 1, 3),
('Koi Chagoi', 'image_chagoi.jpg', 20, 2100.00, 'Japan', 1, 'Yes', 4.0, 60, 1, 4),
('Koi Tancho', 'image_tancho.jpg', 10, 2800.00, 'Japan', 1, 'Yes', 3.8, 58, 1, 5),
('Koi Shiro Utsuri', 'image_shiro_utsuri.jpg', 8, 2600.00, 'Japan', 1, 'No', 3.6, 56, 1, 1);

CREATE TABLE [dbo].[orderDetails]( 
 	[orderID] [nvarchar] (40) NOT NULL,  	
	[koiFishID] [int] NOT NULL, 
 	[quantity] int NOT NULL, 
 	[price] float NULL,
	[status] bit not null,
	CONSTRAINT [PK_orderDetail] PRIMARY KEY ([orderID], [koiFishID] ),
	CONSTRAINT [FK_koiFishDetail] FOREIGN KEY ([koiFishID])
	REFERENCES [dbo].[koiFish]([koiFishID]) ON DELETE CASCADE,
	CONSTRAINT [FK_orderDetail] FOREIGN KEY ([orderID])
	REFERENCES [dbo].[orders]([orderID]) ON DELETE CASCADE
);

INSERT INTO [dbo].[orders] ([orderID], [date], [userID], [serviceID], [totalMoney], [status])
VALUES 
    ('ORD001', '2024-11-01', 1, 1, 3000.00, 1),
    ('ORD002', '2024-11-02', 2, 2, 500.00, 1),
    ('ORD003', '2024-11-03', 3, 1, 1500.00, 1),
    ('ORD004', '2024-11-04', 4, 2, 1000.00, 0),
    ('ORD005', '2024-11-05', 5, 1, 2000.00, 1),
    ('ORD006', '2024-11-06', 6, 2, 750.00, 1),
    ('ORD007', '2024-11-07', 7, 1, 3500.00, 0),
    ('ORD008', '2024-11-08', 1, 2, 1200.00, 1),
    ('ORD009', '2024-11-09', 2, 1, 4000.00, 1),
    ('ORD010', '2024-11-10', 3, 2, 600.00, 0);

	INSERT INTO [dbo].[orderDetails] ([orderID], [koiFishID], [quantity], [price], [status])
VALUES 
    ('ORD001', 1, 2, 1500.00, 1),  -- 2 Koi Sanke at 1500.00 each
    ('ORD001', 3, 1, 1800.00, 1),  -- 1 Koi Showa at 1800.00 each
    ('ORD002', 2, 1, 2000.00, 1),  -- 1 Koi Kohaku at 2000.00 each
    ('ORD003', 4, 3, 2200.00, 1),  -- 3 Koi Asagi at 2200.00 each
    ('ORD004', 5, 2, 1750.00, 0);  -- 2 Koi Shusui at 1750.00 each, status inactive


	use KoiFish
ALTER TABLE orders DROP CONSTRAINT FK_order_service;