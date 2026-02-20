using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class CtrlGestionarGrupos
    {
        private DiplomaContext _context;

        public CtrlGestionarGrupos(DiplomaContext context)
        {
            _context = context;
        }

        public void BuscarGrupo(int idGrupo)
        {
            var grupo = _context.Grupos.Find(idGrupo);
        }

        public List<Grupo> ListarGrupos()
        {
            return _context.Grupos
                .Include(g => g.IdEstadoGrupoNavigation)
                .Include(g => g.IdAccions)
                .ToList();
        }

        public List<EstadoGrupo> ListarEstados()
        {
            return _context.EstadoGrupos.ToList();
        }


        public void AgregarGrupo(Grupo nuevoGrupo)
        {
            if (_context.Grupos.Any(g => g.NombreGrupo == nuevoGrupo.NombreGrupo))
            {
                throw new Exception("El nombre del grupo ya existe.");
            }

            nuevoGrupo.IdEstadoGrupo = 1;
            
            _context.Grupos.Add(nuevoGrupo);
            _context.SaveChanges();
        }

        public void ModificarGrupo (Grupo grupoModificado)
        {
            var grupoExistente = _context.Grupos.Find(grupoModificado.IdGrupo);

            if (grupoExistente != null)
            {
                grupoExistente.NombreGrupo = grupoModificado.NombreGrupo;
                grupoExistente.Descripcion = grupoModificado.Descripcion;
                grupoExistente.IdEstadoGrupo = grupoModificado.IdEstadoGrupo;

                _context.SaveChanges();
            }
        }

        public void EliminarGrupo(int idGrupo)
        {
            var grupo = _context.Grupos.Find(idGrupo);

            if (grupo == null) throw new Exception("Grupo no encontrado.");

            grupo.IdEstadoGrupo = 0;

            _context.SaveChanges();
        }

        public void ActivarGrupo(int idGrupo)
        {
            var grupo = _context.Grupos.Find(idGrupo);
            if (grupo == null) throw new Exception("Grupo no encontrado.");
            grupo.IdEstadoGrupo = 1;
            _context.SaveChanges();
        }


        //acciones

        public List<Accione> ListarAcciones()
        {
            return _context.Acciones
                .Include(a=> a.IdFormularioNavigation)
                    .ThenInclude(f => f.IdModuloNavigation)
                .ToList();
        }

        public List<Accione> ListarAccionesPorGrupo(int idGrupo)
        {
            var grupo = _context.Grupos
                        .Include(g => g.IdAccions)
                        .FirstOrDefault(g => g.IdGrupo == idGrupo);
            if (grupo == null) throw new Exception("Grupo no encontrado.");
            return grupo.IdAccions.ToList();
        }

        public void GuardarPermisosGrupo(int idGrupo, List<int> idsAcciones)
        {
            var grupo = _context.Grupos
                        .Include(g => g.IdAccions)
                        .FirstOrDefault(g => g.IdGrupo == idGrupo);

            if (grupo == null) throw new Exception("Grupo no encontrado.");

            grupo.IdAccions.Clear();

            var accionesNuevas = _context.Acciones
                            .Where(a => idsAcciones.Contains(a.IdAccion))
                            .ToList();
            foreach(var accion in accionesNuevas)
            {
                grupo.IdAccions.Add(accion);
            }

            _context.SaveChanges();
        }



    }
}
