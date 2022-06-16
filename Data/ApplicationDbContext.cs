using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Symptomfinder.Models;
using Microsoft.AspNetCore.Identity;

namespace Symptomfinder.Data
{
    public class ApplicationDbContext : DbContext
    {
        private int id = 0;
        private IEnumerable<Symptome> symptomes = ConvertCSV.ConvertCSVFile.ReadfromCSVFiles();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // add your own configuration here

            foreach (Symptome symptome in symptomes)
            {
                id += 1;
                modelBuilder.Entity<Symptome>().HasData(new Symptome
                {
                    Id = id,
                    Treatment = symptome.Treatment,
                    Symptoms = symptome.Symptoms,
                    Name = symptome.Name,
                    Causes = symptome.Causes
                });
            }
        }

        public DbSet<Symptome> Symptome { get; set; }
    }
}
