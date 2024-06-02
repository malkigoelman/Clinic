using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public DbSet<Specialization> Specialization { get; set; }
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["DbConnectionString"]);
            optionsBuilder.LogTo(m=>Debug.WriteLine(m));    
        }

    }
}
