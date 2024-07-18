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
Fotografia nvarchar(max),
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
@Fotografia nvarchar(max),
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


alter PROCEDURE spActualizarEmpleado
@Nombre varchar(50),
@Fotografia nvarchar(max),
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
				Fotografia = case when @Fotografia = '' then Fotografia else @Fotografia end,
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


--delete Empleado where Id >= 4



select * from Empleado




--data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD

--update Empleado set Fotografia = 'data:image/jpeg;base64,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' 