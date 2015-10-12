using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperAdmin.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DbContext { get; set; }
        public string Email { get; set; }
    }
}