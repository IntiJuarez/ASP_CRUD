﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;


namespace ASP_SP.Source.Pages
{
    
    public partial class FrmPerfil : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Session["usuariologueado"].ToString());
            if (Session["usuariologueado"] ==null)
            {
                Response.Redirect("/Source/Pages/FrmLogin.aspx");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Perfil", con);
                 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    image.ImageUrl = "/Source/Pages/FrmImagen.aspx?id=" + id;
                    this.tbNombres.Text = dr["Nombres"].ToString();
                    this.tbApellidos.Text = dr["Apellidos"].ToString();
                    this.tbFecha.Text = dr["Fecha"].ToString();
                    //tbFecha.Text = DateTime.Now.ToString("dd-mm-yyyy");
                    this.tbUsuario.Text = dr["Usuario"].ToString();
                    dr.Close();
                }
                con.Close();
            }
        }

        void MetodoOcultar()
        {
            if(contrasenia.Visible==false)
            {
                contrasenia.Visible = true;
                btnGuardar.Visible = true;
                btnCambiar.Text = "Cancelar";
                lblErrorClave.Text = "";
            }
            else
            {
                contrasenia.Visible = false;
                btnGuardar.Visible = false;
                btnCambiar.Text = "Cambiar contraseña";
                lblErrorClave.Text = "";

            }
        }

        protected void BtnAplicar_Click(object sender, EventArgs e)
        {
            int tamanioarchivo;
            byte[] imagen = FUImage.FileBytes;
            tamanioarchivo = int.Parse(FUImage.FileContent.Length.ToString());
            if (tamanioarchivo >= 20971)
            {
                lblError.Text = "El tamaño de la imagen debe ser menor a 10 Mb";
            }
            else if (FUImage.HasFile)
            {
                try
                {
                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand("CambiarImagen", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = imagen;
                            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            lblError.Text = "";
                        }
                    }
                }
                catch (Exception exx)
                {
                    lblError.Text = exx.Message;
                }

            }

            else
            {
                lblError.Text = "No se ha cargado una imagen de perfil nueva";
            }
        }

        protected void BtnCambiar_Click(object sender, EventArgs e)
        {
            MetodoOcultar();
        }

        protected void Eliminar(object sender, EventArgs e)
        {
            using(con)
            {
                using (SqlCommand cmd = new SqlCommand("Eliminar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Session.Remove("usuariologueado");
                    Response.Redirect("/Source/Pages/FrmLogin.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string contraseniasinverificar = tbClave.Text;
            Regex letras = new Regex(@"[a-zA-Z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex especiales = new Regex("[!\"#\\$&'()*+,-./:;=?@\\[\\]{|}~]");

            if (tbClave.Text ==""|| tbClave2.Text=="")
            {
                lblError.Text = "Los campos no pueden quedar vacíos!";
            }
            else if (!letras.IsMatch(contraseniasinverificar))
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
            else
            {
                try
                {
                    using(con)
                    {
                        using (SqlCommand cmd = new SqlCommand("CambiarContraseña", con))
                        {
                            string patron = "IntiNahuel";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                            cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = tbClave.Text;
                            cmd.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MetodoOcultar();
                            lblErrorClave.Text = "";
                        }
                    }
                }
                catch(Exception ex)
                {
                    lblErrorClave.Text = ex.Message;
                }
            }
        }
    }
}