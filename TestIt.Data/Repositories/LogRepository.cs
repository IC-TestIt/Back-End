using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class LogRepository : EntityBaseRepository<Log>, ILogRepository
    {
        public LogRepository(TestItContext context)
            : base(context)
        { }
    }
}
