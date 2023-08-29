# 📁 Proyectos de CRUD en .NET Windows Forms con patrón MVC

En estos tres proyectos, se desarrollarán aplicaciones de Windows Forms utilizando el patrón de diseño Modelo-Vista-Controlador (MVC) para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en bases de datos relacionales. Cada proyecto se enfocará en interactuar con una base de datos diferente, utilizando vistas diseñadas para facilitar las acciones CRUD mientras se incorporan validadores de usuario.

## Proyecto 1: CRUD de Clientes

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


## Proyecto 2: CRUD de Clientes y Videos

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


## Proyecto 3: CRUD Avanzado

### Funcionalidades

1. 📝 Operaciones CRUD avanzadas en la tercera base de datos.
2. 🖼️ Diseño de vistas adecuado para las necesidades específicas.
3. 🔒 Validadores de usuario para asegurar la integridad de los datos.