using TestIt.Data;
using TestIt.Data.Abstract;
using TestIt.Data.Repositories;
using TestIt.Model.Entities;


namespace TestIt.Data.Repositories
{
    public class QuestionRepository : EntityBaseRepository<Question> , IQuestionRepository
    {
        public QuestionRepository(TestItContext context)
            : base(context)
        { }
    }
}
