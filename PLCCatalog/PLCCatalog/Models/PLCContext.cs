using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PLCCatalog.Models
{
    public class PLCContext : DbContext
    {

        public PLCContext() :
                    base("DefaultConnection")
        { }
        public DbSet<PLC> PLCs { get; set; }

    }

    public class PLCDbInitializer :DropCreateDatabaseAlways<PLCContext>
    { 
        protected override void Seed (PLCContext db)
        {
            db.PLCs.Add(new PLC { Name = "Siemens S-1200", Discription = "Good PLC", NumOfIO = "12 DI, 6 DO, 8 AI, 3 RTD", Country = "Germany", Sphere = "industrial automation;" });
        }
    }
}