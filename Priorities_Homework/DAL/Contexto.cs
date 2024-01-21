using Microsoft.EntityFrameworkCore;
using Priorities_Homework.Models;

namespace Priorities_Homework.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Prioridad> Prioridades { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            
        }
    }
}