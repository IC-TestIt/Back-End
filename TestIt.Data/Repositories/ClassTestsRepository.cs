using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class ClassTestsRepository : EntityBaseRepository<ClassTests>, IClassTestsRepository
    {
        public ClassTestsRepository(TestItContext context)
            : base(context)
        { }
    }
}
