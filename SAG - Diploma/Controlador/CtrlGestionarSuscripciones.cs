﻿using Microsoft.EntityFrameworkCore;
using Modelo.Modelo;

namespace Controlador
{
    public class CtrlGestionarSuscripciones
    {
        private DiplomaContext _context;

        public CtrlGestionarSuscripciones(DiplomaContext context)
        {
            _context = context;
        }
        public List<Suscripcione> Listar()
        {
            return _context.Suscripciones
                .Include(s => s.IdClienteNavigation)
                .Include(s => s.IdPlanNavigation)
                .Include(s => s.IdEstadoSuscripcionNavigation)
                .ToList();
        }
        public List<Suscripcione> ListarPorCliente(int idCliente)
        {
            ActualizarEstados(idCliente);

            return _context.Suscripciones
                .Include(s => s.IdPlanNavigation)
                .Include(s => s.IdEstadoSuscripcionNavigation)
                .Where(s => s.IdCliente == idCliente)
                .OrderByDescending(s => s.Inicio)
                .ToList();
        }
        private void ActualizarEstados(int idCliente)
        {
            var hoy = DateOnly.FromDateTime(DateTime.Now);

            var suscripciones = _context.Suscripciones
                .Where(s => s.IdCliente == idCliente)
                .ToList();

            // buscar el estado "Vencida"
            var estadoVencida = _context.EstadoSuscripcions
                .FirstOrDefault(e => e.Descripcion == "Vencida");

            if (estadoVencida == null) return; // seguridad

            foreach (var s in suscripciones)
            {
                if (s.Fin.HasValue && s.Fin.Value < hoy)
                {
                    if (s.IdEstadoSuscripcion != estadoVencida.IdEstadoSuscripcion)
                    {
                        s.IdEstadoSuscripcion = estadoVencida.IdEstadoSuscripcion;
                    }
                }
            }

            _context.SaveChanges();
        }


        public Suscripcione? BuscarPorID(int idSuscripcion)
        {
            return _context.Suscripciones
                .Include(s => s.IdPlanNavigation)
                .Include(s => s.IdEstadoSuscripcionNavigation)
                .FirstOrDefault(s => s.IdSuscripcion == idSuscripcion);
        }

        public void AsignarSuscripcion(int idCliente, int idPlan, DateOnly inicio, DateOnly fin, int idEstado = 1)
        {
            var nuevaSuscripcion = new Suscripcione
            {
                IdCliente = idCliente,
                IdPlan = idPlan,
                Inicio = inicio,
                Fin = fin,
                IdEstadoSuscripcion = idEstado
            };

            _context.Suscripciones.Add(nuevaSuscripcion);
            _context.SaveChanges();
        }
        public void EliminarSuscripcion(int idSuscripcion)
        {
            var suscripcion = _context.Suscripciones.Find(idSuscripcion);
            if (suscripcion != null)
            {
                _context.Suscripciones.Remove(suscripcion);
                _context.SaveChanges();
            }
        }
        public Suscripcione? ObtenerSuscripcionActiva(int idCliente)
        {
            return _context.Suscripciones
                .Include(s => s.IdPlanNavigation)
                .Include(s => s.IdEstadoSuscripcionNavigation)
                .FirstOrDefault(s => s.IdCliente == idCliente && s.IdEstadoSuscripcionNavigation.Descripcion == "Vigente");
        }
        public DateOnly CalcularFechaFin(int idPlan, DateOnly inicio)
        {
            var plan = _context.Planes.Find(idPlan);
            if (plan == null) throw new Exception("Plan no encontrado");

            return inicio.AddMonths(plan.DuracionMeses);
        }

        public Cliente? ObtenerCliente(int idCliente)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == idCliente);
        }
        public List<Plane> ObtenerPlanes()
        {
            return _context.Planes.ToList();
        }
    }
}

