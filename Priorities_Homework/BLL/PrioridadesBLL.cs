using Microsoft.EntityFrameworkCore;
using Priorities_Homework.DAL;
using Priorities_Homework.Models;
using System.Linq.Expressions;

namespace Priorities_Homework.BLL
{
    public class PrioridadesBLL
    {
        private Contexto _contexto;

        public PrioridadesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int prioridadId) {
            return _contexto.Prioridades.Any(o => o.PrioridadId == prioridadId);

        }

        private bool Insertar(Prioridades prioridad) {
            _contexto.Prioridades.Add(prioridad);
            return _contexto.SaveChanges() > 0;
        }

        private bool Modificar(Prioridades prioridad) {
            _contexto.Entry(prioridad).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public bool Guardar(Prioridades prioridades) {
			if(!Existe(prioridades.PrioridadId))

	            return this.Insertar(prioridades);
            else
				return this.Modificar(prioridades);
		}
        public Prioridades? Buscar(int prioridadId) {
            return _contexto.Prioridades.Where(o => o.PrioridadId == prioridadId).
                AsNoTracking().SingleOrDefault();
        }

        public bool Eliminar(int id) {
            var prioridad = _contexto.Prioridades.Find(id);
            _contexto.Prioridades.Remove(prioridad);
            return _contexto.SaveChanges() > 0;

        }

        public List<Prioridades> ObtenerLista(Expression<Func<Prioridades, bool>> criterio) {
            return _contexto.Prioridades
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}
