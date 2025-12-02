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
    public class CtrlGestionarRutinasyProgresos
    {
        private DiplomaContext _context;

        public CtrlGestionarRutinasyProgresos(DiplomaContext context)
        {
            _context = context;
        }


        public Rutina CrearRutina(int idCliente, int cantDias)
        {
            Cliente cliente = _context.Clientes
                .FirstOrDefault(c => c.IdCliente == idCliente);

            if (cliente == null) { 
                return null;
            }


            Rutina rutina = RutinaFactory.CrearRutina(cantDias);
            rutina.IdCliente = cliente.IdCliente;
            rutina.FechaAsignacion = DateOnly.FromDateTime(DateTime.Now);

            _context.Rutinas.Add(rutina);
            _context.SaveChanges();
        
            return rutina;
        }

        public Rutina? ConsultarRutinaActual(int idCliente)
        {
            return _context.Rutinas
                .Include(r => r.DiasRutinas)
                    .ThenInclude(d => d.EjerciciosAsignados)
                        .ThenInclude(ea => ea.IdEjercicioNavigation)
                .Where(r => r.IdCliente == idCliente)
                .OrderByDescending(r => r.FechaAsignacion)
                .FirstOrDefault();
        }

        public void AgregarEjADia(int idDiaRutina, int idEjercicio, int series, int repes, float peso, int orden)
        {
            DiasRutina dia = _context.DiasRutinas.Find(idDiaRutina);
            Ejercicio ejercicio = _context.Ejercicios.Find(idEjercicio);

            if(dia == null || ejercicio == null) return;

            bool ordenDuplicado = dia.EjerciciosAsignados.Any(ea => ea.Orden == orden);
            if (ordenDuplicado)
                throw new InvalidOperationException("Ya existe un ejercicio en este día con el mismo orden.");

            EjerciciosAsignado nuevoEjAsignado = new EjerciciosAsignado
            {
                IdDiaRutina = idDiaRutina,
                IdEjercicio = idEjercicio,
                Series = series,
                Repeticiones = repes,
                Peso = peso,
                Orden = orden
            };

            _context.EjerciciosAsignados.Add(nuevoEjAsignado);
            _context.SaveChanges();
        }

        public void ModificarEjAsignado(int idEjAsignado, int series, int repes, float peso, int orden)
        {
            EjerciciosAsignado ej = _context.EjerciciosAsignados.Find(idEjAsignado);
            if (ej == null) return;

            bool ordenDuplicado = ej.IdDiaRutinaNavigation.EjerciciosAsignados
                .Any(ea => ea.Orden == orden && ea.IdEjercicioAsignado != idEjAsignado);

            ej.Series = series;
            ej.Repeticiones = repes;
            ej.Peso = peso;
            ej.Orden = orden;

            _context.SaveChanges();
        }


        public List<Progreso> ConsultarProgresos(int idCliente)
        {
            return _context.Progresos
                .Include(p => p.IdEjercicioAsignadoNavigation)
                    .ThenInclude(ea => ea.IdEjercicioNavigation)
                .Where(p => p.IdCliente == idCliente)
                .OrderByDescending(p => p.Fecha)
                .ToList();
        }



        public void RegistrarProgreso(int idCliente, int idEjAsignado, int seriesHechas, int repesHechas, float pesoUsado, string observaciones)
        {
            bool clienteExiste = _context.Clientes.Any(c => c.IdCliente == idCliente);
            bool ejercicioExiste = _context.EjerciciosAsignados.Any(ea => ea.IdEjercicioAsignado == idEjAsignado);

            if (clienteExiste == false || ejercicioExiste == false) { return; }

            Progreso nuevoProgreso = new Progreso
            {
                IdCliente = idCliente,
                IdEjercicioAsignado = idEjAsignado,
                Fecha = DateOnly.FromDateTime(DateTime.Now),
                SeriesHechas = seriesHechas,
                RepesHechas = repesHechas,
                PesoUsado = (decimal)pesoUsado,
                Observaciones = observaciones
            };

            _context.Progresos.Add(nuevoProgreso);
            _context.SaveChanges();

        }
    }
}
