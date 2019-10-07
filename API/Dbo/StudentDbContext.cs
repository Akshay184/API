using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using API.Models;

namespace API.Dbo
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}