using System.Data.SqlClient;

namespace NominaLinAerea.Data
{
    public class ConexionBD
    {
        private string cadSQL = string.Empty;

        public ConexionBD() 
        {
            var ObtenConBD = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            cadSQL = ObtenConBD.GetSection("ConnectionStrings:ParametroSQL").Value;

        }

        public string RegresaCadSQL()
        {
            return cadSQL;
        }

    }
}
