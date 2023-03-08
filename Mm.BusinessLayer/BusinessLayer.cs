using DomainModel;
using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IStandardRepository _standardRepository;
        private readonly IStudentRepository _studentRepository;

        public BusinessLayer()
        {
            _teacherRepository = new TeacherRepository();
            _courseRepository = new CourseRepository();
            _standardRepository = new StandardRepository();
            _studentRepository = new StudentRepository();
        }

        public BusinessLayer(ITeacherRepository teacherRepository, ICourseRepository courseRepository, IStandardRepository standardRepository, IStudentRepository studentRepository)
        {
            _teacherRepository = teacherRepository;
            _courseRepository = courseRepository;
            _standardRepository = standardRepository;
            _studentRepository = studentRepository;
        }

        //CRUD for teachers

        public IList<Teacher> GetAllTeachers()
        {
            return _teacherRepository.GetAll();
        }

        public Teacher GetTeacherByName(string teacherName)
        {
            return _teacherRepository.GetSingle(
                d => d.TeacherName.Equals(teacherName),
                d => d.Courses); //include related Courses
        }

        public Teacher GetTeacherById(int teacherID)
        {
            return _teacherRepository.GetSingle(
                d => d.TeacherId.Equals(teacherID),
                d => d.Courses); //include related Courses
        }

        public void AddTeacher(Teacher teachers)
        {
            _teacherRepository.Insert(teachers);
        }

        public void UpdateTeacher(Teacher teachers)
        {
            _teacherRepository.Update(teachers);
        }

        public void RemoveTeacher(Teacher teachers)
        {
            _teacherRepository.Delete(teachers);
        }

        public IList<Course> GetCoursesByTeacherId(int teacherId)
        {
            return _courseRepository.SearchFor(c => c.Teacher.TeacherId.Equals(teacherId));
        }

        //CRUD for courses

        public IList<Course> GetAllCourses()
        {
            return _courseRepository.GetAll();
        }

        public Course GetCourseByName(string courseName)
        {
            return _courseRepository.GetSingle(
                d => d.CourseName.Equals(courseName),
                d => d.Teacher); //include related teacher
        }

        public Course GetCourseById(int courseId)
        {
            return _courseRepository.GetSingle(
                d => d.CourseId.Equals(courseId),
                d => d.Teacher); //include related teacher
        }

        public void AddCourse(params Course[] courses)
        {
            _courseRepository.Add(courses);
        }

        public void UpdateCourse(params Course[] courses)
        {
            _courseRepository.Update(courses);
        }

        public void RemoveCourse(params Course[] courses)
        {
            _courseRepository.Remove(courses);
        }

        //CRUD for standards
        public IList<Standard> GetAllStandards()
        {
            return _standardRepository.GetAll();
        }

        public Standard GetStandardById(int standardId)
        {
            return _standardRepository.GetSingle(
                d => d.StandardId.Equals(standardId),
                d => d.Students,
                d => d.Teachers);
        }

        public void AddStandard(Standard standard)
        {
            _standardRepository.Add(standard); 
        }

        public void UpdateStandard(Standard standard)
        {
            _standardRepository.Update(standard);
        }

        public void RemoveStandard(Standard standard)
        {
            _standardRepository.Remove(standard);
        }

        //CRUD for students

        public IList<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student GetStudentById(int studentId)
        {
            return _studentRepository.GetSingle(
                d => d.StudentID.Equals(studentId),
                d => d.Courses);
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }

        public void RemoveStudent(Student student)
        {
            _studentRepository.Remove(student);
        }
    }
}