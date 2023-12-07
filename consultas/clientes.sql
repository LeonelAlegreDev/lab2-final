CREATE TABLE clientes(
    id INT(10) NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(200) NOT NULL,
    email VARCHAR(200) NOT NULL UNIQUE,
    contrasena VARCHAR(200) NOT NULl,
    PRIMARY KEY(id)
) AUTO_INCREMENT=1;

CREATE TABLE empleados(
    id INT(10) NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(200) NOT NULL,
    email VARCHAR(200) NOT NULL UNIQUE,
    contrasena VARCHAR(200) NOT NULl,
    sueldo  INT(50) NOT NULL,
    PRIMARY KEY(id)
) AUTO_INCREMENT=1;

-- setea la contraseña del usuario root
ALTER USER 'root'@'localhost' IDENTIFIED BY 'secret_password';
