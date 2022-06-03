using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class DbContextClass :DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options):base(options)
        {

        }
        public DbSet<PensionerModel> Pensioner { get; set; }
        public DbSet<PensionDetail> Pensiondetail { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder);
    }
}
