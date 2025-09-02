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
            return _context.Clientes.ToList();
        }

        public void AgregarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void EliminarCliente(int id)
        {
            Cliente clienteElegido = _context.Clientes.Find(id);

            if (clienteElegido != null)
            {
                _context.Clientes.Remove(clienteElegido);
                _context.SaveChanges();
            }
        }

        public void ModificarCliente(Cliente clienteModificado)
        {
            if (clienteModificado != null)
            {
                Cliente clienteExistente = _context.Clientes.FirstOrDefault(c => c.IdCliente == clienteModificado.IdCliente);
                if (clienteExistente != null)
                {
                    clienteExistente.NombreCliente = clienteModificado.NombreCliente;
                    clienteExistente.ApellidoCliente = clienteModificado.ApellidoCliente;
                    clienteExistente.DniCliente = clienteModificado.DniCliente;
                    clienteExistente.MailCliente = clienteModificado.MailCliente;

                    _context.SaveChanges();
                }
            }
        }


        public Cliente BuscarPorID(int clienteID)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == clienteID);
        }
        public List<Cliente> FiltrarPorDNI(string dni)
        {
            return _context.Clientes
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdEstadoSuscripcionNavigation)
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdPlanNavigation)
                .Where(c => c.DniCliente.ToString() == dni) // Convertimos DniCliente a string para comparar con dni
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
