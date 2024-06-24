using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_SP.Source.Pages
{
    public partial class MP : System.Web.UI.MasterPage
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"]!=null)
            {
                int id = int.Parse(Session["usuariologueado"].ToString());
                using(con)
                {
                    using (SqlCommand cmd = new SqlCommand("Perfil", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        dr.Read();
                        this.lblUsuario.Text = dr["Apellidos"].ToString() + ", "+dr["Nombres"].ToString();
                        imagePerfil.ImageUrl = "/Source/Pages/FrmImagen.aspx?id=" + id;
                    }
                }
            }
            else
            {
                Response.Redirect("/Source/Pages/FrmLogin.aspx");
            }
        }

        protected void Perfil(object sender, EventArgs e)
        {
            Response.Redirect("/Source/Pages/FrmPerfil.aspx");
        }

        protected void Salir(object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Response.Redirect("/Source/Pages/FrmLogin.aspx");
        }
    }
}