using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Thrita.Telegtools.EntityFramework
{
    public class TelegtoolsContext : DbContext
    {
        public const string DefaultConnectionStringName = "Thrita.Telegtools.EntityFramework.DbConnection";
        public const string DefaultSchemaAppSettingKey = "Thrita.Telegtools.EntityFramework.Schema";
        public const string DefaultSchema = "Telegtools";

        public static readonly string SchemaName;

        static TelegtoolsContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TelegtoolsContext>());
            SchemaName = ConfigurationManager.AppSettings[DefaultSchemaAppSettingKey] ?? DefaultSchema;
        }

        public TelegtoolsContext() : this(DefaultConnectionStringName) { }

        public TelegtoolsContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        public DbSet<TelegramPost> TelegramPosts { get; set; }

        public DbSet<TelegtoolsJob> Jobs { get; set; }

        public DbSet<TelegtoolsLog> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema(SchemaName);
            modelBuilder.Configurations.Add(new TelegramPostConfig());
            base.OnModelCreating(modelBuilder);
        }

        internal static object FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            return System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
