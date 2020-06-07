using Microsoft.EntityFrameworkCore;

namespace OlifelVersionUpdateAPI.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
            //
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Versao> Versoes { get; set; }
        public DbSet<VersaoCliente> VersoesClientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Cliente>().ToTable("Cliente");
            builder.Entity<Utilizador>().ToTable("Utilizador");
            builder.Entity<Grupo>().ToTable("Grupo");
            builder.Entity<Versao>().ToTable("Versao");
            builder.Entity<VersaoCliente>().ToTable("VersaoCliente");

            //builder.Entity<Cliente>().HasKey(c => c.Id);
            builder.Entity<Utilizador>().HasKey(u => u.Id);
            builder.Entity<Grupo>().HasKey(g => g.Id);
            builder.Entity<Versao>().HasKey(v => v.Id);
            builder.Entity<VersaoCliente>().HasKey(v => new { v.Cliente_ID, v.Versao_ID });

            //builder.Entity<Cliente>().Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Entity<Utilizador>().Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Entity<Versao>().Property(v => v.Id).ValueGeneratedOnAdd();
        }
    }
}
