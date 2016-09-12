CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL IDENTITY(1000, 1), 
    [Name] NVARCHAR(250) NOT NULL,
	[PositionId] INT NOT NULL,

    CONSTRAINT [PK_Employee_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Employee_PositionId] FOREIGN KEY([PositionId]) REFERENCES [dbo].[Position] ([Id])
)
