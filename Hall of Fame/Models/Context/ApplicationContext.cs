using Microsoft.EntityFrameworkCore;

namespace Hall_of_Fame.Models.Context
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Skill> Skills { get; set; }

        

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasData(
                    new Person { Id = 1, Name = "Test1", DisplayName = "1" },
                    new Person { Id = 2, Name = "Test2", DisplayName = "2" }
                    
                );

            ///Наполнение данными навыков
            modelBuilder.Entity<Skill>()
                .HasData(
                    new { Name = "Skill1", Id = (long)1, Level = (byte)1 },
                    new { Name = "Skill2", Id = (long)2, Level = (byte)2 }
                   
                );
        }
    }
}
