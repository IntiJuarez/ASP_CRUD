<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="ASP_SP.Source.Pages.FrmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

    <title>Inicio de sesión</title>
</head>
<body>
    <form id="FrmLogin" runat="server" class="container d-flex justify-content-center align-items-center">
        <div class="col-5">
            <div class="form-control card card-body align-items-center h3">
                <div class="modal-title align-content-center h3">
                     <asp:Label runat="server" Text="Inicio de sesion" Font-Size="Larger"></asp:Label>
                </div>
            </div>
            <br />
            <div class="input-group">
                <asp:TextBox runat="server" CssClass="form-control" placeholder="User" ID="txtUsuario"></asp:TextBox>
            </div>
            <br />
            <div class="input-group">
                <asp:TextBox runat="server" CssClass="form-control" TextMode="Password" placeholder="Password" ID="txtClave"></asp:TextBox>
            </div>
            <br />
            <div class="input-group">
                <asp:Button runat="server" CssClass="form-control btn btn-dark" Text="LOG IN" OnClick="Iniciar" />
            </div>
            <br />
            <br />
            <div>
                <asp:Label runat="server" ID="lblError" class="alert-danger"></asp:Label>
                <br />
                <asp:Label runat="server" Text="¿No tienes una cuenta?, Registrate"></asp:Label>
                <asp:LinkButton runat="server" Text="aquí" OnClick="Registrarse" ></asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
