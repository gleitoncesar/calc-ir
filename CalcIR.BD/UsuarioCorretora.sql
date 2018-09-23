CREATE TABLE [dbo].[UsuarioCorretora]
(
	[Id] BIGINT IDENTITY NOT NULL, 
    [IdUsuario] BIGINT NOT NULL, 
    [IdCorretora] BIGINT NOT NULL,
	CONSTRAINT PK_UsuarioCoretora PRIMARY KEY(Id),
	CONSTRAINT [FK_UsuarioCorretora_01] FOREIGN KEY (IdUsuario) REFERENCES [Usuario]([Id]),
	CONSTRAINT [FK_UsuarioCorretora_02] FOREIGN KEY (IdCorretora) REFERENCES [Corretora]([Id]),
)
