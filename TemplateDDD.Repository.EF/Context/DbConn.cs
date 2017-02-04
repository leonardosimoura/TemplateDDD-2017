using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TemplateDDD.Domain.Entidade;
using TemplateDDD.Repository.EF.Metadata;

namespace TemplateDDD.Repository.EF.Context
{
    public class DbConnConfiguration : DbConfiguration
    {
        public DbConnConfiguration()
        {
            SetExecutionStrategy(
                "System.Data.SqlClient",
                () => new SqlAzureExecutionStrategy(2, TimeSpan.FromSeconds(30)));
        }
    }

    [DbConfigurationType(typeof(DbConnConfiguration))]
    public class DbConn: DbContext
    {
        public DbConn():base("DbConn")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new CreateDatabaseIfNotExists<DbConn>());
        }
        
        public DbSet<Usuario> Usuario { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>().Configure(a => a.HasMaxLength(500).IsVariableLength().IsUnicode(false));

            modelBuilder.Properties().Where(prop => prop.Name == "Id" + prop.ReflectedType.Name)
                .Configure(config => config.IsKey());

            modelBuilder.Entity<Usuario>()
                .Property(c => c.Nome)
                .HasMaxLength(250)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
