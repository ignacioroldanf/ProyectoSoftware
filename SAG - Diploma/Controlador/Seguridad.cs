using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Controlador
{
    public static class Seguridad
    {
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            StringBuilder sb = new StringBuilder();

            byte[] stream = sha256.ComputeHash(encoding.GetBytes(str));

            for (int i = 0; i < stream.Length; i++)
                sb.AppendFormat("{0:x2}", stream[i]);

            return sb.ToString();
        }

        public static bool ValidarClave(string clave)
        {
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&#]).{8,}$");

            return regex.IsMatch(clave);
        }

        public static string GenerarClaveAleatoria()
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@$!%*?&";
            int longitud = 8; 
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();

            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }

            string claveGenerada = res.ToString();

            if (!ValidarClave(claveGenerada))
                return GenerarClaveAleatoria(); 

            return claveGenerada;
        }
    }
}
