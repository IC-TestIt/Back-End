using TestIt.Data.Abstract;
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
