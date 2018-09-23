CREATE TABLE [dbo].[Nota]
(
	[Id] BIGINT IDENTITY NOT NULL,
	[IdUsuario] BIGINT NOT NULL, 
    [IdCorretora] BIGINT NOT NULL, 
    [DataPregao] DATE NOT NULL, 
    [ValorLiquido] MONEY NOT NULL, 
    CONSTRAINT PK_Nota PRIMARY KEY(Id),
	CONSTRAINT [FK_Nota_01] FOREIGN KEY (IdUsuario) REFERENCES [Usuario]([Id]),
	CONSTRAINT [FK_Nota_02] FOREIGN KEY (IdCorretora) REFERENCES [Corretora]([Id])
)
