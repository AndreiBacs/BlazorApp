
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[Department] [nvarchar](max) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[Tasks] [nvarchar](max) NOT NULL,
	[IsArchived] [bit] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employee] ADD  DEFAULT ((0)) FOR [IsArchived]

GO

INSERT INTO [dbo].[Employee]([LastName],[FirstName],[Department],[EntryDate],[Tasks],[IsArchived]) VALUES ('Mark','Weiss','Comunications',GETDATE(),'Task1',0)
INSERT INTO [dbo].[Employee]([LastName],[FirstName],[Department],[EntryDate],[Tasks],[IsArchived]) VALUES ('Andrew','Low','IT',GETDATE(),'Task2',0)
INSERT INTO [dbo].[Employee]([LastName],[FirstName],[Department],[EntryDate],[Tasks],[IsArchived]) VALUES ('Jimmy','John','IT',GETDATE(),'Task2',0)
INSERT INTO [dbo].[Employee]([LastName],[FirstName],[Department],[EntryDate],[Tasks],[IsArchived]) VALUES ('Dan','Devito','Staff',GETDATE(),'Task2',0)
INSERT INTO [dbo].[Employee]([LastName],[FirstName],[Department],[EntryDate],[Tasks],[IsArchived]) VALUES ('Rachel','Weiss','Staff',GETDATE(),'Task2',0)
INSERT INTO [dbo].[Employee]([LastName],[FirstName],[Department],[EntryDate],[Tasks],[IsArchived]) VALUES ('Tania','Weiss','IT',GETDATE(),'Task2,Task3',0)
GO