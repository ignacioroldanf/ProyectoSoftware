using SAG___Diploma.Vista;
using SAG___Diploma.Vista.Theme;

namespace SAG___Diploma
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Inicializar tema global para que se aplique a todos los formularios
            FuturisticTheme.Initialize();
            Application.Run(new FormInicioSesion());
        }
    }
}