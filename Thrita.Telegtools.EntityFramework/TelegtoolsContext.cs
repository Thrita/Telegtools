using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Thrita.Telegtools.EntityFramework
{
    public class TelegtoolsContext : DbContext
    {
        public static readonly string SchemaName;

        static TelegtoolsContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TelegtoolsContext>());
            SchemaName =
                ConfigurationManager.AppSettings["Thrita.Telegtools.EntityFramework.Schema"] ?? "Telegtools";
        }

        public TelegtoolsContext() { }

        public TelegtoolsContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        public DbSet<TelegramPost> TelegramPosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema(SchemaName);
            modelBuilder.Configurations.Add(new TelegramPostConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
