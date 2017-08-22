using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class LogRepository : EntityBaseRepository<Log>, ILogRepository
    {
        private TestItContext context;
        public LogRepository(TestItContext context)
            : base(context)
        { }
        
        public IEnumerable<Log> Filter(Log log)
        {
            IQueryable<Log> queryLog = context.Logs;
           
            if (!string.IsNullOrEmpty(log.Class))
            {
                queryLog = queryLog.Where(x => x.Class == log.Class);
            }
            if (!string.IsNullOrEmpty(log.Method))
            {
                queryLog = queryLog.Where(x => x.Method == log.Method);
            }

            return queryLog.ToList();
        }
    }
}
