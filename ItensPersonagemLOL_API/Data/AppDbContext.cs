using ItensPersonagemLOL_API.Model;
using Microsoft.EntityFrameworkCore;

namespace ItensPersonagemLOL_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                            : base(options)
        {

        }

        public DbSet<Atributo> Atributo { get; set; }
        public DbSet<Classe> Classe { get; set; }
        public DbSet<EfeitoPassivo> EfeitosPassivo { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemAtributo> ItemAtributos { get; set; }
        public DbSet<ItemComponente> ItemComponente { get; set; }
        public DbSet<Personagem> Personagem { get; set; }
        public DbSet<PersonagemItem> PersonagemItens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Relação da ItemComponente
            modelBuilder.Entity<ItemComponente>()
                .HasKey(ic => new { ic.ItemCodigo, ic.ComponenteCodigo });

            modelBuilder.Entity<ItemComponente>()
                .HasOne(ic => ic.Item)
                .WithMany(i => i.Componentes)
                .HasForeignKey(ic => ic.ItemCodigo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemComponente>()
                .HasOne(ic => ic.Componente)
                .WithMany(i => i.UsadoEm)
                .HasForeignKey(ic => ic.ComponenteCodigo)
                .OnDelete(DeleteBehavior.Restrict);

            // Relação da PersonagemItem
            modelBuilder.Entity<PersonagemItem>()
                .HasKey(ia => new { ia.PersonagemCodigo, ia.ItemCodigo });

            modelBuilder.Entity<PersonagemItem>()
                .HasOne(ia => ia.Personagem)
                .WithMany(i => i.PersonagemItens)
                .HasForeignKey(ia => ia.PersonagemCodigo);

            modelBuilder.Entity<PersonagemItem>()
                .HasOne(ia => ia.Item)
                .WithMany(a => a.PersonagemItens)
                .HasForeignKey(ia => ia.ItemCodigo);
        }
    }
}
