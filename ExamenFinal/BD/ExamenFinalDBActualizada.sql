create DATABASE examenfinal
go
use examenfinal

CREATE TABLE Usuarios (
    ID INT identity PRIMARY KEY,
    Usuario VARCHAR(50) UNIQUE,
    Contrasena VARCHAR(100)
);
INSERT INTO Usuarios (Usuario, Contrasena)
VALUES ('Usuario', '12345');

CREATE TABLE Agentes (
    ID INT identity PRIMARY KEY,
    Nombre VARCHAR(50),
	Email VARCHAR(100),
	Telefono VARCHAR(8),
)
go

CREATE TABLE Clientes (
    ID INT identity PRIMARY KEY,
    Nombre VARCHAR(50),
    Email VARCHAR(100),
    Telefono VARCHAR(20)
)
go
CREATE TABLE Casas (
    ID INT identity PRIMARY KEY,
    Direccion VARCHAR(100),
    Ciudad VARCHAR(50),
    Precio DECIMAL(10, 2)
)
go
CREATE TABLE Ventas (
    ID INT identity PRIMARY KEY,
    ID_Agente INT,
    ID_Cliente INT,
    ID_Casa INT,
    Fecha DATE,
    FOREIGN KEY (ID_Agente) REFERENCES Agentes(ID),
    FOREIGN KEY (ID_Cliente) REFERENCES Clientes(ID),
    FOREIGN KEY (ID_Casa) REFERENCES Casas(ID)
);
GO

CREATE PROCEDURE GestionarAgentes
    @accion NVARCHAR(10),
    @agente_id INT = NULL,
    @agente_nombre NVARCHAR(50) = NULL,
    @agente_email NVARCHAR(100) = NULL,
    @agente_telefono NVARCHAR(20) = NULL
AS
BEGIN
    IF @accion = 'agregar'
    BEGIN
        INSERT INTO Agentes (Nombre, Email, Telefono) VALUES (@agente_nombre, @agente_email, @agente_telefono);
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM Agentes WHERE ID = @agente_id;
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE Agentes SET 
            Nombre = @agente_nombre,
            Email = @agente_email,
            Telefono = @agente_telefono
        WHERE ID = @agente_id;
    END
    ELSE IF @accion = 'consultar'
    BEGIN
        SELECT * FROM Agentes;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END
GO

CREATE PROCEDURE ObtenerAgentePorId
    @agente_id INT
AS
BEGIN
    SELECT ID, Nombre, Email, Telefono
    FROM Agentes
    WHERE ID = @agente_id;
END
GO

CREATE PROCEDURE GestionarClientes
    @accion NVARCHAR(10),
    @cliente_id VARCHAR(100) = NULL,
    @cliente_nombre NVARCHAR(50) = NULL,
    @cliente_email NVARCHAR(100) = NULL,
    @cliente_telefono NVARCHAR(20) = NULL
AS
BEGIN
    IF @accion = 'agregar'
    BEGIN
        INSERT INTO Clientes (Nombre, Email, Telefono) VALUES (@cliente_nombre, @cliente_email, @cliente_telefono);
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM Clientes WHERE ID = @cliente_id;
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE Clientes SET 
            Nombre = @cliente_nombre,
            Email = @cliente_email,
            Telefono = @cliente_telefono
        WHERE ID = @cliente_id;
    END
    ELSE IF @accion = 'consultar'
    BEGIN
        SELECT * FROM Clientes;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END
GO

CREATE PROCEDURE ObtenerClientePorId
    @cliente_id NVARCHAR(50)
AS
BEGIN
    SELECT ID, Nombre, Email, Telefono
    FROM Clientes
    WHERE ID = @cliente_id;
END
GO

CREATE PROCEDURE GestionarCasas
    @accion NVARCHAR(10),
    @casa_id INT = NULL,
    @casa_direccion VARCHAR(100) = NULL,
    @casa_ciudad VARCHAR(50) = NULL,
    @casa_precio DECIMAL(10, 2) = NULL
AS
BEGIN
    IF @accion = 'agregar'
    BEGIN
        INSERT INTO Casas (Direccion, Ciudad, Precio) VALUES (@casa_direccion, @casa_ciudad, @casa_precio);
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM Casas WHERE ID = @casa_id;
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE Casas SET 
            Direccion = @casa_direccion,
            Ciudad = @casa_ciudad,
            Precio = @casa_precio
        WHERE ID = @casa_id;
    END
    ELSE IF @accion = 'consultar'
    BEGIN
        SELECT * FROM Casas;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END
GO

CREATE PROCEDURE ObtenerCasaPorId
    @casa_id INT
AS
BEGIN
    SELECT * FROM Casas WHERE ID = @casa_id; 
END
GO

CREATE PROCEDURE GestionarVentas
    @accion NVARCHAR(10),
    @venta_id INT = NULL,
    @agente_id INT = NULL,
    @cliente_id INT = NULL,
    @casa_id INT = NULL,
    @fecha DATE = NULL
AS
BEGIN
    IF @accion = 'agregar'
    BEGIN
        INSERT INTO Ventas (ID_Agente, ID_Cliente, ID_Casa, Fecha) VALUES (@agente_id, @cliente_id, @casa_id, @fecha);
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM Ventas WHERE ID = @venta_id;
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE Ventas SET 
            ID_Agente = @agente_id,
            ID_Cliente = @cliente_id,
            ID_Casa = @casa_id,
            Fecha = @fecha
        WHERE ID = @venta_id;
    END
    ELSE IF @accion = 'consultar'
    BEGIN
        SELECT V.ID, A.Nombre AS NombreAgente, C.Nombre AS NombreCliente, CA.Direccion AS DireccionCasa, CA.Precio AS PrecioCasa, V.Fecha
        FROM Ventas V
        INNER JOIN Agentes A ON V.ID_Agente = A.ID
        INNER JOIN Clientes C ON V.ID_Cliente = C.ID
        INNER JOIN Casas CA ON V.ID_Casa = CA.ID;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END
GO

CREATE PROCEDURE ObtenerVentaPorId
    @venta_id INT
AS
BEGIN
    SELECT V.ID AS VentaID, A.ID AS AgenteID, C.ID AS ClienteID, CS.ID AS CasaID, A.Nombre AS Agente, C.Nombre AS Cliente, CS.Direccion AS CasaDireccion, V.Fecha
    FROM Ventas V
    INNER JOIN Agentes A ON V.ID_Agente = A.ID
    INNER JOIN Clientes C ON V.ID_Cliente = C.ID
    INNER JOIN Casas CS ON V.ID_Casa = CS.ID
    WHERE V.ID = @venta_id;
END
GO

CREATE PROCEDURE ValidarUsuario
    @Usuario VARCHAR(50),
    @Contrasena VARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE Usuario = @Usuario AND Contrasena = @Contrasena)
        SELECT 'Validado' AS Estado;
    ELSE
        SELECT 'NoValidado' AS Estado;
END
