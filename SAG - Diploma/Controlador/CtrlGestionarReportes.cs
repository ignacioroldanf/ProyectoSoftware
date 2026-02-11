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

        // --- REPORTE 1: INGRESOS POR PLAN ---
        public List<Reportes.ReporteIngresos> ObtenerIngresosPorPlan()
        {
            var hoy = DateOnly.FromDateTime(DateTime.Now);

            var resultado = _context.Suscripciones
                .Include(s => s.IdPlanNavigation)
                .Include(s => s.IdEstadoSuscripcionNavigation)
                .Where(s => s.IdEstadoSuscripcionNavigation.Descripcion == "Vigente" && s.Fin >= hoy)
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

        // --- REPORTE 2: ESTADO REAL DE CLIENTES ---
        // (Este método ya estaba bien en tu código, lo copio igual para que tengas el archivo completo)
        public List<Reportes.ReporteEstadoUsuarios> ObtenerEstadoUsuarios()
        {
            var hoy = DateOnly.FromDateTime(DateTime.Now);

            var clientes = _context.Clientes
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdEstadoSuscripcionNavigation)
                .AsNoTracking()
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
            var listaResultado = new List<Reportes.ReporteEstadoUsuarios>();

            foreach (var kvp in contadores)
            {
                double porcentaje = totalClientes > 0 ? (double)kvp.Value / totalClientes * 100 : 0;

                listaResultado.Add(new Reportes.ReporteEstadoUsuarios
                {
                    Estado = kvp.Key,
                    CantidadUsuarios = kvp.Value,
                    Porcentaje = $"{porcentaje:0.00}%"
                });
            }

            return listaResultado;
        }
    }
}