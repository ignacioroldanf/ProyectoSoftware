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

        // ESTADO DE CLIENTES 
        public List<Reportes.ReporteEstadoClientes> ObtenerEstadoClientes(DateTime fechaDesde, DateTime fechaHasta)
        {
            var hoy = DateOnly.FromDateTime(DateTime.Now);
            var desde = DateOnly.FromDateTime(fechaDesde);
            var hasta = DateOnly.FromDateTime(fechaHasta);

            var clientes = _context.Clientes
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdEstadoSuscripcionNavigation)
                .AsNoTracking()
                .Where(c => c.FechaAlta >= desde && c.FechaAlta <= hasta)
                .ToList();

            Dictionary<string, int> contadores = new Dictionary<string, int>();

            foreach (var cliente in clientes)
            {
                string estadoFinalDelCliente = "Sin Historial";

                bool tieneVigente = cliente.Suscripciones.Any(s =>
                    s.IdEstadoSuscripcionNavigation != null &&
                    s.IdEstadoSuscripcionNavigation.Descripcion == "Vigente" &&
                    s.Fin >= hoy);

                if (tieneVigente)
                {
                    estadoFinalDelCliente = "Vigente";
                }
                else
                {
                    var ultimaSuscripcion = cliente.Suscripciones
                        .OrderByDescending(s => s.Inicio)
                        .FirstOrDefault();

                    if (ultimaSuscripcion != null && ultimaSuscripcion.IdEstadoSuscripcionNavigation != null)
                    {
                        estadoFinalDelCliente = ultimaSuscripcion.IdEstadoSuscripcionNavigation.Descripcion;
                    }
                }

                if (contadores.ContainsKey(estadoFinalDelCliente))
                    contadores[estadoFinalDelCliente]++;
                else
                    contadores.Add(estadoFinalDelCliente, 1);
            }

            int totalClientes = clientes.Count;
            var listaResultado = new List<Reportes.ReporteEstadoClientes>();

            foreach (var kvp in contadores)
            {
                double porcentaje = totalClientes > 0 ? (double)kvp.Value / totalClientes * 100 : 0;

                listaResultado.Add(new Reportes.ReporteEstadoClientes
                {
                    Estado = kvp.Key,
                    CantidadClientes = kvp.Value,
                    Porcentaje = $"{porcentaje:0.00}%"
                });
            }

            return listaResultado;
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
    }
}