using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class CtrlGestionarReservas
    {
        private readonly DiplomaContext _context;

        public CtrlGestionarReservas (DiplomaContext context)
        {
            _context = context;
        }

        public List<TipoRecurrencium> ListarTipoRecurrencia()
        {
            return _context.TipoRecurrencia.ToList();
        }

        public List<EstadoReserva> ListarEstadosReserva()
        {
            return _context.EstadoReservas.ToList();
        }


        public List<AgendaClase> ObtenerAgendaDelDia(DateTime fecha)
        {
            int diaSemanaInt = (int)fecha.DayOfWeek;
            DateOnly fechaSolo = DateOnly.FromDateTime(fecha);

            var horarios = _context.HorarioClases
                .Include(h => h.IdClaseNavigation)
                    .ThenInclude(c => c.IdProfesorNavigation)
                        .ThenInclude(p => p.IdPersonaNavigation)
                .Where(h => h.IdDiaSemana == diaSemanaInt)
                .ToList();

            var listaAgenda = new List<AgendaClase>();

            foreach (var h in horarios) 
            {
                int ocupados = _context.ReservaIndividuals
                    .Include(ri => ri.IdReservaNavigation)
                    .Count(ri => ri.IdHorarioClase == h.IdHorarioClase
                            && ri.FechaReserva == fechaSolo
                            && ri.IdReservaNavigation.IdEstadoReserva == 2);

                string nombreProfe = "Sin Asignar";
                if (h.IdClaseNavigation.IdProfesorNavigation?.IdPersonaNavigation != null)
                {
                    nombreProfe = h.IdClaseNavigation.IdProfesorNavigation.IdPersonaNavigation.Nombre + " " +
                                  h.IdClaseNavigation.IdProfesorNavigation.IdPersonaNavigation.Apellido;
                }

                listaAgenda.Add(new AgendaClase
                {
                    IdHorarioClase = h.IdHorarioClase,
                    NombreClase = h.IdClaseNavigation.NombreClase,
                    NombreProfesor = nombreProfe,
                    HorarioClase = $"{h.HoraInicio} - {h.HoraFin}",
                    CupoTotal = h.IdClaseNavigation.CupoMaximo,
                    Inscritos = ocupados
                });
            }
            return listaAgenda.OrderBy(x => x.HorarioClase).ToList();
        }

        public List<dynamic> ObtenerInscriptos(int idHorario, DateTime fecha)
        {
            DateOnly fechaSolo = DateOnly.FromDateTime(fecha);

            return _context.ReservaIndividuals
                .Include(ri => ri.IdReservaNavigation)
                    .ThenInclude(r => r.IdClienteNavigation)
                        .ThenInclude(c => c.IdPersonaNavigation)
                .Where(ri => ri.IdHorarioClase == idHorario
                            && ri.FechaReserva == fechaSolo
                            && ri.IdReservaNavigation.IdEstadoReserva == 2)
                .Select(ri => new
                {
                    IdReserva = ri.IdReserva,
                    NombreCompleto = ri.IdReservaNavigation.IdClienteNavigation.IdPersonaNavigation.Nombre + " " +
                                     ri.IdReservaNavigation.IdClienteNavigation.IdPersonaNavigation.Apellido,
                    DNI = ri.IdReservaNavigation.IdClienteNavigation.IdPersonaNavigation.Dni
                })
                .ToList<dynamic>();
        }

        public List<dynamic> ObtenerReservasPorCliente(int idCliente)
        {
            return _context.ReservaIndividuals
                    .Include(ri => ri.IdReservaNavigation)
                        .ThenInclude(r => r.IdEstadoReservaNavigation)
                    .Include(ri => ri.IdHorarioClaseNavigation)
                        .ThenInclude(h => h.IdClaseNavigation)
                    .Where(ri => ri.IdReservaNavigation.IdCliente == idCliente)
                    .Select(ri => new
                    {
                        IdReserva = ri.IdReserva,
                        IdReservaPadre = ri.IdReservaNavigation.IdReservaPadre,
                        Fecha = ri.FechaReserva,
                        Hora = ri.IdHorarioClaseNavigation.HoraInicio,
                        Clase = ri.IdHorarioClaseNavigation.IdClaseNavigation.NombreClase,
                        Estado = ri.IdReservaNavigation.IdEstadoReservaNavigation.Descripcion,

                        Tipo = ri.IdReservaNavigation.IdReservaPadre != null ? "Recurrente" : "Individual"
                    })
                    .OrderByDescending(x => x.Fecha)
                    .ToList<dynamic>();
        }
        public void CrearReserva(int idCliente, int idHorario, DateTime fechaInicio, DateTime? fechaFin, bool esRecurrente)
        {
            var horario = _context.HorarioClases
                                .Include(h=> h.IdClaseNavigation)
                                .FirstOrDefault(h=> h.IdHorarioClase == idHorario);

            if (horario == null) throw new Exception("El horario seleccionado no existe.");

            int cupoMax = horario.IdClaseNavigation.CupoMaximo;
            int diaSemanaClase = horario.IdDiaSemana;

            if (!esRecurrente || fechaFin == null)
            {
                DateOnly fechaOnly = DateOnly.FromDateTime(fechaInicio);

                // Verificar que el cliente no tenga ya una reserva activa en esa clase/fecha
                if (TieneReservaActiva(idCliente, idHorario, fechaOnly))
                    throw new Exception($"El cliente ya tiene una reserva activa para la fecha {fechaOnly} en esta clase.");

                ValidarDiaSemana(fechaInicio, diaSemanaClase);
                ValidarCupo(idHorario, fechaOnly, cupoMax);

                var reservaBase = new Reserva
                {
                    IdCliente = idCliente,
                    FechaAlta = DateTime.Now,
                    IdEstadoReserva = 2,
                    IdReservaPadre = null
                };

                var detalleIndiv = new ReservaIndividual
                {
                    IdHorarioClase = idHorario,
                    FechaReserva = fechaOnly,
                    IdReservaNavigation = reservaBase
                };

                _context.ReservaIndividuals.Add(detalleIndiv);
            }
            else
            {
                var padreBase = new Reserva
                {
                    IdCliente = idCliente,
                    FechaAlta = DateTime.Now,
                    IdEstadoReserva = 2,
                    IdReservaPadre = null
                };

                var detalleRecurrente = new ReservaRecurrente
                {
                    IdHorarioClase = idHorario,
                    IdTipoRecurrencia = 1,
                    IdReservaNavigation = padreBase
                };

                DateTime fechaIterador = fechaInicio;
                bool seCreoAlguna = false;

                while (fechaIterador <= fechaFin.Value)
                {
                    if (EsMismoDia(fechaIterador, diaSemanaClase))
                    {
                        DateOnly fechaHija = DateOnly.FromDateTime(fechaIterador);

                        // Verificar conflicto de reserva antes de crear cada hija
                        if (TieneReservaActiva(idCliente, idHorario, fechaHija))
                            throw new Exception($"El cliente ya tiene una reserva activa para la fecha {fechaHija} en esta clase. No se creó la recurrencia.");

                        ValidarCupo(idHorario, fechaHija, cupoMax);

                        var hijoBase = new Reserva
                        {
                            IdCliente = idCliente,
                            FechaAlta = DateTime.Now,
                            IdEstadoReserva = 2
                        };

                        var detalleHijo = new ReservaIndividual
                        {
                            IdHorarioClase = idHorario,
                            FechaReserva = fechaHija,
                            IdReservaNavigation = hijoBase
                        };

                        padreBase.InverseIdReservaPadreNavigation.Add(hijoBase);

                        _context.ReservaIndividuals.Add(detalleHijo);

                        seCreoAlguna = true;
                    }

                    fechaIterador = fechaIterador.AddDays(1);
                }

                if (!seCreoAlguna)
                    throw new Exception("El rango de fechas no contiene días válidos para esta clase.");
                
                _context.ReservaRecurrentes.Add(detalleRecurrente);
            
            }

            _context.SaveChanges();
        }
        
        public bool TieneReservaActiva(int idCliente, int idHorario, DateOnly fecha)
        {
            try
            {
                return _context.ReservaIndividuals
                    .Include(ri => ri.IdReservaNavigation)
                    .Any(ri => ri.IdHorarioClase == idHorario
                            && ri.FechaReserva == fecha
                            && ri.IdReservaNavigation.IdCliente == idCliente
                            && ri.IdReservaNavigation.IdEstadoReserva == 2);
            }
            catch
            {
                // Si hay un problema con la consulta, asumimos que no hay reserva para no bloquear por error de consulta
                return false;
            }
        }
        
        public void DarBajaReservaIndividual (int idReserva)
        {
            var reserva = _context.Reservas.FirstOrDefault(r => r.IdReserva == idReserva);

            if (reserva == null)
                throw new Exception("La reserva no existe.");

            if (reserva.IdEstadoReserva == 1) throw new Exception("La reserva ya se encuentra cancelada.");

            reserva.IdEstadoReserva = 1;

            _context.SaveChanges ();
        }

        public void DarBajaReservaRecurrente (int idReservaPadre)
        {
            var reservaPadre = _context.Reservas
                .Include(r => r.InverseIdReservaPadreNavigation)
                .FirstOrDefault(r=> r.IdReserva == idReservaPadre);

            if (reservaPadre == null) throw new Exception("La reserva recurrente no existe.");

            reservaPadre.IdEstadoReserva = 1;

            foreach(var hija in reservaPadre.InverseIdReservaPadreNavigation)
            {
                if (hija.IdEstadoReserva == 2)
                {
                    hija.IdEstadoReserva = 1;
                }
            }

            _context.SaveChanges ();
        }

        #region Validaciones
        private void ValidarCupo(int idHorario, DateOnly fecha, int cupoMax) 
        {
            int ocupados = _context.ReservaIndividuals
                .Include(ri => ri.IdReservaNavigation)
                .Count(ri => ri.IdHorarioClase == idHorario
                        && ri.FechaReserva == fecha
                        && ri.IdReservaNavigation.IdEstadoReserva == 2);

            if (ocupados >= cupoMax)
            {
                throw new Exception($"No hay cupo disponible para la fecha {fecha}.");
            }
        }

        private void ValidarDiaSemana(DateTime fecha, int diaSemanaDB)
        {
            if(!EsMismoDia(fecha, diaSemanaDB))
            {
                throw new Exception($"La fecha seleccionada no corresponde al día de dictado de la clase");
            }
        }

        private bool EsMismoDia(DateTime fecha, int diaSemanaDB) 
        {
            // Normalize DB day id to DayOfWeek 0..6.
            // Some DBs use 1=Monday..7=Sunday, others 0=Sunday..6=Saturday. Map both to 0..6.
            int dayOfWeek = (int)fecha.DayOfWeek; // 0 = Sunday .. 6 = Saturday
            int dbNormalized = diaSemanaDB % 7; // maps 7->0 (Sunday), 1->1 (Monday), etc.
            return dayOfWeek == dbNormalized;
        }
        #endregion
    }
}
