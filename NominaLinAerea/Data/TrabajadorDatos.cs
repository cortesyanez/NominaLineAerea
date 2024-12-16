using NominaLinAerea.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
namespace NominaLinAerea.Data
{
    public class TrabajadorDatos
    {
        public List<modeloTrabajadores> Listar(Int16 IDTra, Int16 numOper)
        {
            var ListTrabajadores = new List<modeloTrabajadores>();
            var con = new ConexionBD();
            using (var conexion = new SqlConnection(con.RegresaCadSQL()))
            {
               conexion.Open();
                SqlCommand comando = new SqlCommand("sp_ConsultaTrabajadores", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("idEmp", IDTra);
                comando.Parameters.AddWithValue("tipOp", numOper);
                using (var LectorDatos = comando.ExecuteReader())
                {
                    while (LectorDatos.Read())
                    {
                        idEmp_mod = Convert.ToInt16(LectorDatos([@idEmp])),
                        
                        ListTrabajadores.Add(new modeloTrabajadores());
                    }
                }
            }
        }
    }
}
