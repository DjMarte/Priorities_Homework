using Microsoft.EntityFrameworkCore;
using Priorities_Homework.DAL;
using Priorities_Homework.Models;
using System.Linq.Expressions;

namespace Priorities_Homework.BLL
{
    public class PrioridadService
    {
        private readonly Contexto _contexto;

        public PrioridadService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task <bool> Existe(int prioridadId) {
            return await _contexto.Prioridades.AnyAsync(o => o.PrioridadId == prioridadId);
        }

        private async Task<bool> Insertar(Prioridades prioridad) {
            _contexto.Prioridades.Add(prioridad);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Prioridades prioridad) {
            _contexto.Entry(prioridad).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Prioridades prioridad) {
			if(! await Existe(prioridad.PrioridadId))

	            return await Insertar(prioridad);
            else
				return await Modificar(prioridad);
		}
        public async Task<Prioridades?> Buscar(int prioridadId) {
            return await _contexto.Prioridades
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PrioridadId == prioridadId);
        }

        public async Task<bool> Eliminar(Prioridades prioridad) {
            var cantidad = await _contexto.Prioridades
                .Where(p => p.PrioridadId == prioridad.PrioridadId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public List<Prioridades> ObtenerLista(Expression<Func<Prioridades, bool>> criterio) {
            return _contexto.Prioridades
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}
