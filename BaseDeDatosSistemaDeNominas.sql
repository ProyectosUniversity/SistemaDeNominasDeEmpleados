

------- BASE DE DATOS DEL SISTEMA DE NOMINAS DE EMPLEADOS-------

--Carpetas Disco C:\

xp_create_subdir 'C:\SistemaDeNominas\Principal'
go

xp_create_subdir 'C:\SistemaDeNominas\Contratos'
go

xp_create_subdir 'C:\SistemaDeNominas\Pagos'
go

xp_create_subdir 'C:\SistemaDeNominas\Logs'
go

--Carpetas Disco D:\
xp_create_subdir 'D:\SistemaDeNominas\Principal'
go

xp_create_subdir 'D:\SistemaDeNominas\Contratos'
go

xp_create_subdir 'D:\SistemaDeNominas\Pagos'
go

xp_create_subdir 'D:\SistemaDeNominas\Logs'
go

--------CREACION DE LA BASE DE DATOS Y SUS GRUPOS DE ARCHIVOS-------
if not exists(select * from sys.databases where name='SistemaDeNominas')
  Begin
    Create database SistemaDeNominas
	  ON PRIMARY
	    (name = 'Pr1', filename = 'C:\SistemaDeNominas\Principal\Pr1.mdf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	    (name = 'Pr2', filename = 'D:\SistemaDeNominas\Principal\Pr2.mdf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	  filegroup Contratos
	    (name = 'Cr1', filename = 'C:\SistemaDeNominas\Contratos\Cr1.ndf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	    (name = 'Cr2', filename = 'D:\SistemaDeNominas\Contratos\Cr2.ndf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	  filegroup Pagos
	    (name = 'P1', filename = 'C:\SistemaDeNominas\Pagos\P1.ndf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	    (name = 'P2', filename = 'D:\SistemaDeNominas\Pagos\P2.ndf',Size=10MB,maxsize=200MB,filegrowth=10MB)
	  LOG ON
	    (name = 'Log_1', filename = 'C:\SistemaDeNominas\Logs\Log_1.ldf',Size=5MB,maxsize=100MB,filegrowth=10MB),
	    (name = 'Log_2', filename = 'D:\SistemaDeNominas\Logs\Log_2.ldf',Size=5MB,maxsize=100MB,filegrowth=10MB)
    end
go


--------USO DE LA BASE DE DATOS-------
if exists(select * from sys.databases where name='SistemaDeNominas')
    Begin    
		use SistemaDeNominas
    End
go
--------CREACION DE ESQUEMAS-------
if not exists (select * from sys.schemas WHERE name = 'Contratos' or name = 'Pagos')
	Begin
		Exec('Create schema Contratos')
		Exec('Create schema Pagos')
	End
go


--------TIPOS DE DATOS DEFINIDOS POR EL USUARIO-------
if not exists (select * from sys.types where name = 'Codigo' or name = 'Texto' or  name = 'Calculo')  
   Begin
        Create type Codigo from nchar(6) not null
		Create type Texto from varchar(50) not null
        Create type Calculo from numeric(9,2) not null
    End
go

--------FUNCIONES DE PARTICION-------
if not exists (select * from sys.partition_functions where name = 'ContratosFuncionParticion'  or name = 'PagosFuncionParticion' )
   Begin
       Create partition function ContratosFuncionParticion (nchar(6))
	           as range right for values ('D','G') 
       Create partition function PagosFuncionParticion (nchar(6))
	           as range for values ('E','H')
    end
go

--------ESQUEMAS DE PARTICION-------
if not exists (select * from sys.partition_schemes where name = 'ContratosEsquemaParticion'  
               or name = 'PagosEsquemaParticion' )
  Begin
    exec('Create partition scheme ContratosEsquemaParticion As partition ContratosFuncionParticion 
	        to ([Primary], Contratos,Pagos)')
     exec('Create partition scheme PagosEsquemaParticion As partition 
	 PagosFuncionParticion 
	        to (Contratos,Pagos,[Primary])')
	end
go

--------TABLAS DE LA BASE DE DATOS-------

--TABLA EMPLEADO
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Contratos' and TABLE_NAME='Empleado')
Begin
    create table Contratos.Empleado
    (CodigoEmpleado Codigo,
	DNIEmpleado char(8) not null,
	Nombre Texto,
	Direccion nvarchar(200) not null,
    Telefono nchar(9) not null,
	FechaDeNacimiento DATE,
	EstadoCivil varchar(100) not null,
	GradoAcademico varchar(100) not null
	constraint CodigoEmpleadoPK primary key  (CodigoEmpleado)
    )on  ContratosEsquemaParticion  (CodigoEmpleado)
end
go

--TABLA AFP
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Pagos' and TABLE_NAME='AFP')
Begin
    create table Pagos.AFP
    (CodigoAFP Codigo,
	PorcentajeDeDescuento Calculo default 0,
	constraint CodigoAFPPK primary key  (CodigoAFP)
    )on  PagosEsquemaParticion  (CodigoAFP)
end
go

--TABLA CONTRATO
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Contratos' and TABLE_NAME='Contrato' )
Begin
    create table Contratos.Contrato
    (CodigoContrato  Codigo,
     FechaInicio DATE default GetDate(),
     FechaFin DATE,
     Cargo varchar(100) not null,
	 AsignacionFamiliar char(2) not null,
	 TotalDeHorasContratadasPorSemanas Calculo,
	 ValorHora Calculo,
	 CodigoEmpleado Codigo,
	 CodigoAFP Codigo,
	 constraint AsignacionFamiliarCK check(AsignacionFamiliar='Si' or AsignacionFamiliar='No'),
	 constraint FechaInicioCK check (FechaInicio < FechaFin),
	 constraint FechaFinCK check (FechaFin > FechaInicio),
	 constraint TotalDeHorasContratadasPorSemanasCK check (TotalDeHorasContratadasPorSemanas >= 8 or TotalDeHorasContratadasPorSemanas <= 40),
	 constraint CodigoContratoPK primary key  (CodigoContrato),
	 constraint CodigoEmpleadoFK foreign key (CodigoEmpleado) references Contratos.Empleado(CodigoEmpleado),
	 constraint CodigoAFPFK foreign key (CodigoAFP) references Pagos.AFP(CodigoAFP)
     )on  ContratosEsquemaParticion(CodigoContrato)
end
go

alter table  Contratos.Contrato add Estado varchar(10) default 'Vigente'
go

alter table Contratos.Contrato add constraint EstadoCheck check (Estado='Vigente' or Estado='Anulado')
go


--TABLA PERIODO
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Contratos' and TABLE_NAME='Periodo' )
Begin
    create table Contratos.Periodo
    (CodigoPeriodo  Codigo ,
     FechaInicio DATE default GetDate(),
     FechaFin DATE,
     Estado nchar(1) not null,
	 constraint FechaInicio_CK check (FechaInicio < FechaFin),
	 constraint FechaFin_CK check (FechaFin > FechaInicio),
	 constraint EstadoCK check (Estado='Activo' or Estado='Inactivo'),
	 constraint CodigoPeriodoPK primary key  (CodigoPeriodo)
     )on  ContratosEsquemaParticion(CodigoPeriodo)
end
go


--TABLA BOLETA
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Pagos' and TABLE_NAME='Boleta' )
Begin
    create table Pagos.Boleta
    (CodigoBoleta  Codigo,
     TotalDeIngresos Calculo default 0,
     TotalDeDescuento Calculo default 0,
     TotalDeHoras Calculo default 0,
	 SueldoNeto Calculo default 0,
	 AsginacionFamiliar Calculo default 0,
	 DescuentoPorAFP Calculo default 0,
	 FechaPago Date,
	 Codigo_ConceptoDePago Codigo,
	 CodigoContrato Codigo
	 constraint CodigoBoletaPK primary key  (CodigoBoleta),
	 constraint CodigoContratoFK foreign key (CodigoContrato) references Contratos.Contrato(CodigoContrato)
     )on  PagosEsquemaParticion(CodigoBoleta)
end
go

--TABLA CONCEPTODEPAGO
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Pagos' and TABLE_NAME='ConceptoDePago' )
Begin
    create table Pagos.ConceptoDePago
    (CodigoConceptoDePago  Codigo,
     SumaDeIngresos Calculo default 0,
	 SumaDeDescuentos Calculo default 0,
	 Codigo_ConceptoDePago Codigo,
	 CodigoPeriodo Codigo
	 constraint CodigoConceptoDePagoPK primary key  (CodigoConceptoDePago),
	 constraint CodigoPeriodoFK foreign key (CodigoPeriodo) references Contratos.Periodo(CodigoPeriodo)
     )on  PagosEsquemaParticion(CodigoConceptoDePago)
end
go



-------- SECUENCIAS PARA LOS CODIGOS ------

--Secuencia para Empleado
 if not exists(select * from sys.sequences where name= 'SecEmpleado')
    Begin
      create sequence Contratos.SecEmpleado
      as bigint
      START  with 1
      INCREMENT by 1
      MINVALUE 0
	  NO MAXVALUE
	End
 go

 --Secuencias para Contrato
 if not exists(select * from sys.sequences where name= 'SecContrato')
    Begin
	   create sequence Contratos.SecContrato
       as bigint
       START  with 1
       INCREMENT by 1
       MINVALUE 0
	   NO MAXVALUE
	End
 go

 --Secuencias para Periodo
 if not exists(select * from sys.sequences where name= 'SecPeriodo')
    Begin
      create sequence Contratos.SecPeriodo
      as bigint
      START  with 1
      INCREMENT by 1
      MINVALUE 0
	  NO MAXVALUE
    End
 go

 --Secuencias para AFP
  if not exists(select * from sys.sequences where name= 'SecAFP')
    Begin
      create sequence Pagos.SecAFP
      as bigint
      START  with 1
      INCREMENT by 1
      MINVALUE 0
	  NO MAXVALUE
    End
 go

 --Secuencias para Boleta
 if not exists(select * from sys.sequences where name= 'SecBoleta')
    Begin
      create sequence Pagos.SecBoleta
      as bigint
      START  with 1
      INCREMENT by 1
      MINVALUE 0
	  NO MAXVALUE
    End
 go

  --Secuencias para ConceptoDePago
 if not exists(select * from sys.sequences where name= 'SecConceptoDePago')
    Begin
      create sequence Pagos.SecConceptoDePago
      as bigint
      START  with 1
      INCREMENT by 1
      MINVALUE 0
	  NO MAXVALUE
    End
 go



 --------CREACION DE INDICES-------

 --------PROCEDIMIENTOS ALMACENADOS PARA EMPLEADO-------

 --Agregar Empleado
 if not exists (select * from sys.procedures where name='Contratos.spAgregarEmpleado')
  Begin
     exec('create procedure Contratos.spAgregarEmpleado
            @DNIEmpleado char(8),
			@Nombre varchar(50),
			@Direccion nvarchar(200),
			@Telefono nchar(9),
			@FechaDeNacimiento date,
			@EstadoCivil varchar(100),
			@GradoAcademico varchar(100)
			as
			insert into Contratos.Empleado values (next value for 
			   Contratos.SecEmpleado, @DNIEmpleado, @Nombre, @Direccion, @Telefono, @FechaDeNacimiento,
			   @EstadoCivil,@GradoAcademico)')
  end
go


 --Buscar Empleado
create procedure Contratos.spBuscarEmpleado
    @DNIEmpleado varchar(8)
	as
	select E.CodigoEmpleado as "Codigo" ,E.Nombre as "Nombre", E.Direccion as "Direccion", E.Telefono as "Telefono", E.FechaDeNacimiento as "Fecha de Nacimiento", E.EstadoCivil as "Estado Civil", E.GradoAcademico as "Grado Academico" from Contratos.Empleado as E where E.DNIEmpleado like @DNIEmpleado +'%'

--Mostrar Empleado
 if not exists (select * from sys.procedures where name='Contratos.spMostrarEmpleado')
  Begin
     exec('create procedure Contratos.spMostrarEmpleado
			as
			select CodigoEmpleado as "Codigo",Nombre as "Nombre", Direccion as "Direccion", Telefono as "Telefono",FechaDeNacimiento as "Fecha de Nacimiento", EstadoCivil as "Estado Civil", GradoAcademico as "Grado Academico" from Contratos.Empleado')
  end
go


--Agregar AFP
if not exists (select * from sys.procedures where name='Pagos.spAgregarAFP')
  Begin
    exec(' create procedure Pagos.spAgregarAFP
           @PorcentajeDeDescuento numeric(9,2)
			as
			insert into Pagos.AFP values (next value for 
			   SecAFP,@PorcentajeDeDescuento )')
  end
go

--Listar AFP
if not exists (select * from sys.procedures where name='Pagos.spListarAFP')
  Begin
    exec('create procedure Pagos.spListarAFP
			as
			select * from Pagos.AFP')
  end
go


 --Crear Contrato
 if not exists (select * from sys.procedures where name='Contratos.spCrearContrato')
  Begin
    exec('create procedure Contratos.spCrearContrato
            @FechaInicio date,
			@FechaFin date,
			@Cargo varchar(100),
			@AsignacionFamiliar char(2),
			@TotalDeHorasContratadasPorSemanas numeric(9,2),
			@ValorHora numeric(9,2),
			@CodigoEmpleado nchar(6),
			@CodigoAFP nchar(6),
			@Estado varchar(10)
			as
			insert into Contratos.Contrato values (next value for 
			   Contratos.SecContrato, @FechaInicio, @FechaFin, @Cargo,  @AsignacionFamiliar,@TotalDeHorasContratadasPorSemanas,
			   @ValorHora,@CodigoEmpleado,@CodigoAFP,@Estado)')
  end
go


--Editar Contrato
if not exists (select * from sys.procedures where name='Contratos.spEditarContrato')
  Begin
    exec('create procedure Contratos.spEditarContrato
            @CodigoContrato nchar(6),
            @FechaInicio date,
			@FechaFin date,
			@Cargo varchar(100),
			@AsignacionFamiliar char(2),
			@TotalDeHorasContratadasPorSemanas numeric(9,2),
			@ValorHora numeric(9,2),
			@CodigoEmpleado nchar(6),
			@CodigoAFP nchar(6),
			@Estado varchar(10)
     as
	   update Contratos.Contrato  set  FechaInicio= @FechaInicio, FechaFin = @FechaFin, Cargo = @Cargo,AsignacionFamiliar = @AsignacionFamiliar,TotalDeHorasContratadasPorSemanas = @TotalDeHorasContratadasPorSemanas,ValorHora = @ValorHora,CodigoEmpleado = @CodigoEmpleado,CodigoAFP = @CodigoAFP,Estado=@Estado where CodigoContrato = @CodigoContrato')
  end
go

--Anular Contrato
 create procedure Contratos.spCambiarEstado
            @CodigoContrato nchar(6),
            @Estado varchar(10)
     as
	   update Contratos.Contrato set  Estado=@Estado where CodigoContrato = @CodigoContrato
	   go


--Mostrar Contrato de un Empleado
 if not exists (select * from sys.procedures where name='Contratos.spMostrarContrato')
  Begin
    exec('create procedure Contratos.spMostrarContrato
     @CodigoEmpleado nchar(6)
     as
	   select  C.CodigoContrato as "Codigo",C.FechaInicio as "Fecha Inicio",C.FechaFin as "Fecha Fin", C.Cargo as "Cargo", C.AsignacionFamiliar as "Asignacion Familiar", (select A.PorcentajeDeDescuento from Pagos.AFP as A where A.CodigoAFP= C.CodigoAFP) as AFP,C.TotalDeHorasContratadasPorSemanas as "Total de Horas Contratadas por Semana", C.ValorHora as "Valor Hora",C.CodigoEmpleado as "Codigo Empleado",C.Estado as "Estado" from Contratos.Contrato as C where C.CodigoEmpleado=@CodigoEmpleado')
  end
go 




--INSERCIONES--

--Agregar Empleados
  exec Contratos.spAgregarEmpleado 75318053,'Francisco','Av. America 452', 967582412,'1998-07-17','soltero','secundaria'

  exec Contratos.spAgregarEmpleado 17863287,'Usuario2','Av. Larco 124', 977812400,'1996-10-21','casado','bachiller'
--Insertando AFP
  exec Pagos.spAgregarAFP 13
  exec Pagos.spAgregarAFP 12

 --Crear Contrato
   exec Contratos.spCrearContrato '2019-10-24','2020-05-15','Trabajador','No',30,8,1,1
 --Editar Contrato
   exec Contratos.spEditarContrato 1,'2019-10-24','2020-05-15','Empleado','Si',30,8,1,1

  
go


exec Contratos.spMostrarContrato 2

exec Contratos.spMostrarEmpleado

exec Contratos.spCrearContrato 
'2019-10-24','2020-08-15','Empleado','Si',30,8,2,2,'Vigente'
select * from Contratos.Contrato where CodigoEmpleado=2