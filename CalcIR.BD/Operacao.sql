CREATE TABLE [dbo].[Operacao]
(
	[Id] BIGINT IDENTITY NOT NULL,
	[IdUsuario] BIGINT NOT NULL, 
    [IdPapel] BIGINT NOT NULL, 
    [Quantidade] INT NOT NULL, 
    [ValorMedio] MONEY NOT NULL,
	[DataInicio] DATE NOT NULL, 
	[DataFim] DATE NULL, 
    [Resultado] MONEY NULL, 
    CONSTRAINT PK_Operacao PRIMARY KEY(Id),
	CONSTRAINT [FK_Operacao_01] FOREIGN KEY (IdUsuario) REFERENCES [Usuario]([Id]),
	CONSTRAINT [FK_Operacao_02] FOREIGN KEY (IdPapel) REFERENCES [Papel]([Id]),
)
