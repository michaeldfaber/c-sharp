namespace EFCoreDemo.DbContext
{
    using EFCoreDemo.EFModels;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class LocalDbContext : DbContext, ILocalDbContext
    {
        public const string DefaultSchema = "efcoredemo";

        public LocalDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DefaultSchema);
            base.OnModelCreating(modelBuilder);
        }
    }
}
