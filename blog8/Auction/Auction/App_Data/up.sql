
		CREATE TABLE [dbo].[Buyer]
		(
			ID            INT IDENTITY (1,1) NOT NULL,
			Name        NVARCHAR(30) NOT NULL,
			CONSTRAINT [PK_dbo.Buyer] PRIMARY KEY CLUSTERED (ID)
		);

		CREATE TABLE [dbo].[Seller]
		(
			ID            INT IDENTITY (1,1) NOT NULL,
			Name        NVARCHAR(30) NOT NULL,
			CONSTRAINT [PK_dbo.Seller] PRIMARY KEY CLUSTERED (ID)
		);

		CREATE TABLE [dbo].[Item]
		(
			ID            INT IDENTITY (1001,1) NOT NULL,
			Name        NVARCHAR(30) NOT NULL,
			Description NVARCHAR(100) NOT NULL,
			Seller        INT NOT NULL,
			CONSTRAINT [PK_dbo.Item] PRIMARY KEY CLUSTERED (ID ASC),
			CONSTRAINT [FK_dbo.Item] FOREIGN KEY (Seller) REFERENCES [dbo].[Seller] (ID)

		);

		CREATE TABLE [dbo].[Bid]
		(
			ID            INT IDENTITY (1,1) NOT NULL,
			ItemID        INT NOT NULL,
			Buyer        INT NOT NULL,
			Price        INT NOT NULL,
			TimeStamp    DATETIME NOT NULL
			CONSTRAINT [PK_dbo.Bid] PRIMARY KEY CLUSTERED (ID ASC),
			CONSTRAINT [FK_dbo.Bid] FOREIGN KEY (ItemID) REFERENCES [dbo].[Item] (ID),
			CONSTRAINT [FK2_dbo.Bid] FOREIGN KEY (Buyer) REFERENCES [dbo].[Buyer] (ID)

		);


		Insert INTO[dbo].[Buyer](Name) VALUES

		('Jane Stone'),
		('Tom McMasters'),
		('Otto Vanderwall')


		Insert INTO [dbo].[Seller](Name) VALUES

		('Gayle Hardy'),
		('Lyle Banks'),
		('Pearl Greene')

		Insert INTO[dbo].[Item](Name, Description, Seller) VALUES
		('Abraham Lincoln Hammer'    ,'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln',1),
		('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927',2),
		('Bob Dylan Love Poems'      ,'Five versions of an original unpublished, handwritten, love poem by Bob Dylan',3);

		Insert INTO[dbo].[Bid](ItemID, Buyer, Price, Timestamp) VALUES
		(1001, 1, 250000,'12/04/2017 09:04:22'),
		(1003,2, 95000 ,'12/04/2017 08:44:03');