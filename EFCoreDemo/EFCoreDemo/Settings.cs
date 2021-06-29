namespace EFCoreDemo
{
    using System;

    public class Settings
    {
        public string Environment { get; set; }

        public bool IsLocal => Environment.ToUpper() == "LOCAL";

        public string LocalConnectionString { get; set; }
    }
}
