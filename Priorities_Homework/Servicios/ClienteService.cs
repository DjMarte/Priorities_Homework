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

        public async Task<bool> Guardar(Cliente cliente) {
            if (!await Existe(cliente.ClienteId))
                return await Insertar(cliente);
            else
                return await Modificar(cliente);
        }

        private async Task<bool> Insertar(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Cliente cliente) {
            _contexto.Entry(cliente).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

		public async Task<bool> Existe(int clienteId)
        {
            return await _contexto.Clientes.AnyAsync(o => o.ClienteId == clienteId);
        }

        public async Task<Cliente?> Buscar(int clienteId) {
            return await _contexto.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Eliminar(Cliente cliente)
        {
            var cantidad = await _contexto.Clientes
                .Where(c => c.ClienteId == cliente.ClienteId)
                .ExecuteDeleteAsync();
            return cantidad > 0;
        }

        public List<Cliente> ObtenerLista(Expression<Func<Cliente, bool>> criterio) {
            return _contexto.Clientes
               .AsNoTracking()
               .Where(criterio)
               .ToList();
        }
    } 
}