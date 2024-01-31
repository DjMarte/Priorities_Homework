using Microsoft.EntityFrameworkCore;
using Priorities_Homework.DAL;
using Priorities_Homework.Models;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Priorities_Homework.BLL
{
	public class ClienteService
	{
		private readonly Contexto _contexto;

        public ClienteService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Guardar(Clientes cliente) {
            if (!await Existe(cliente.ClienteId))
                return await Insertar(cliente);
            else
                return await Modificar(cliente);
        }

        private async Task<bool> Insertar(Clientes cliente)
        {
            _contexto.Clientes.Add(cliente);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Clientes cliente) {
            _contexto.Entry(cliente).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

		public async Task<bool> Existe(int clienteId)
        {
            return await _contexto.Clientes.AnyAsync(o => o.ClienteId == clienteId);
        }

		public async Task<Clientes?> BuscarId(int clienteId) {
			return await _contexto.Clientes
				.AsNoTracking()
				.FirstOrDefaultAsync(c => c.ClienteId == clienteId);
		}

		public async Task<Clientes?> BuscarNombre(string nombre) {
			return await _contexto.Clientes
				.AsNoTracking()
				.FirstOrDefaultAsync(c => c.Nombre.ToLower() == nombre.ToLower());
		}

		public async Task<Clientes?> BuscarRNC(string Rnc) {
			return await _contexto.Clientes
				.AsNoTracking()
				.FirstOrDefaultAsync(c => c.RNC == Rnc);
		}
		public async Task<bool> Eliminar(Clientes cliente)
        {
            var cantidad = await _contexto.Clientes
                .Where(c => c.ClienteId == cliente.ClienteId)
                .ExecuteDeleteAsync();
            return cantidad > 0;
        }

        public List<Clientes> ObtenerLista(Expression<Func<Clientes, bool>> criterio) {
            return _contexto.Clientes
               .AsNoTracking()
               .Where(criterio)
               .ToList();
        }
    } 
}