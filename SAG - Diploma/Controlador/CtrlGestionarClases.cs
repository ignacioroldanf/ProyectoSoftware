using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class CtrlGestionarClases
    {
        private readonly DiplomaContext _context;

        public CtrlGestionarClases (DiplomaContext context)
        {
            _context = context;
        }

        public List<dynamic> ListarClases()
        {
            return _context.Clases
                .Include(c => c.IdProfesorNavigation)
                    .ThenInclude(p => p.IdPersonaNavigation)
                .Select(c => new
                {
                    IdClase = c.IdClase,
                    Nombre = c.NombreClase,
                    Descripcion = c.DescripcionClase,
                    Cupo = c.CupoMaximo,
                    Profesor = c.IdProfesorNavigation != null
                        ? c.IdProfesorNavigation.IdPersonaNavigation.Nombre + " " + c.IdProfesorNavigation.IdPersonaNavigation.Apellido
                        : "Sin Asignar"
                })
                .ToList<dynamic>();

        }

        public Clase ObtenerClasePorID(int idClase)
        {
            return _context.Clases
                .Include(c => c.HorarioClases)
                .FirstOrDefault(c => c.IdClase == idClase);
        }

        public List<Profesore> ListarProfesores()
        {
            return _context.Profesores
                .Include(p => p.IdPersonaNavigation)
                .ToList();
        }

        public List<DiasSemana> ListarDiasSemana()
        {
            return _context.DiasSemanas.ToList();
        }

        //abm

        public void AgregarClase(Clase nuevaClase)
        {
            if (string.IsNullOrWhiteSpace(nuevaClase.NombreClase))
                throw new Exception("El nombre de la clase es obligatorio.");

            if (nuevaClase.CupoMaximo <= 0)
                throw new Exception("El cupo máximo debe ser mayor a 0.");

            _context.Clases.Add(nuevaClase);

            using (var transaction = _context.Database.BeginTransaction())
            {
                string usuarioApp = Sesion.Instancia.UsuarioActual?.NombreUsuario ?? "Desconocido";
                _context.Database.ExecuteSqlRaw("EXEC sp_set_session_context @key=N'UsuarioApp', @value={0}", usuarioApp);

                _context.SaveChanges();

                transaction.Commit();
            }
        }

        public void ModificarClase(Clase claseModificada)
        {
            var claseExistente = _context.Clases.Find(claseModificada.IdClase);

            if (claseExistente == null) throw new Exception("La clase no existe.");

            claseExistente.NombreClase = claseModificada.NombreClase;
            claseExistente.DescripcionClase = claseModificada.DescripcionClase;
            claseExistente.CupoMaximo = claseModificada.CupoMaximo;
            claseExistente.IdProfesor = claseModificada.IdProfesor;

            using (var transaction = _context.Database.BeginTransaction())
            {
                string usuarioApp = Sesion.Instancia.UsuarioActual?.NombreUsuario ?? "Desconocido";
                _context.Database.ExecuteSqlRaw("EXEC sp_set_session_context @key=N'UsuarioApp', @value={0}", usuarioApp);

                _context.SaveChanges();

                transaction.Commit();
            }
        }

        public void EliminarClase(int idClase)
        {
            var clase = _context.Clases
                .Include(c => c.HorarioClases)
                .FirstOrDefault(c => c.IdClase == idClase);

            if (clase == null) throw new Exception("La clase no existe.");

            bool tieneReservas = _context.ReservaIndividuals
                .Any(ri => ri.IdHorarioClaseNavigation.IdClase == idClase
                        && ri.IdReservaNavigation.IdEstadoReserva == 2); // 2 = Activa

            if (tieneReservas)
            {
                throw new Exception("No se puede eliminar la clase porque tiene reservas/alumnos activos. Primero debe cancelar las reservas.");
            }

            _context.HorarioClases.RemoveRange(clase.HorarioClases);
            _context.Clases.Remove(clase);

            using (var transaction = _context.Database.BeginTransaction())
            {
                string usuarioApp = Sesion.Instancia.UsuarioActual?.NombreUsuario ?? "Desconocido";
                _context.Database.ExecuteSqlRaw("EXEC sp_set_session_context @key=N'UsuarioApp', @value={0}", usuarioApp);

                _context.SaveChanges();

                transaction.Commit();
            }
        }

        public void AgregarHorario(int idClase, int idDia, TimeOnly inicio, TimeOnly fin)
        {
            var nuevoHorario = new HorarioClase
            {
                IdClase = idClase,
                IdDiaSemana = idDia,
                HoraInicio = inicio,
                HoraFin = fin
            };
            _context.HorarioClases.Add(nuevoHorario);
            _context.SaveChanges();
        }

        public void EliminarHorario(int idHorario)
        {
            bool tieneReservas = _context.ReservaIndividuals
               .Any(ri => ri.IdHorarioClase == idHorario && ri.IdReservaNavigation.IdEstadoReserva == 2);

            if (tieneReservas) throw new Exception("El horario tiene reservas activas.");

            var horario = _context.HorarioClases.Find(idHorario);
            if (horario != null)
            {
                _context.HorarioClases.Remove(horario);
                _context.SaveChanges();
            }
        }
    }
}
