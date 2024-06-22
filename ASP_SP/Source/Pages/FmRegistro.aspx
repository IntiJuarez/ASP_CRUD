<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FmRegistro.aspx.cs" Inherits="ASP_SP.Source.Pages.FmRegistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="../JavaScript/JavaScript.js"></script>
    <title>Registro de usuarios</title>
</head>
<body>
    <form id="FmRegistro" runat="server">
        <div class="container d-flex justify-content-center">
            <div class="col-8">
                <div class="form-control card card-body">
                    <div class="row justify-content-center">
                        <asp:Label runat="server" CssClass="row justify-content-center h3">Registro de usuarios</asp:Label>
                    </div>
                    <fieldset>
                        <legend class="row justify-content-center">Datos personales</legend>
                        <div class="input-group">
                            <asp:Label ID="Label1" CssClass="form-control" runat="server" Text="Nombres:"></asp:Label>
                            <asp:TextBox ID="txtNombres" CssClass="form-control" runat="server" placeholder="ej.Luffy"></asp:TextBox>
                        </div>
                        <br />
                        <div class="input-group">
                            <asp:Label ID="Label2" CssClass="form-control" runat="server" Text="Apellidos:"></asp:Label>
                            <asp:TextBox ID="txtApellidos" CssClass="form-control" runat="server" placeholder="ej.Monkey D."></asp:TextBox>
                        </div>
                        <br />
                        <div class="input-group">
                            <asp:Label ID="Label3" CssClass="form-control" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                            <asp:TextBox ID="txtFecha" CssClass="form-control" runat="server" placeholder="Date"></asp:TextBox>
                        </div>
                    </fieldset>
                    <br />
                    <fieldset>
                        <legend>Datos de inicio de sesión</legend>
                        <div class="input-group">
                             <asp:Label ID="Label4" CssClass="form-control" runat="server" Text="Usuario:"></asp:Label>
                             <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server" placeholder="Usuario"></asp:TextBox>
                        </div>
                        <br />
                        <div class="input-group">
                            <asp:Label ID="Label5" CssClass="form-control" runat="server" Text="Clave:"></asp:Label>
                            <asp:TextBox ID="txtClave" CssClass="form-control" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                        </div>
                        <br />
                        <div class="input-group">
                            <asp:Label ID="Label6" CssClass="form-control" runat="server" Text="Repetir Clave:"></asp:Label>
                            <asp:TextBox ID="txtClave2" CssClass="form-control" runat="server" placeholder="Password Again" TextMode="Password"></asp:TextBox>
                        </div>
                        <br />
                        <div class="row justify-content-center">
                            <asp:Image runat="server" CssClass="img-thumbail" Width="150" Height="150" ImageUrl="~/Source/Images/user.png" />
                        </div>
                        <div class="row justify-content-center">
                            <asp:FileUpload runat="server" CssClass="small form-control" ID="FUImage" onchange="mostrarimagen(this)"/>
                        </div>
                    </fieldset>
                    <br />
                    <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label>
                    <br />
                    <div class="row">
                        <asp:Button runat="server" CssClass="form-control btn btn-success" text="Completar Registro" OnClick="Registrar" />
                        <hr />
                        <asp:Button runat="server" CssClass="form-control btn btn-warning" Text="Cancelar" OnClick="Cancelar" />
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
