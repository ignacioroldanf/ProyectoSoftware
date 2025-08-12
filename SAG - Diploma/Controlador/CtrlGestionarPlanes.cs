using Microsoft.EntityFrameworkCore;
using Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class CtrlGestionarPlanes
    {
        private DiplomaContext _context;
        public CtrlGestionarPlanes(DiplomaContext context)
        {
            _context = context;
        }

        public List<Plane> Listar()
        {
            return _context.Planes.ToList();
        }

        public void AgregarPlan(Plane plan)
        {
            _context.Planes.Add(plan);
            _context.SaveChanges();
        }

        public void EliminarPlan(int id)
        {
            Plane planElegido = _context.Planes.Find(id);
            if (planElegido != null)
            {
                _context.Planes.Remove(planElegido);
                _context.SaveChanges();
            }
        }

        public void ModificarPrecio(Plane planModificado)
        {
            if (planModificado != null)
            {
                Plane planExistente = _context.Planes.FirstOrDefault(c => c.IdPlan == planModificado.IdPlan);
                if (planExistente != null)
                {
                    planExistente.PrecioMensual= planModificado.PrecioMensual;

                    _context.SaveChanges();
                }
            }
        }


    }
}
