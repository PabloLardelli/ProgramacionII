create database CARRERAS
go

use CARRERAS
go

create table Asignatura(
id_asignatura int,
nombre varchar(50)
constraint pk_Asignatura primary key (id_asignatura)
)

create table Carrera(
id_carrera int identity,
titulo varchar(50),
constraint pk_Carrera primary key (id_carrera),
)

create table DetalleCarrera(
id_detalle int,
anioCursado int,
cuatrimestre int,
asignatura int,
id_carrera int
constraint pk_DetalleCarrera primary key (id_detalle),
constraint fk_DetalleCarrera_Asignatura foreign key (asignatura)
	references Asignatura (id_asignatura),
constraint fk_DetalleCarrera_Carrera foreign key (id_carrera)
	references Carrera (id_carrera)
)


insert into Asignatura
			Values    (1, 'Estadistica'),
					  (2, 'Matematica'),
					  (3, 'Programacion'),
					  (4, 'Quimica')


create proc SP_CARGAR_ASIGNATURA
as
select * from Asignatura 

exec SP_CARGAR_ASIGNATURA


CREATE PROCEDURE SP_PROXIMO_ID
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(id_carrera)+1  FROM Carrera);
END


CREATE PROCEDURE SP_INSERTAR_MAESTRO 
	@titulo varchar(50), 
	@carrera_nro int OUTPUT
AS
BEGIN
	INSERT INTO Carrera(titulo)
    VALUES (@titulo);
    --Asignamos el valor del último ID autogenerado (obtenido --  
    --mediante la función SCOPE_IDENTITY() de SQLServer)	
    SET @carrera_nro = SCOPE_IDENTITY();

END
GO


CREATE PROCEDURE SP_INSERTAR_DETALLE
	@carrera_nro int,
	@detalle int, 
	@asignatura int, 
	@año int,
	@cuatrimestre int
AS
BEGIN
	INSERT INTO DetalleCarrera(id_detalle, anioCursado, cuatrimestre, asignatura, id_carrera)
    VALUES (@detalle, @año, @cuatrimestre, @asignatura, @carrera_nro);
  
END

select * from Carrera
delete Carrera