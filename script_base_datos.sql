CREATE TABLE ubicacion(
id_ubicacion SERIAL PRIMARY KEY,
nombre VARCHAR(100) NOT NULL
);

CREATE TABLE usuario(
id_usuario SERIAL PRIMARY KEY,
nombre VARCHAR(100) UNIQUE NOT NULL,
cargo VARCHAR(40) NOT NULL
);

CREATE TABLE equipos(
id_equipo SERIAL PRIMARY KEY,
tipo VARCHAR(20) NOT NULL,
nro_serie Varchar(30) UNIQUE NOT NULL,
estado VARCHAR(20) NOT NULL,
usuario INT REFERENCES usuario(id_usuario) NOT NULL,
ubicacion INT REFERENCES ubicacion(id_ubicacion) NOT NULL
);

INSERT INTO ubicacion (id_ubicacion, nombre) VALUES (1, 'Concepción');
INSERT INTO usuario (id_usuario, nombre, cargo) VALUES (2, 'Alberto Oses', 'Soporte TI');
INSERT INTO equipos (tipo, nro_serie, estado, usuario, ubicacion) VALUES ('Notebook', '77-44-55', 'Operativo', 2, 1);
