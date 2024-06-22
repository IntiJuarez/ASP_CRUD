using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_SP.Source.Pages
{
    public partial class FrmImagen : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologeado"]==null)
            {
                Response.Redirect("/Source/Pages/FrmLogin.aspx");
            }
            else
            {
               using(con)
                {
                    using (SqlCommand cmd=new SqlCommand("CargarImagen", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Request.QueryString["id"];
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            byte[] imagen = (byte[])dr["Imagen"];
                            Response.BinaryWrite(imagen);
                        }
                    }
                }
            }
        }
    }
}