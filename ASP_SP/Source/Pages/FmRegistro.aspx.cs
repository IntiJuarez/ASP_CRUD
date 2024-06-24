using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ASP_SP.Source.Pages
{
    public partial class FmRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cancelar(object sender, EventArgs e)
        {
            Response.Redirect("/Source/Pages/FrmLogin.aspx");
        }
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Registrar(object sender, EventArgs e)
        {
            int tamanioImagen = int.Parse(FUImage.FileContent.Length.ToString());
            string contraseniasinverificar = txtClave.Text;
            Regex letras = new Regex(@"[a-zA-Z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex especiales = new Regex("[!\"#\\$&'()*+,-./:;=?@\\[\\]{|}~]");
            con.Open();

            SqlCommand usuario = new SqlCommand("ContarUsuario", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            
            usuario.Parameters.Add("@usuario", SqlDbType.VarChar).Value = txtUsuario.Text;
            int user = Convert.ToInt32(usuario.ExecuteScalar());
            if(txtNombres.Text==""||txtApellidos.Text==""||txtFecha.Text==""||txtUsuario.Text=="")
            {
                lblError.Text = "Los campos no pueden quedar vacios!";
            }
            else if(user >=1)
            {
                lblError.Text = "El usuario " + txtUsuario.Text + "ya existe!";
            }
            else if(txtClave.Text!=txtClave2.Text)
            {
                lblError.Text = "Las contraseñas no coinciden!";
            }
            else if(!letras.IsMatch(contraseniasinverificar))
            {
                lblError.Text = "Las contraseñas deben tener letras!";
            }
            else if (!numeros.IsMatch(contraseniasinverificar))
            {
                lblError.Text = "Las contraseñas deben tener numeros!";
            }
            else if (!especiales.IsMatch(contraseniasinverificar))
            {
                lblError.Text = "Las contraseñas deben tener caracteres especiales!";
            }
            else if(!FUImage.HasFile)
            {
                lblError.Text = "No se ha cargado una imagen de perfil!";
            }
            else if(tamanioImagen>= 2097151000)
            {
                lblError.Text = "El tamaño de la imagen no puede ser mayor a 10 Mb!";
            }
            else
            {
                byte[] imagen = FUImage.FileBytes;
                string patron = "IntiNahuel";
                using(con)
                {
                    using(SqlCommand cmd = new SqlCommand("Registrar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = txtNombres.Text;
                        cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = txtApellidos.Text;
                        cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = txtFecha.Text;
                        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = txtUsuario.Text;
                        cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = txtClave.Text;
                        cmd.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;
                        cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = imagen;
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = 0;
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    Response.Redirect("/Source/Pages/FrmLogin.aspx");
                }
            }
        }
    }
}