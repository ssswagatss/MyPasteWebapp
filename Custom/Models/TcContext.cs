using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Custom.Models
{
    public class TCContext:DbContext
    {
        public TCContext():base("name=TenantContext")
        {
        }
        public TCContext(string context) : base("Data Source=.;Initial Catalog=" + context + ";Integrated Security=SSPI")
        {
        }

        public DbSet<User> Users{ get; set; }

    }
}