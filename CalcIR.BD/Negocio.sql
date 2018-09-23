CREATE TABLE [dbo].[Negocio]
(
	[Id] BIGINT NOT NULL,
	[IdNota] BIGINT NOT NULL, 
    [IdMercado] BIGINT NOT NULL, 
    [IdTipoNegocio] BIGINT NOT NULL, 
	[IdPapel] BIGINT NOT NULL, 
    [Quantidade] INT NOT NULL, 
    [PrecoAjustado] MONEY NOT NULL, 
    CONSTRAINT PK_Negocio PRIMARY KEY(Id), 
    CONSTRAINT [FK_Negocio_01] FOREIGN KEY (IdNota) REFERENCES [Nota]([Id]),
	CONSTRAINT [FK_Negocio_02] FOREIGN KEY (IdMercado) REFERENCES [Mercado]([Id]),
	CONSTRAINT [FK_Negocio_03] FOREIGN KEY (IdTipoNegocio) REFERENCES [TipoNegocio]([Id]),
	CONSTRAINT [FK_Negocio_04] FOREIGN KEY (IdPapel) REFERENCES [Papel]([Id])
)
