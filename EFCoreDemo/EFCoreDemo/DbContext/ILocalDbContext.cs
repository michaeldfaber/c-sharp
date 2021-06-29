namespace EFCoreDemo.DbContext
{
    using EFCoreDemo.EFModels;
    using Microsoft.EntityFrameworkCore;
    using System;

    public interface ILocalDbContext
    {
        DbSet<Person> Persons { get; set; }
    }
}
