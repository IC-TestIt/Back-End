using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class LogService : ILogService
    {
        private ILogRepository LogRepository { get; set; }

        public LogService(ILogRepository logRepository)
        {
            this.LogRepository = logRepository;
        }

        public void Save(Log log)
        {
            LogRepository.Add(log);
            LogRepository.Commit();
        }

        public IEnumerable<Log> Filter(Log log )
        {
            var logs = LogRepository.Filter(log);
            return logs;
        }
    }
}
