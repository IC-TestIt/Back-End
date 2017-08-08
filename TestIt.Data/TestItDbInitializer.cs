using System;
using System.Linq;
using TestIt.Model.Entities;

namespace TestIt.Data
{
    public class TestItDbInitializer
    {
        private static TestItContext context;

        public static void Initialize (IServiceProvider serviceProvider)
        {
            context = (TestItContext)serviceProvider.GetService(typeof(TestItContext));

            InitializeTestIt();
        }

        private static void InitializeTestIt()
        {
            if (!context.Organizations.Any())
            {
                var organization_1 = new Organization
                {
                    Name = "Fatec",
                    Description = "Faculdade de tecnologia"
                };

                context.Organizations.Add(organization_1);
                context.SaveChanges();
            }
        }
    }
}
