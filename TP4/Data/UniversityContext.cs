using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TP4.Models;

namespace TP4.Data
{
    public class UniversityContext : DbContext
    {
        private static UniversityContext _context = null;
        public DbSet<Student> Student { get; set; }




        private UniversityContext(DbContextOptions o) : base(o)
        {

        }

        public static UniversityContext Instantiate_UniversityContext()
        {
            try
            {
                Debug.WriteLine(" Dans methode instantiate ");
                if (_context == null)
                {
                    Debug.WriteLine("un instance est cree ");
                    var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
                    optionsBuilder.UseSqlite(@"Data Source=C:\Users\sourour\Downloads\2022 GL3 .NET Framework TP4 - SQLite database.db");
                    _context = new UniversityContext(optionsBuilder.Options);
                }

                return _context;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("un exception est trouvee hahahaha" + ex.Message);
            }
            return _context;
        }
    }
}
