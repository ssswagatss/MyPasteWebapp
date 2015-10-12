using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyPasteWebapp.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DbContext { get; set; }
        public string Email { get; set; }
    }

    public class TenantContext:DbContext
    {
        public TenantContext():base("name=TenantContext")
        {
        }
        public DbSet<Tenant> Tenants { get; set; }
    }
}