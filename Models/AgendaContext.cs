using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Agenda.Models
{
    public class AgendaContext: DbContext
    {
        public AgendaContext() : base()
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=localhost;Database=agenda;Trusted_Connection=True;");
            optionBuilder.EnableSensitiveDataLogging();
           // base.OnConfiguring(optionBuilder);
        }
    }
}
