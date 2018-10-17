using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using DbSet = Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
//using Microsoft.EntityFrameworkCore;


namespace ContactManager.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }   
    }

    public class ContactContexto : DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Contact> Contact { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

    }


}