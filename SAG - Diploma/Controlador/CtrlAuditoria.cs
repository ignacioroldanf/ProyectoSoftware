using Modelo.Modelo;
using System;
using System.Data; // ¡Agregá este using para usar DataTable!
using System.Linq;

namespace Controlador
{
    public class CtrlAuditoria
    {
        public DataTable ObtenerAuditoriaLogins(string filtroMovimiento = "TODOS")
        {
            using (var db = new DiplomaContext())
            {
                var consulta = db.AudLoginLogouts.AsQueryable();

                if (filtroMovimiento != "TODOS")
                {
                    int idMov = filtroMovimiento == "LOGIN" ? 1 : 2;
                    consulta = consulta.Where(a => a.IdMov == idMov);
                }

                var listaBd = consulta.OrderByDescending(a => a.FyhMov).ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("Usuario", typeof(string));
                dt.Columns.Add("Fecha y Hora", typeof(DateTime));
                dt.Columns.Add("Movimiento", typeof(string));

                foreach (var item in listaBd)
                {
                    string nombreMovimiento = item.IdMov == 1 ? "LOGIN" : "LOGOUT";
                    dt.Rows.Add(item.Usuario, item.FyhMov, nombreMovimiento);
                }

                return dt;
            }
        }

        public DataTable ObtenerAuditoriaClases(string filtroAccion = "TODOS")
        {
            using (var db = new DiplomaContext())
            {
                var consulta = db.AudClases.AsQueryable();

                if (filtroAccion != "TODOS")
                {
                    consulta = consulta.Where(c => c.Movimiento == filtroAccion);
                }

                var listaBd = consulta.OrderByDescending(c => c.FyhMov).ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Clase", typeof(string));
                dt.Columns.Add("Cupo", typeof(int));
                dt.Columns.Add("Acción", typeof(string));
                dt.Columns.Add("Usuario BD", typeof(string));
                dt.Columns.Add("Fecha y Hora", typeof(DateTime));

                foreach (var item in listaBd)
                {
                    dt.Rows.Add(
                        item.IdClase,
                        item.NombreClase,
                        item.CupoMaximo,
                        item.Movimiento,
                        item.UsuarioAuditoria,
                        item.FyhMov
                    );
                }

                return dt;
            }
        }
    }
}