using Microsoft.EntityFrameworkCore;

namespace Golf.Biz.Persistance
{
    /// <summary>
    /// Contexte de BD pour le golf.
    /// </summary>
    public class ContexteGolf : DbContext
    {
        /// <summary>
        /// Table des parties.
        /// </summary>
        public DbSet<Partie> Partie { get; set; }

        /// <summary>
        /// Constructeur avec options.
        /// </summary>
        /// <param name="options">Options.</param>
        public ContexteGolf()
            : base()
        {
        }

        /// <summary>
        /// Constructeur avec options.
        /// </summary>
        /// <param name="options">Options.</param>
        public ContexteGolf(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Création du modèle.
        /// </summary>
        /// <param name="modelBuilder">Constructeur.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Partie>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Partie>()
                .Property(k => k.Score)
                .IsRequired();
        }

        /// <summary>
        /// Configuration par défaut.
        /// </summary>
        /// <param name="optionsBuilder">Constructeur d'options.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"server=(LocalDb)\MSSQLLocalDb;database=Golf;Integrated Security=True");
            }
        }
    }
}
