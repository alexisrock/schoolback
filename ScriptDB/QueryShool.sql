CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameUsuario] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Idrol] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Ro] FOREIGN KEY([Idrol])
REFERENCES [dbo].[Rol] ([Id])
GO

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Ro]
GO

CREATE TABLE [dbo].[Configuration](
	[Id] [nvarchar](255) NOT NULL,
	[Value] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE TABLE Curso(
Id INT PRIMARY KEY IDENTITY,
Descripcion NVARCHAR(400)
);

GO



CREATE TABLE Estudiante(
Id INT PRIMARY KEY IDENTITY,
IdUsuario INT,
IdCurso INT,
CONSTRAINT  Fk_IdUsuario_Estudiante FOREIGN KEY(IdUsuario)
REFERENCES Usuario(Id),
CONSTRAINT  Fk_IdCurso_Estudiante FOREIGN KEY(IdCurso)
REFERENCES Curso(Id)
);
GO

CREATE TABLE Materia(
Id INT PRIMARY KEY IDENTITY,
Descripcion NVARCHAR(400)
);

GO

CREATE TABLE Profesor(
Id INT PRIMARY KEY IDENTITY,
IdUsuario INT,
Profesion NVARCHAR(255),
CONSTRAINT  Fk_IdUsuario_Profesor FOREIGN KEY(IdUsuario)
REFERENCES Usuario(Id)
);


GO


CREATE TABLE MateriaProfesor(
Id INT PRIMARY KEY IDENTITY,
IdMateria INT,
IdProfesor INT,
CONSTRAINT  Fk_IdMateria_MateriaProfesor FOREIGN KEY(IdMateria)
REFERENCES Materia(Id),
CONSTRAINT  Fk_IdProfesor_MateriaProfesor FOREIGN KEY(IdProfesor)
REFERENCES Estudiante(Id)
);

GO

CREATE TABLE InscripcionMateria(
Id INT PRIMARY KEY IDENTITY,
IdMateriaProfesor INT,
IdEstudiante INT,
CONSTRAINT  Fk_IdMateriaProfesor_InscripcionMateria FOREIGN KEY(IdMateriaProfesor)
REFERENCES Materia(Id),
CONSTRAINT  Fk_IdEstudiante_InscripcionMateria FOREIGN KEY(IdEstudiante)
REFERENCES Estudiante(Id),
);

GO
INSERT [dbo].[Configuration] ([Id], [Value]) VALUES (N'IVEncrypted', N'UIGEmQDh')
INSERT [dbo].[Configuration] ([Id], [Value]) VALUES (N'JwtAudienceToken', N'http://190.66.12.50:8909')
INSERT [dbo].[Configuration] ([Id], [Value]) VALUES (N'JwtExpireTime', N'600')
INSERT [dbo].[Configuration] ([Id], [Value]) VALUES (N'JwtIssuerToken', N'http://190.66.12.50:8909')
INSERT [dbo].[Configuration] ([Id], [Value]) VALUES (N'JwtSecretKey', N'MIIEBAKCAQEAqCAqEALgjhNplvRhv4HE7XR3R9jCBqpU+DcPb')
INSERT [dbo].[Configuration] ([Id], [Value]) VALUES (N'KeyEncrypted', N'abcdefghijklmnopqrstuvwx')

GO
INSERT [dbo].[Rol]([Description]) VALUES (N'Profesor')
INSERT [dbo].[Rol]([Description]) VALUES (N'Estudiante')
GO


GO
INSERT [dbo].[Curso]([Descripcion]) VALUES (N'Desarrollo web')
INSERT [dbo].[Curso]([Descripcion]) VALUES (N'ciencia de datos')
 INSERT [dbo].[Curso]([Descripcion]) VALUES (N'infraestructura')
GO


INSERT  [dbo].[Materia] ([Descripcion]) VALUES (N'Estructuras de datos')
INSERT  [dbo].[Materia]([Descripcion]) VALUES (N'Algoritmos I')
INSERT  [dbo].[Materia]([Descripcion]) VALUES (N'Algoritmos II')
INSERT  [dbo].[Materia]([Descripcion]) VALUES (N'Base de datos')
INSERT [dbo].[Materia]([Descripcion]) VALUES (N'programacion profunda')
INSERT  [dbo].[Materia]([Descripcion]) VALUES (N'Base de datos II')
INSERT [dbo].[Materia]([Descripcion]) VALUES (N'diseño web')
INSERT [dbo].[Materia]([Descripcion]) VALUES (N'sistemas operativos')
INSERT [dbo].[Materia]([Descripcion]) VALUES (N'infraestructura como codigo')
INSERT  [dbo].[Materia] ([Descripcion]) VALUES (N'Terraform')

GO
 

 CREATE PROCEDURE SPMateriasProfesor
 AS
 BEGIN

	SELECT 
	MP.Id,
	MP.IdMateria,
	M.Descripcion,
	MP.IdProfesor,
	U.NameUsuario
	FROM MateriaProfesor AS MP
	INNER JOIN Materia AS M ON MP.IdMateria = M.iD
	INNER JOIN Profesor AS P ON  MP.IdProfesor = P.Id
	INNER JOIN Usuario AS U ON P.IdUsuario = U.Id
 END


 
GO


 CREATE PROCEDURE SPEstudiantesByProfesor
   @IdProfesor INT,
   @IdMateria INT
 AS
 BEGIN

	SELECT 
	U.NameUsuario AS Estudiante,
	U.Email	
	FROM InscripcionMateria AS IM
	INNER JOIN Estudiante AS E ON IM.IdEstudiante = E.Id
	INNER JOIN Usuario AS U ON E.IdUsuario = U.Id
	INNER JOIN MateriaProfesor AS MP ON IM.IdMateriaProfesor = MP.Id
	INNER JOIN Profesor AS P ON  MP.IdProfesor = P.Id
	INNER JOIN Usuario AS UP ON P.IdUsuario = UP.Id
	WHERE
	MP.IdProfesor = @IdProfesor AND MP.IdMateria = @IdMateria
 END


 
GO


CREATE PROCEDURE SPEstudiantesMaterias
   @IdMateria INT
 AS
 BEGIN

	SELECT 
	U.NameUsuario AS Estudiante,
	U.Email,
	UP.NameUsuario AS Profesor
	FROM InscripcionMateria AS IM
	INNER JOIN Estudiante AS E ON IM.IdEstudiante = E.Id
	INNER JOIN Usuario AS U ON E.IdUsuario = U.Id
	INNER JOIN MateriaProfesor AS MP ON IM.IdMateriaProfesor = MP.Id
	INNER JOIN Profesor AS P ON  MP.IdProfesor = P.Id
	INNER JOIN Usuario AS UP ON P.IdUsuario = UP.Id
	WHERE
	MP.IdMateria = @IdMateria
 END

 
GO


CREATE PROCEDURE SPMateriasEstudiante
   @Idusuario INT
 AS
 BEGIN

	SELECT 
	M.Id As MateriaId,
	M.Descripcion as Materia,
	UP.NameUsuario AS Profesor
	FROM InscripcionMateria AS IM
	INNER JOIN Estudiante AS E ON IM.IdEstudiante = E.Id
	INNER JOIN Usuario AS U ON E.IdUsuario = U.Id
	INNER JOIN MateriaProfesor AS MP ON IM.IdMateriaProfesor = MP.Id
	INNER JOIN Materia AS M on MP.IdMateria = M.Id
	INNER JOIN Profesor AS P ON  MP.IdProfesor = P.Id
	INNER JOIN Usuario AS UP ON P.IdUsuario = UP.Id
	WHERE
	U.Id = @Idusuario
 END

 GO

 CREATE PROCEDURE SPMateriasByIdProfesor
   @Idusuario INT
 AS
 BEGIN

	SELECT 
	M.Id As MateriaId,
	M.Descripcion as Materia
	FROM MateriaProfesor AS MP
	INNER JOIN Materia AS M on MP.IdMateria = M.Id
	INNER JOIN Profesor AS P ON  MP.IdProfesor = P.Id
	INNER JOIN Usuario AS UP ON P.IdUsuario = UP.Id
	WHERE
	UP.Id = @Idusuario
 END


 