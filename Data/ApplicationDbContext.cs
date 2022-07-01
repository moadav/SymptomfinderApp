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
            var Common_Symptoms = new List<Filter>();
            Common_Symptoms.Add(new Filter {  Name ="headache" });
            Common_Symptoms.Add(new Filter { Name = "dizziness" });
            Common_Symptoms.Add(new Filter { Name = "weakness" });
            Common_Symptoms.Add(new Filter { Name = "stomach" });
            Common_Symptoms.Add(new Filter { Name = "vomiting" });
            Common_Symptoms.Add(new Filter { Name = "chest" });
            Common_Symptoms.Add(new Filter { Name = "confusion" });

            foreach (Symptome symptome in symptomes)
            {
                id += 1;
                modelBuilder.Entity<Symptome>().HasData(new Symptome
                {
                    Id = id, 
                    Name = symptome.Name,
                    SymptomInformation = symptome.SymptomInformation,
                    
                });
            }

            foreach (Filter filter in Common_Symptoms)
            {
                id += 1;
                modelBuilder.Entity<Filter>().HasData(new Filter
                {
                    Id = id,
                    Name = filter.Name,
                     
                   
                });
            }
        }

        public DbSet<Symptome> Symptome { get; set; }
        public DbSet<Filter> Filter { get; set; }
    }
}
