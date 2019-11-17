

-------BASE DE DATOS DEL SISTEMA DE NOMINAS DE EMPLEADOS-------

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

xp_create_subdir ':\SistemaDeNominas\Logs'
go

--------CREACION DE LA BASE DE DATOS Y SUS GRUPOS DE ARCHIVOS-------
if not exists(select * from sys.databases where name='SistemaDeNominas')
  Begin
    Create database SistemaDeNominas
	  ON PRIMARY
	    (name = 'C1', filename = 'C:\SistemaDeNominas\Principal\C1.mdf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	    (name = 'P2', filename = 'D:\productos\principal\C2.mdf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	  filegroup Contratos
	    (name = 'Pr1', filename = 'C:\SistemaDeNominas\Contratos\Cr1.ndf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	    (name = 'Pr2', filename = 'D:\SistemaDeNominas\Contratos\Cr2.ndf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	  filegroup Almacen
	    (name = 'P1', filename = 'C:\SistemaDeNominas\Pagos\P1.ndf',Size=10MB,maxsize=200MB,filegrowth=10MB),
	    (name = 'P2', filename = 'D:\SistemaDeNominas\Pagos\P2.ndf',Size=10MB,maxsize=200MB,filegrowth=10MB)
	  LOG ON
	    (name = 'Log_1', filename = 'C:\SistemaDeNominas\Logs\Log_1.ldf',Size=5MB,maxsize=100MB,filegrowth=10MB),
	    (name = 'Log_2', filename = 'D:\SistemaDeNominas\logs\Log_2.ldf',Size=5MB,maxsize=100MB,filegrowth=10MB)
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
if not exists (select * from sys.types where name = 'Codigo' or name = 'Texto' or  name = 'TextoNumerico')  
   Begin
        Create type Codigo from nchar(8) not null
		Create type Texto from varchar(100) not null
        Create type TextoNumerico from nvarchar(200) not null
    End
go

--------FUNCIONES DE PARTICION-------
if not exists (select * from sys.partition_functions where name = 'ContratosFuncionParticion'  or name = 'PagosFuncionParticion' )
   Begin
       Create partition function ContratosFuncionParticion (nchar(8))
	           as range right for values ('D','G','J') 
       Create partition function PagosFuncionParticion (nchar(8))
	           as range for values ('E','H','k')
    end
go

--------ESQUEMAS DE PARTICION-------
if not exists (select * from sys.partition_schemes where name = 'ContratosEsquemaParticion'  
               or name = 'PagosEsquemaParticion' )
  Begin
    exec(' Create partition scheme ContratosEsquemaParticion As partition ContratosFuncionParticion 
	        to ([Primary], Contratos,[Primary], Pagos)')
     exec('Create partition scheme PagosEsquemaParticion As partition PagosFuncionParticio 
	        to (Contratos,Pagos,Contratos,Pagos)')
	end
go

--------TABLAS DE LA BASE DE DATOS-------

--TABLA EMPLEADO
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Contratos' and TABLE_NAME='Empleado')
Begin
    create table Contratos.Empleado
    (CodigoEmpleado Codigo,
	DNIEmpleado nchar(8) not null,
	Nombre Texto ,
	Direccion TextoNumerico,
    Telefono nchar(9) not null,
	FechaDeNacimiento DATE,
	EstadoCivil varchar(1) not null,
	GradoAcademico varchar(1) not null
	constraint CodigoEmpleadoPK primary key  (CodigoEmpleado),
    )on  ContratoEsquemaParticion  (CodigoEmpleado)
end
go

--TABLA AFP
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Pagos' and TABLE_NAME='AFP')
Begin
    create table Pagos.AFP
    (CodigoAFP Codigo,
	PorcentajeDeDescuento numeric(9,2) not null,
	constraint CodigoAFPPK primary key  (CodigoAFPPK),
    )on  PagosEsquemaParticion  (CodigoAFP)
end
go

--TABLA CONTRATO
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Contrato' and TABLE_NAME='Contrato' )
Begin
    create table Contrato.Contrato
    (CodigoContrato  Codigo ,
     FechaInicio DATE ,
     FechaInicio DATE,
     Cargo varchar(1) not null,
	 AsignacionFamiliar char(1) not null,
	 TotalDeHorasContratadasPorSemanas time not null,
	 ValorHora numeric(9,2) not null,
	 constraint CodigoContratoPK primary key  (CodigoContrato),
	 constraint CodigoEmpleadoFK foreign key (CodigoEmpleado) references Contrato.CodigoEmpleado(CodigoEmpleado),
	 constraint CodigoAFPFK foreign key (CodigoAFP) references Pagos.AFP(CodigoAFP)
     )on  ContratoEsquemaParticion(CodigoContrato)
end
go

--TABLA PERIODO
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Contrato' and TABLE_NAME='Periodo' )
Begin
    create table Contrato.Contrato
    (CodigoPeriodo  Codigo ,
     FechaInicio DATE ,
     FechaInicio DATE,
     Estado char(1) not null,
	 constraint CodigoPeriodoPK primary key  (CodigoPeriodo)
     )on  ContratoEsquemaParticion(CodigoContrato)
end
go


--TABLA BOLETA
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Pagos' and TABLE_NAME='Boleta' )
Begin
    create table Pagos.Boleta
    (CodigoBoleta  Codigo ,
     TotalDeIngresos numeric(9,2) not null,
     TotalDeDescuento numeric(9,2) not null,
     TotalDeHoras time,
	 SueldoNeto numeric(9,2) not null,
	 AsginacionFamiliar numeric(9,2) not null,
	 DescuentoPorAFP numeric(9,2) not null,
	 Codigo_ConceptoDePago Codigo,
	 constraint CodigoBoletaPK primary key  (CodigoBoleta),
	 constraint CodigoContratoFK foreign key (CodigoContrato) references Contrato.Contrato(CodigoContrato)
     )on  PagosEsquemaParticion(CodigoBoleta)
end
go

--TABLA CONCEPTODEPAGO
if not exists (select * from Information_Schema.Tables WHERE TABLE_SCHEMA = 'Pagos' and TABLE_NAME='ConceptoDePago' )
Begin
    create table Pagos.ConceptoDePago
    (CodigoConceptoDePago  Codigo ,
     SumaDeIngresos numeric(9,2),
	 SumaDeDescuentos numeric(9,2),
	 Codigo_ConceptoDePago Codigo,
	 constraint CodigoBoletaPK primary key  (CodigoBoleta),
	 constraint CodigoPeriodoFK foreign key (CodigoPeriodo) references Contrato.Contrato(CodigoPeriodo)
     )on  PagosEsquemaParticion(CodigoConceptoDePago)
end
go