﻿CREATE TABLE [dbo].[Usuario]
(
	[Id] BIGINT IDENTITY NOT NULL, 
    [Nome] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Usuario PRIMARY KEY (Id)
)
