using Microsoft.EntityFrameworkCore;
using Priorities_Homework.DAL;
using Priorities_Homework.Models;
using System.Linq.Expressions;

namespace Priorities_Homework.BLL
{
    public class PrioridadesBLL
    {
        private readonly Contexto _contexto;

        public PrioridadesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task <bool> Existe(int prioridadId) {
            return await _contexto.Prioridades.AnyAsync(o => o.PrioridadId == prioridadId);
        }

        private async Task<bool> Insertar(Prioridad prioridad) {
            _contexto.Prioridades.Add(prioridad);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Prioridad prioridad) {
            _contexto.Entry(prioridad).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Prioridad prioridad) {
			if(! await Existe(prioridad.PrioridadId))

	            return await Insertar(prioridad);
            else
				return await Modificar(prioridad);
		}
        public async Task<Prioridad?> Buscar(int prioridadId) {
            return await _contexto.Prioridades
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PrioridadId == prioridadId);
        }

        public async Task<bool> Eliminar(Prioridad prioridad) {
            var cantidad = await _contexto.Prioridades
                .Where(p => p.PrioridadId == prioridad.PrioridadId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public List<Prioridad> ObtenerLista(Expression<Func<Prioridad, bool>> criterio) {
            return _contexto.Prioridades
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}
