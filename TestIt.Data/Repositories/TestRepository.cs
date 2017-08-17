using System;
using TestIt.Data;
using TestIt.Data.Abstract;
using TestIt.Data.Repositories;
using TestIt.Model.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestIt.Data.Repositories
{
    public class TestRepository : EntityBaseRepository<Test>, ITestRepository
    {
        private TestItContext context;
        public TestRepository(TestItContext context)
            : base(context)
        {
            this.context = context;
        }

        public Test GetFull(int id)
        {
            var question = (from a in context.Questions
                        join b in context.Tests on a.TestId equals b.Id
                        where a.TestId == id
                        select a).Include(x => x.EssayQuestion).Include(x => x.Test).Include(x => x.AlternativeQuestion.Alternatives).ToList();

            return question.FirstOrDefault().Test ?? null;
        }
    }       
}
