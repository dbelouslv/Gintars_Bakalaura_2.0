using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BS.EntityData.Context
{
    public interface IDataContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();

        DbSet<Team> Teams { get; set; }
        DbSet<Match> Matches { get; set; }
    }

    public partial class DataContext : DbContext, IDataContext
    {
        public DataContext() : base("name=DataContext")
        {
            Database.SetInitializer<DataContext>(null);
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 300;
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
               .HasRequired(m => m.TeamOne)
               .WithMany()
               .HasForeignKey(m => m.TeamOneId)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
              .HasRequired(m => m.TeamTwo)
              .WithMany()
              .HasForeignKey(m => m.TeamTwoId)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<Particapant>()
              .HasRequired(m => m.Match)
              .WithMany(m => m.Participants)
              .HasForeignKey(m => m.MatchId)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<Particapant>()
              .HasRequired(m => m.Team)
              .WithMany(m => m.Participants)
              .HasForeignKey(m => m.TeamId)
              .WillCascadeOnDelete(false);
        }
    }
}
