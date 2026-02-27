using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controlador
{
    public class CtrlGestionarReportes
    {
        private DiplomaContext _context;

        public CtrlGestionarReportes()
        {
            _context = new DiplomaContext();
        }

        // INGRESOS POR PLAN 
        public List<Reportes.ReporteIngresos> ObtenerIngresosPorPlan(DateTime fechaDesde, DateTime fechaHasta)
        {
            var hoy = DateOnly.FromDateTime(DateTime.Now);
            var desde = DateOnly.FromDateTime(fechaDesde);
            var hasta = DateOnly.FromDateTime(fechaHasta);
            
            var resultado = _context.Suscripciones
                .Include(s => s.IdPlanNavigation)
                .Include(s => s.IdEstadoSuscripcionNavigation)
                .Where(s => s.IdEstadoSuscripcionNavigation.Descripcion == "Vigente" 
                        && s.Inicio >= desde
                        && s.Inicio <= hasta)
                .GroupBy(s => s.IdPlanNavigation.NombrePlan)
                .Select(g => new Reportes.ReporteIngresos
                {
                    NombrePlan = g.Key,
                    CantidadSocios = g.Count(),
                    TotalIngresos = (decimal)g.Sum(s => s.IdPlanNavigation.PrecioMensual),
                    Categoria = g.Key.Contains("Premium") || g.Key.Contains("Gold") ? "Premium" : "Básico"
                })
                .ToList();

            return resultado;
        }

        
        // EJERCICIOS MAS POPULARES 

        public List<Reportes.ReporteEjerciciosPopulares> ObtenerEjerciciosMasPopulares(DateTime fechaDesde, DateTime fechaHasta)
        {
            var desde = DateOnly.FromDateTime(fechaDesde);
            var hasta = DateOnly.FromDateTime(fechaHasta);

            var ranking = _context.Progresos
                .Include(p => p.IdEjercicioAsignadoNavigation)
                    .ThenInclude(ea => ea.IdEjercicioNavigation) 
                .Where(p =>
                    p.Fecha >= desde &&
                    p.Fecha <= hasta &&
                    p.IdEjercicioAsignadoNavigation != null &&
                    p.IdEjercicioAsignadoNavigation.IdEjercicioNavigation != null)
                .GroupBy(p => p.IdEjercicioAsignadoNavigation.IdEjercicioNavigation.NombreEjercicio)
                .Select(grupo => new Reportes.ReporteEjerciciosPopulares
                {
                    NombreEjercicio = grupo.Key,
                    CantidadUsos = grupo.Count() 
                })
                .OrderByDescending(dto => dto.CantidadUsos)
                .Take(10)
                .ToList();

            return ranking;
        }

        // TOP INASISTENCIAS (POR PORCENTAJE)
        public List<Reportes.ReporteInasistencias> ObtenerTopInasistencias(DateTime fechaDesde, DateTime fechaHasta)
        {
            var desde = DateOnly.FromDateTime(fechaDesde);
            var hasta = DateOnly.FromDateTime(fechaHasta);

            var reservas = _context.Reservas
                .Include(r => r.IdClienteNavigation)
                    .ThenInclude(c => c.IdPersonaNavigation)
                .AsNoTracking()
                .Where(r => r.ReservaIndividual != null &&
                            r.ReservaIndividual.FechaReserva >= desde &&
                            r.ReservaIndividual.FechaReserva <= hasta)
                .ToList();

            var ranking = reservas
                .GroupBy(r => r.IdCliente)
                .Select(grupo => new
                {
                    ClienteObj = grupo.First().IdClienteNavigation,
                    TotalReservas = grupo.Count(),
                    Faltas = grupo.Count(r => r.IdEstadoReserva == 5)
                })
                .Where(x => x.Faltas > 0)
                .Select(x => new Reportes.ReporteInasistencias
                {
                    Cliente = x.ClienteObj.IdPersonaNavigation.Nombre + " " + x.ClienteObj.IdPersonaNavigation.Apellido,
                    TotalReservas = x.TotalReservas,
                    Faltas = x.Faltas,
                    PorcentajeFaltas = x.TotalReservas > 0 ? Math.Round(((double)x.Faltas / x.TotalReservas) * 100, 2) : 0
                })
                .OrderByDescending(x => x.PorcentajeFaltas)
                .Take(10)
                .ToList();

            return ranking;
        }
    }
}