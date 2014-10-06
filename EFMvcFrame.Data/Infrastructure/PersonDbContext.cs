using EFMvcFrame.Data.Configuration;
using EFMvcFrame.Model.Entites;
using System;
//using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;



namespace EFMvcFrame.Data.Infrastructure
{
    

    public class PersonDbContext :DbContext 
    {
        //XiaoZouStore
        public PersonDbContext()
            : base("PersonStore")
        {
            //Database.SetInitializer<PersonDbContext>(new DropCreateDatabaseAlways<PersonDbContext>());
            Database.SetInitializer<PersonDbContext>(null);
            //Database.SetInitializer<PersonDbContext>(MigrateDatabaseToLatestVersion<PersonDbContext>);
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual void Commit()
        {
            this.SaveChanges();
        }
       

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {

          

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Person>().MapToStoredProcedures();
            //modelBuilder.HasDefaultSchema("public");
            modelBuilder.Configurations.Add(new PersonConfiguration());
            //modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Conventions.Remove)
        }
    }
}
