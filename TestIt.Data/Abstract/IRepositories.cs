using TestIt.Model.Entities;

namespace TestIt.Data.Abstract
{
    public interface IUserRepository : IEntityBaseRepository<User> {}
    public interface ITeacherRepository : IEntityBaseRepository<Teacher> {}
    public interface IStudentRepository : IEntityBaseRepository<Student> {}
    public interface ISocialIdRepository : IEntityBaseRepository<SocialIdentifier> {}
    public interface IOrganizationRepository : IEntityBaseRepository<Organization> {}
    public interface IClassRepository : IEntityBaseRepository<Class> {}
    
}
