using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos
{
    class HelperDB
    {
        private SqlConnection cnn;

        public HelperDB()
        {
            cnn = new SqlConnection(@"Data Source=HP15-BS007LA\SQLEXPRESS;Initial Catalog=recetas_db;Integrated Security=True");
        }

        public DataTable EjecutarSql()
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("[SP_CONSULTAR_INGREDIENTES]",cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }

        public int ConsultaUltimo()
        {
            int ultimo;
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SP_ULTIMA_RECETA", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pOut = new SqlParameter("@next", SqlDbType.Int);
            pOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOut);
            cmd.ExecuteReader();

            ultimo = (int)pOut.Value;
            return ultimo;
        }

        public int ProximaReceta()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SP_ULTIMA_RECETA",cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pOut = new SqlParameter("@next",SqlDbType.Int);
            pOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOut);
            cmd.ExecuteReader();
            cnn.Close();
            int proximo = (int)pOut.Value;
            return proximo;
        }

        public bool Confirmar(Receta receta)
        {
            bool ok = true;
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("SP_INSERTAR_RECETA_1",cnn,t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tipo_receta",receta.TipoReceta);
                cmd.Parameters.AddWithValue("@nombre", receta.Nombre);
                cmd.Parameters.AddWithValue("@cheff", receta.Cheff);
                SqlParameter pOut = new SqlParameter("@receta_nro", SqlDbType.Int);
                pOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOut);

                cmd.ExecuteNonQuery();
                int receta_nro = (int)pOut.Value;
                //int cDetalle = 1;

                foreach (DetalleReceta det in receta.Detalle)
                {
                    SqlCommand cmdDet = new SqlCommand("SP_INSERTAR_DETALLES",cnn,t);
                    cmdDet.CommandType = CommandType.StoredProcedure;
                    cmdDet.Parameters.AddWithValue("@id_receta",receta_nro);
                    cmdDet.Parameters.AddWithValue("@id_ingrediente", det.Ingrediente);
                    cmdDet.Parameters.AddWithValue("@cantidad", det.Cantidad);

                    //cDetalle++;
                  
                }
                t.Commit();

            }
            catch (Exception)
            {
                t.Rollback();
                ok = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return ok;
        }

    }
}
