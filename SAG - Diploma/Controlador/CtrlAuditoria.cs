using Modelo.Modelo;
using System.Collections.Generic;
using System.Linq;

namespace Controlador
{
    public class CtrlAuditoria
    {
        public List<dynamic> ObtenerAuditoriaLogins()
        {
            using (var db = new DiplomaContext())
            {
                return db.AudLoginLogouts
                    .OrderByDescending(a => a.FyhMov)
                    .Select(a => new
                    {
                        Usuario = a.Usuario,
                        FechaYHora = a.FyhMov,
                        Movimiento = a.IdMov == 1 ? "Login" : "Logout"
                    })
                    .ToList<dynamic>();
            }
        }

        public List<dynamic> ObtenerAuditoriaClases()
        {
            using (var db = new DiplomaContext())
            {
                return db.AudClases
                    .OrderByDescending(c => c.FyhMov)
                    .Select(c => new
                    {
                        ID_Clase = c.IdClase,
                        Clase = c.NombreClase,
                        Cupo = c.CupoMaximo,
                        Accion = c.Movimiento,
                        UsuarioBD = c.UsuarioAuditoria,
                        FechaYHora = c.FyhMov
                    })
                    .ToList<dynamic>();
            }
        }
    }
}