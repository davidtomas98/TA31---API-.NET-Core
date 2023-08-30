# 📁 Ejercicios de CRUD en .NET Windows Forms con patrón MVC

En estos tres Ejercicios, se desarrollarán aplicaciones de Windows Forms utilizando el patrón de diseño Modelo-Vista-Controlador (MVC) para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en bases de datos relacionales. Cada proyecto se enfocará en interactuar con una base de datos diferente, utilizando vistas diseñadas para facilitar las acciones CRUD mientras se incorporan validadores de usuario.

## Ejercicio 1: CRUD de Clientes

### Base de Datos

```sql
CREATE TABLE 'cliente' (
    id int (11) NOT NULL AUTO_INCREMENT,
    nombre varchar (250) DEFAULT NULL,
    apellido varchar (250) DEFAULT NULL,
    direccion varchar (250) DEFAULT NULL,
    dni int(11) DEFAULT NULL,
    fecha date DEFAULT NULL,
    PRIMARY KEY (id)
);
```

### Funcionalidades

1. 📝 Crear, 📖 Leer, 🔄 Actualizar y 🗑️ Eliminar clientes.
2. 🖼️ Vistas diseñadas para cada acción CRUD.
3. 🔒 Validadores de usuario implementados para garantizar la integridad de los datos.


## Ejercicio 2: CRUD de Clientes y Videos

### Base de Datos

```sql
CREATE TABLE 'cliente' (
    id int (11) NOT NULL AUTO_INCREMENT,
    nombre varchar(250) DEFAULT NULL,
    apellido varchar (250) DEFAULT NULL,
    direccion varchar (250) DEFAULT NULL,
    dni int(11) DEFAULT NULL,
    fecha date DEFAULT NULL,
    PRIMARY KEY (id)
);
```
```sql
CREATE TABLE 'videos' (
    id int (11) NOT NULL AUTO_INCREMENT,
    title varchar (250) DEFAULT NULL,
    director varchar (250) DEFAULT NULL,
    cli_id int (11) DEFAULT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (cli_id) REFERENCES cliente (id)
);
```

### Funcionalidades

1. 📝 Realizar operaciones CRUD en clientes y videos.
2. 🖼️ Vistas diseñadas para interactuar con ambas tablas.
3. 🔒 Validadores de usuario implementados para mantener la consistencia de los datos.


## Ejercicio 3: CRUD Avanzado

### Base de Datos

-- Tabla CIENTIFICOS
```sql
CREATE TABLE 'CIENTIFICOS' (
    DNI varchar (8) NOT NULL AUTO_INCREMENT,
    NomApels nvarchar(255) DEFAULT NULL,
    PRIMARY KEY (DNI)
);
```

-- Tabla PROYECTO
```sql
CREATE TABLE 'PROYECTO' (
    id char (4) NOT NULL AUTO_INCREMENT,
    Nombre nvarchar(255) DEFAULT NULL,,
    Horas nvarchar(255) DEFAULT NULL,
    PRIMARY KEY (id)
);
```

-- Tabla ASIGNADO_A
```sql
CREATE TABLE 'ASIGNADO_A' (
    Cientifico varchar(8) DEFAULT NULL,
    Proyecto char(4) DEFAULT NULL,
    PRIMARY KEY (Cientifico, Proyecto),
    FOREIGN KEY (Cientifico) REFERENCES CIENTIFICOS(DNI),
    FOREIGN KEY (Proyecto) REFERENCES PROYECTO(Id)
);
```

### Funcionalidades

1. 📝 Operaciones CRUD avanzadas en la tercera base de datos.
2. 🖼️ Diseño de vistas adecuado para las necesidades específicas.
3. 🔒 Validadores de usuario para asegurar la integridad de los datos.