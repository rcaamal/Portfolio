-- Users table
CREATE TABLE [dbo].[Users]
(
	[ID]		INT IDENTITY (1,1)	NOT NULL,
	[FirstName]	NVARCHAR(64)		NOT NULL,
	[LastName]	NVARCHAR(128)		NOT NULL,
	[PhoneNumber]	NVARCHAR(128)		NOT NULL,
	[AptName]	NVARCHAR(128)		NOT NULL,
	[UNumber]	NVARCHAR(128)		NOT NULL,
	[Explanation]	NVARCHAR(128)		NOT NULL,
	
	CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Users] (FirstName, LastName, PhoneNumber, AptName, UNumber, Explantion) VALUES
	('Randy','Johnson','1234567890','Maraco', '12', 'help'),
	('Sue','Suzanne','1233456789','Paris', '34', 'fix sink'),
	('Mira','Kuzak','1224324545','Salem', '4', 'bad lights'),
	('Erik','Sun','1234555543','Kip', '18', 'window broke'),
	('Mirna','Sue','1234556767','Parse', '37', 'Sink needs new pipe'),
	('Sofia','Castillo','1534567896','Salt', '32', 'new door')
GO