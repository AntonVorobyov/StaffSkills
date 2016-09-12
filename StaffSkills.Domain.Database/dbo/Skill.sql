CREATE TABLE [dbo].[Skill]
(
	[Id] INT NOT NULL IDENTITY(1000, 1), 
    [Title] NVARCHAR(150) NOT NULL,
	[PositionId] INT NOT NULL,

    CONSTRAINT [PK_Skill_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Skill_PositionId] FOREIGN KEY([PositionId]) REFERENCES [dbo].[Position] ([Id])
)
