using Microsoft.EntityFrameworkCore;
using Priorities_Homework.DAL;
using Priorities_Homework.Models;
using System.Linq.Expressions;

namespace Priorities_Homework.Servicios
{
    public class TicketService
    {
        private readonly Contexto _contexto;

        public TicketService(Contexto contexto) {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int ticketId) {
            return await _contexto.Tickets.AnyAsync(o => o.TicketId == ticketId);
        }

        private async Task<bool> Insertar(Tickets ticket) {
            _contexto.Tickets.Add(ticket);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Tickets ticket) {
            _contexto.Entry(ticket).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Tickets ticket) {
            if (!await Existe(ticket.TicketId))
                return await Insertar(ticket);
            else
                return await Modificar(ticket);
        }

        public async Task<Tickets?> Buscar(int ticketId) {
            return await _contexto.Tickets
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.TicketId == ticketId);
        }

        public async Task<bool> Eliminar(Tickets ticket) {
            var cantidad = await _contexto.Tickets
                .Where(p => p.TicketId == ticket.TicketId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public List<Tickets> ObtenerLista(Expression<Func<Tickets, bool>> criterio) {
            return _contexto.Tickets
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }           
    }
}
