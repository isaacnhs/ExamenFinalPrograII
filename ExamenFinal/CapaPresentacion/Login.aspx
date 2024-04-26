<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExamenFinal.CapaPresentacion.Login" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="formLogin" runat="server">
        <div class="container">
            <div class="row justify-content-center mt-5">
                <div class="col-lg-4">
                    <h2 class="text-center mb-4">Login</h2>
                    <div class="mb-3">
                        <label for="txtUsuario" class="form-label">Usuario</label>
                        <input type="text" id="txtUsuario" runat="server" class="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtContraseña" class="form-label">Contraseña</label>
                        <input type="password" id="txtContraseña" runat="server" class="form-control" />
                    </div>
                    <div class="mb-3">
                        <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="btnIniciarSesion_Click" />
                    </div>
                    <div id="mensaje" class="text-danger" runat="server"></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>