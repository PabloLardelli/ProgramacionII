using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Carreras.Dominio;

namespace Carreras.Datos
{
    class HelperDB
    {
        private SqlConnection cnn;

        public HelperDB()
        {
            cnn = new SqlConnection(@"Data Source=HP15-BS007LA\SQLEXPRESS;Initial Catalog=CARRERAS;Integrated Security=True");

        }

        public DataTable ConsultaSql(string consulta)
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand(consulta, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }

        public bool Confirmar(Carrera oCarrera)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("SP_INSERTAR_MAESTRO",cnn,t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@titulo",oCarrera.Titulo);

                SqlParameter pOut = new SqlParameter("@carrera_nro", SqlDbType.Int);
                pOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOut);
                cmd.ExecuteNonQuery();

                int cDetalle = 1;
                int carrera_nro = (int)pOut.Value;

                SqlCommand cmdDet;
                foreach (DetalleCarrera det in oCarrera.Detalles)
                {
                    cmdDet = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    cmdDet.CommandType = CommandType.StoredProcedure;
                    cmdDet.Parameters.AddWithValue("@carrera_nro", carrera_nro);
                    cmdDet.Parameters.AddWithValue("@detalle", cDetalle);
                    cmdDet.Parameters.AddWithValue("@asignatura", det.Asignatura);
                    cmdDet.Parameters.AddWithValue("@año", det.AnioCursado);
                    cmdDet.Parameters.AddWithValue("@cuatrimestre", det.Cuatrimestre);

                    //cmdDet.ExecuteNonQuery();
                    cDetalle ++;
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
                if(cnn.ConnectionString != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return ok;
        }


    }
}
