using System;
using AtletaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula10
{
    public class AtletaContext : DbContext
    {   
        public DbSet<Atleta> Atletas { get; set; }

        public AtletaContext()
        {
            caminho = @$"{AppDomain.CurrentDomain.BaseDirectory}\atleta.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={caminho}");
        }

        private readonly string caminho;
    }
}