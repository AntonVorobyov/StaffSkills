﻿CREATE TABLE [dbo].[Position]
(
	[Id] INT NOT NULL IDENTITY(1000, 1), 
    [Title] NVARCHAR(250) NOT NULL,

    CONSTRAINT [PK_Position_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
)
