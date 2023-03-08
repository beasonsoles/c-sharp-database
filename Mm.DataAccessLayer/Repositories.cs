using DomainModel;

namespace DataAccessLayer
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
    }

    public interface ICourseRepository : IRepository<Course>
    {
    }
    
    public interface IStandardRepository : IRepository<Standard>
    {
    }
    
    public interface IStudentRepository : IRepository<Student> 
    { 
    }

    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
    }

    public class CourseRepository : Repository<Course>, ICourseRepository
    {
    }
    
    public class StandardRepository : Repository<Standard>, IStandardRepository
    {
    }
    
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
    }
    
    public StudentRepository()
    : base(new SchoolDBEntities())
    {
    }
}
