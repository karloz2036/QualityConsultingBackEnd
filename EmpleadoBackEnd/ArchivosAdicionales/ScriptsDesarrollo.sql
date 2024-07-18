/*

create table Estados(
Id int identity(1,1) primary key not null,
Nombre varchar(25) not null
)

insert into Estados values 
('Aguascalientes'), ('Baja California'), ('Baja California Sur'), ('Campeche'), ('Coahuila'), ('Colima'), ('Chiapas'), ('Chihuahua'), ('CDMX')



create table Puestos(
Id int identity(1,1) primary key not null,
Nombre varchar(25) not null
)

insert into Puestos values 
('Gerente'), ('Coordinador'), ('Desarrollador')

select * from estados
select * from Puestos


--drop table Empleado
create table Empleado(
Id int identity(1,1) primary key not null,
Fotografia varchar(max),
Nombre varchar(max) not null,
Apellido varchar(max) not null,
PuesotId int references Puestos(Id) not null ,
FechaNacimiento date not null,
FechaContratacion date not null,
Direccion varchar(max) not null,
Telefono varchar(max) not null,
CorreoElectronico varchar(max) not null,
EstadoId int references Estados(Id) not null
)

insert into Empleado values 
('fotoCarlos.jpg', 'Carlos', 'Chávez', 2, '1986-02-19', GETDATE(), 'calle 1 num 1234 col del valle', '5556581111', 'correoCarlos@ejemplo.com', 9),
('fotoJuan.jpg', 'Juan', 'Pérez', 3, '1980-01-25', GETDATE(), 'calle 2 num 1233 col anzures', '5556581112', 'correoJuan@ejemplo.com', 2),
('fotoAndrea.jpg', 'Andrea', 'González', 1, '1980-01-25', GETDATE(), 'calle 3 num 12334 col narvarte', '5556581113', 'correoAndrea@ejemplo.com', 4)


alter procedure spObtenerEmpleados
as 
begin 

	select e.Id,e.Fotografia,e.Nombre,e.Apellido,p.Id PuestoId,p.Nombre Puesto,e.FechaNacimiento,e.FechaContratacion,e.Direccion,e.Telefono,e.CorreoElectronico,est.Id EstadoId,est.nombre Estado 
	from Empleado e
	inner join Puestos p on p.Id = e.PuesotId
	inner join Estados est on est.Id = e.EstadoId

end

exec spObtenerEmpleados


create procedure spObtenerPuestos
as 
begin 

	select Id, Nombre
	from Puestos

end

exec spObtenerPuestos


create procedure spObtenerEstados
as 
begin 

	select Id, Nombre
	from Estados

end

exec spObtenerEstados



alter PROCEDURE spAgregarEmpleado
@Nombre varchar(50),
@Fotografia varchar(50),
@Apellido varchar(50),
@PuestoId int,
@FechaNacimiento date,
@FechaContratacion date,
@Direccion varchar(50),
@Telefono varchar(50),
@CorreoElectronico varchar(50),
@EstadoId varchar(50)

AS 
BEGIN 

	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

	BEGIN TRY
		 -- Inicia el bloque de la transaccion
		BEGIN TRANSACTION;
			insert into Empleado (Nombre,Fotografia,Apellido,PuesotId,FechaNacimiento,FechaContratacion,Direccion,Telefono,CorreoElectronico,EstadoId) 
			values (@Nombre,isnull(@Fotografia, ''),@Apellido,@PuestoId,@FechaNacimiento,@FechaContratacion,@Direccion,@Telefono,@CorreoElectronico,@EstadoId)

		COMMIT TRANSACTION;
		-- Indica que la operación se efectuo correctamente
		SELECT '1' AS resultado;    
	END TRY
	
	/* Manejo de error de la transacción */
	BEGIN CATCH
		SELECT 'spagregarEmpleados: ' + ERROR_MESSAGE() AS resultado; 
		ROLLBACK TRANSACTION;
	END CATCH

END

create PROCEDURE spEliminarEmpleado
@EmpleadoId int

AS 
BEGIN 

	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

	BEGIN TRY
		 -- Inicia el bloque de la transaccion
		BEGIN TRANSACTION;
			
			delete Empleado where Id =  @EmpleadoId

		COMMIT TRANSACTION;
		-- Indica que la operación se efectuo correctamente
		SELECT '1' AS resultado;    
	END TRY
	
	/* Manejo de error de la transacción */
	BEGIN CATCH
		SELECT 'spEliminarEmpleado: ' + ERROR_MESSAGE() AS resultado; 
		ROLLBACK TRANSACTION;
	END CATCH

END


create PROCEDURE spActualizarEmpleado
@Nombre varchar(50),
@Fotografia varchar(50),
@Apellido varchar(50),
@PuestoId int,
@FechaNacimiento date,
@FechaContratacion date,
@Direccion varchar(50),
@Telefono varchar(50),
@CorreoElectronico varchar(50),
@EstadoId varchar(50),
@Id int

AS 
BEGIN 

	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

	BEGIN TRY
		 -- Inicia el bloque de la transaccion
		BEGIN TRANSACTION;

			update Empleado
			set Nombre = @Nombre,
				Fotografia = @Fotografia,
				Apellido = @Apellido,
				PuesotId = @PuestoId,
				FechaNacimiento = @FechaNacimiento,
				FechaContratacion = @FechaContratacion,
				Direccion = @Direccion,
				Telefono = @Telefono,
				CorreoElectronico = @CorreoElectronico,
				EstadoId = @EstadoId
			where Id = @Id

		COMMIT TRANSACTION;
		-- Indica que la operación se efectuo correctamente
		SELECT '1' AS resultado;    
	END TRY
	
	/* Manejo de error de la transacción */
	BEGIN CATCH
		SELECT 'spActualizarEmpleado: ' + ERROR_MESSAGE() AS resultado; 
		ROLLBACK TRANSACTION;
	END CATCH

END
*/


--delete Empleado where Id >= 7










