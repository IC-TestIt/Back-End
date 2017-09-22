using System;
using System.Linq;
using TestIt.Model.Entities;

namespace TestIt.Data
{
    public class TestItDbInitializer
    {
        private static TestItContext _context;

        public static void Initialize (IServiceProvider serviceProvider)
        {
            _context = (TestItContext)serviceProvider.GetService(typeof(TestItContext));

            InitializeTestIt();
        }

        private static void InitializeTestIt()
        {
            if (_context.Organizations.Any()) return;
            var organization1 = new Organization
            {
                Name = "Fatec",
                Description = "Faculdade de tecnologia"
            };

            _context.Organizations.Add(organization1);
            _context.SaveChanges();
        }
    }
}
