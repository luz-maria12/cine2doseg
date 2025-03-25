using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using Newtonsoft.Json.Linq;



namespace cine2doseg.Models
{
    public class clsSucursalDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        public DataSet vwRptSucursales()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM vwRptSucursales", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public int spInsSucursales(string nombre, string direccion, string url, string logo)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("spInsSucursales", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_nombre", nombre);
                cmd.Parameters.AddWithValue("p_direccion", direccion);
                cmd.Parameters.AddWithValue("p_homeweb", url);
                cmd.Parameters.AddWithValue("p_logo", logo);

                MySqlParameter bandera = new MySqlParameter("p_bandera", MySqlDbType.Int32);
                bandera.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(bandera);

                cmd.ExecuteNonQuery();
                return Convert.ToInt32(bandera.Value);
            }
        }
    }
}
