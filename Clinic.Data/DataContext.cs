using Microsoft.EntityFrameworkCore;
using Mirpaha.Entities;
using System.Diagnostics;
//using (var reader = new StreamReader("data.csv"))
//using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
namespace Mirpaha
{
    public class DataContext: DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=sample_db");
            optionsBuilder.LogTo(m=>Debug.WriteLine(m));    
        }

    }
}
