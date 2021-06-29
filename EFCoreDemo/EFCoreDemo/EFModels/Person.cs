namespace EFCoreDemo.EFModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        [Key]
        public int Id { get; set; }

        public int Age { get; set; }
    }
}
