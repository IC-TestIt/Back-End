using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Model.Entities;
using TestIt.Data.Abstract;

namespace TestIt.Data.Repositories
{
    public class AnsweredQuestionRepository : EntityBaseRepository<AnsweredQuestion>, IAnsweredQuestionRepository
    {
        public AnsweredQuestionRepository(TestItContext context)
            : base(context)
        { }
    }
}
