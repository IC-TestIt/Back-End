using System.Collections.Generic;
using System.Linq;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class LogRepository : EntityBaseRepository<Log>, ILogRepository
    {
        public LogRepository(TestItContext context)
            : base(context)
        {
        }

        public IEnumerable<Log> Filter(Log log)
        {
            IQueryable<Log> queryLog = Context.Logs;
           
            if (!string.IsNullOrEmpty(log.Class))
            {
                queryLog = queryLog.Where(x => x.Class.Contains(log.Class));
            }
            if (!string.IsNullOrEmpty(log.Method))
            {
                queryLog = queryLog.Where(x => x.Method.Contains(log.Method));
            }

            return queryLog.ToList();
        }
    }
}
