using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_SP.Source.Pages
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Registrarse(object sender, EventArgs e)
        {
            Response.Redirect("/Source/Pages/FmRegistro.aspx");
        }

        protected void Iniciar(object sender, EventArgs e)
        {
            if(txtUsuario.Text==""||txtClave.Text=="")
            {
                lblError.Text = "Los campos no pueden quedar vacios";
            }
            else
            {
                string patron = "IntiNahuel";
                using(con)
                {
                    using (SqlCommand cmd= new SqlCommand("Validar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = txtUsuario.Text;
                        cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = txtClave.Text;
                        cmd.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            Session["usuariologueado"] = dr["Id"].ToString();
                            Response.Redirect("/Source/Pages/FrmIndex.aspx");
                        }
                        else
                        {
                            lblError.Text = "Usuario o contraseña incorrecta";
                        }
                        con.Close();
                    }
                }
            }
        }
    }
}