BEGIN

CREATE DATABASE "Lirmi"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
	
create table "Colegios"(
	"Id" bigserial not null primary key,
	"Nombre" varchar(150) not null,
	"Activo" boolean not null 
);

create table "Cursos"(
	"Id" bigserial not null primary key,
	"ColegioId" bigint not null,
	"Nombre" varchar(150) not null,
	"Activo" boolean not null,
	 CONSTRAINT fk_Colegio_Cursos
      FOREIGN KEY("ColegioId") 
      REFERENCES "Colegios"("Id")
);

create table "Asignaturas"(
	"Id" bigserial not null primary key,
	"Nombre" varchar(150) not null,
	"Activo" boolean not null
);

create table "Curso_Asignaturas"(
     "Id" bigserial not null primary key,
	 "CursoId" bigint not null,
	 "AsignaturaId" bigint not null,
	 CONSTRAINT fk_Curso_Asignaturas_Asignaturas
      FOREIGN KEY("AsignaturaId") 
      REFERENCES "Asignaturas"("Id"),
	 CONSTRAINT fk_Curso_Asignaturas_Cursos
      FOREIGN KEY("CursoId") 
      REFERENCES "Cursos"("Id")
);	
	

END


