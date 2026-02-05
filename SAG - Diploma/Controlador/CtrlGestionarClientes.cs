using Azure.Core.Pipeline;
using Microsoft.EntityFrameworkCore;
using Modelo.Modelo;

namespace Controlador
{
    public class CtrlGestionarClientes
    {
        private DiplomaContext _context;

        public CtrlGestionarClientes(DiplomaContext context)
        {
            _context = context;
        }

        public List<Cliente> Listar()
        {
            return _context.Clientes
                .Include(c => c.IdPersonaNavigation)
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdEstadoSuscripcionNavigation)
                .ToList();
        }

        public void AgregarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void EliminarCliente(int id)
        {
            Cliente clienteElegido = _context.Clientes
                .Include(c => c.Suscripciones)
                .Include(c => c.Rutinas)
                     .ThenInclude(r => r.DiasRutinas)
                         .ThenInclude(d => d.EjerciciosAsignados)
                .Include(c => c.Reservas)
                .Include(c => c.Progresos)
                .FirstOrDefault(c => c.IdCliente == id);

            if (clienteElegido != null)
            {
                if (clienteElegido.Rutinas != null)
                {
                    _context.Rutinas.RemoveRange(clienteElegido.Rutinas);
                }

                if (clienteElegido.Suscripciones != null)
                    _context.Suscripciones.RemoveRange(clienteElegido.Suscripciones);

                if (clienteElegido.Reservas != null)
                    _context.Reservas.RemoveRange(clienteElegido.Reservas);

                if (clienteElegido.Progresos != null)
                    _context.Progresos.RemoveRange(clienteElegido.Progresos);

                _context.Clientes.Remove(clienteElegido);

                _context.SaveChanges();
            }
        }

        public void ModificarCliente(Cliente clienteModificado)
        {
            if (clienteModificado != null)
            {
                Cliente clienteExistente = _context.Clientes
                                                    .Include(c => c.IdPersonaNavigation)
                                                    .FirstOrDefault(c => c.IdCliente == clienteModificado.IdCliente);
                if (clienteExistente != null && clienteExistente.IdPersonaNavigation != null)
                {
                    clienteExistente.IdPersonaNavigation.Nombre = clienteModificado.IdPersonaNavigation.Nombre;
                    clienteExistente.IdPersonaNavigation.Apellido = clienteModificado.IdPersonaNavigation.Apellido;
                    clienteExistente.IdPersonaNavigation.Dni = clienteModificado.IdPersonaNavigation.Dni;
                    clienteExistente.IdPersonaNavigation.Email = clienteModificado.IdPersonaNavigation.Email;

                    _context.SaveChanges();
                }
            }
        }


        public Cliente BuscarPorID(int clienteID)
        {
            return _context.Clientes
                            .Include(c => c.IdPersonaNavigation)
                            .FirstOrDefault(c => c.IdCliente == clienteID);
        }

        public List<Cliente> FiltrarPorDNI(string dni)
        {
            return _context.Clientes
                .Include(c => c.IdPersonaNavigation)
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdEstadoSuscripcionNavigation)
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdPlanNavigation)
                .Where(c => c.IdPersonaNavigation.Dni.ToString() == dni) // Convertimos dni de la persona a string para comparar con dni
                .ToList();
        }

        public List<Cliente> FiltrarClientesPremiumPorDNI(int dni)
        {
            return _context.Clientes
                .Include(c => c.IdPersonaNavigation)
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdEstadoSuscripcionNavigation)
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdPlanNavigation)

                .Where(c =>
                    c.IdPersonaNavigation.Dni == dni
                    &&
                    c.Suscripciones.Any(s =>
                        s.IdEstadoSuscripcionNavigation.Descripcion == "Vigente" &&  
                        s.IdPlanNavigation.NombrePlan.Contains("Premium")
                    )
                )
                .ToList();
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
    }
}
