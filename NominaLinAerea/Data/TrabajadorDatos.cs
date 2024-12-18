using NominaLinAerea.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using NominaLinAerea.Data;
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
                        ListTrabajadores.Add(new modeloTrabajadores()
                        {
                            IdEmp_mod = Convert.ToInt16(LectorDatos["id_Emp"]),
                            NomEmp_mod = LectorDatos["nom_emp"].ToString(),
                            ApaEmp_mod = LectorDatos["apa_emp"].ToString(),
                            SexEmp_mod = LectorDatos["sex_emp"].ToString(),
                            FNaEmp_mod = Convert.ToDateTime(LectorDatos["fna_emp"]),
                            IdBar_mod = Convert.ToInt16(LectorDatos["id_bar_emp"]),
                            IdPue_mod = Convert.ToInt16(LectorDatos["id_pue_emp"]),
                            IdTipTra_mod = Convert.ToInt16(LectorDatos["id_tiptra_emp"]),
                        });
                    }
                }
            }
            return ListTrabajadores;
        }
    


public modeloTrabajadores RegresaTrabajador(Int16 IdTrabajador, Int16 tipOper)
        {
            var Trabajador = new modeloTrabajadores();
            var con = new ConexionBD();

            using (var conexion = new SqlConnection(con.RegresaCadSQL()))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_ConsultaTrabajadores", conexion);
                comando.Parameters.AddWithValue("idEmp", IdTrabajador);
                comando.Parameters.AddWithValue("tipOp", tipOper);
                comando.CommandType = CommandType.StoredProcedure;
                using (var LectorDatos = comando.ExecuteReader())
                {
                    while (LectorDatos.Read())
                    {
                        Trabajador.IdEmp_mod = Convert.ToInt16(LectorDatos["id_emp"]);
                        Trabajador.NomEmp_mod = LectorDatos["nom_emp"].ToString();
                        Trabajador.ApaEmp_mod = LectorDatos["apa_emp"].ToString();
                        Trabajador.SexEmp_mod = LectorDatos["sex_emp"].ToString();
                        Trabajador.FNaEmp_mod = Convert.ToDateTime(LectorDatos["fna_emp"]);
                        Trabajador.IdBar_mod = Convert.ToInt16(LectorDatos["id_bar_emp"]);
                        Trabajador.IdPue_mod = Convert.ToInt16(LectorDatos["id_pue_emp"]);
                        Trabajador.IdTipTra_mod = Convert.ToInt16(LectorDatos["id_tiptra_emp"]);
                    }
                }
            }
            return Trabajador;
        }

        public bool EliminaTrabajador(Int16 IdTrabajador)
        {
            bool exito;

            try
            {
                var con = new ConexionBD();

                using (var conexion = new SqlConnection(con.RegresaCadSQL()))
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("sp_EliminaTrabajador", conexion);
                    comando.Parameters.AddWithValue("@idEmp", IdTrabajador);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.ExecuteNonQuery();

                }
                exito = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                exito = false;
            }
            return exito;
        }

        public bool GuardaModificaTrabajador(modeloTrabajadores Trabajador, Int16 tipOper)
        {
            bool exito = false;
            //string nombreSP = "";

            try
            {
                var con = new ConexionBD();

                using (var conexion = new SqlConnection(con.RegresaCadSQL()))
                {
                    conexion.Open();

                    SqlCommand comando = new SqlCommand("sp_AdministrarTrabajadores", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("idEmp", Convert.ToInt16(Trabajador.IdEmp_mod));
                    comando.Parameters.AddWithValue("nomEmp", Trabajador.NomEmp_mod).ToString();
                    comando.Parameters.AddWithValue("apaEmp", Trabajador.ApaEmp_mod).ToString();
                    comando.Parameters.AddWithValue("sexEmp", Trabajador.SexEmp_mod).ToString();
                    comando.Parameters.AddWithValue("fnaEmp", Convert.ToDateTime(Trabajador.FNaEmp_mod));
                    comando.Parameters.AddWithValue("idBarEmp", Convert.ToInt16(Trabajador.IdBar_mod));
                    comando.Parameters.AddWithValue("idPueEmp", Convert.ToInt16(Trabajador.IdPue_mod));
                    comando.Parameters.AddWithValue("idTipTraEmp", Convert.ToInt16(Trabajador.IdTipTra_mod));
                    comando.Parameters.AddWithValue("TipOp", tipOper);
                    comando.ExecuteNonQuery();
                }
                exito = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                exito = false;
            }
            return exito;
        }
    }
}