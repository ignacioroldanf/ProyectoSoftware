using Microsoft.Data.SqlClient;
using System;
using System.IO;
using System.Linq;

namespace Controlador
{
    public class CtrlBackup
    {
        private string _cadenaMaster = "Server=LegionNachi\\SQLSERVER;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";
        private string _nombreDB = "Diploma";
        private string _rutaSeguridad = @"C:\Backups\"; 

        public string GenerarBackup()
        {
            if (!Directory.Exists(_rutaSeguridad))
            {
                Directory.CreateDirectory(_rutaSeguridad);
            }

            string fechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string rutaDestino = $"{_rutaSeguridad}{_nombreDB}_{fechaHora}.bak";

            using (SqlConnection conn = new SqlConnection(_cadenaMaster))
            {
                conn.Open();

                string queryShrink = $@"
                    ALTER DATABASE [{_nombreDB}] SET RECOVERY SIMPLE;
                    USE [{_nombreDB}]; 
                    DBCC SHRINKFILE ('{_nombreDB}_log', 1);
                    USE master;
                    ALTER DATABASE [{_nombreDB}] SET RECOVERY FULL;";

                using (SqlCommand cmdShrink = new SqlCommand(queryShrink, conn))
                {
                    cmdShrink.ExecuteNonQuery();
                }

                string queryBackup = $@"
                    BACKUP DATABASE [{_nombreDB}] 
                    TO DISK = '{rutaDestino}' 
                    WITH FORMAT, INIT, 
                    NAME = 'Copia de Seguridad Completa de SAG', 
                    SKIP, NOREWIND, NOUNLOAD, STATS = 10;";

                using (SqlCommand cmdBackup = new SqlCommand(queryBackup, conn))
                {
                    cmdBackup.ExecuteNonQuery();
                }
            }

            return rutaDestino;
        }

        public void RestaurarBackup(string rutaOrigen)
        {
            using (SqlConnection conn = new SqlConnection(_cadenaMaster))
            {
                conn.Open();

                string query = $@"
                    ALTER DATABASE [{_nombreDB}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    RESTORE DATABASE [{_nombreDB}] FROM DISK = '{rutaOrigen}' WITH REPLACE;
                    ALTER DATABASE [{_nombreDB}] SET MULTI_USER;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void VerificarYGenerarBackupAutomatico()
        {
            if (!Directory.Exists(_rutaSeguridad))
            {
                Directory.CreateDirectory(_rutaSeguridad);
            }

            var directorio = new DirectoryInfo(_rutaSeguridad);
            var ultimoBackup = directorio.GetFiles("*.bak")
                                         .OrderByDescending(f => f.CreationTime)
                                         .FirstOrDefault();

            if (ultimoBackup == null || (DateTime.Now - ultimoBackup.CreationTime).TotalDays >= 7)
            {
                try
                {
                    GenerarBackup();
                }
                catch
                {

                }
            }
        }
    }
}