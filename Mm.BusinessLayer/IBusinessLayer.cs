﻿using DomainModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IBusinessLayer
    {
        IList<Teacher> GetAllTeachers();
        Teacher GetTeacherByName(string teacherName);
        Teacher GetTeacherById(int teacherID);
        void AddTeacher(params Teacher[] teachers);
        void UpdateTeacher(params Teacher[] teachers);
        void RemoveTeacher(params Teacher[] teachers);

        IList<Course> GetCoursesByTeacherId(int teacherId);

        IList<Course> GetAllCourses();
        Course GetCourseByName(string courseName);
        Course GetCourseById(int courseId);
        void AddCourse(params Course[] courses);
        void UpdateCourse(params Course[] courses);
        void RemoveCourse(params Course[] courses);

        IList<Standard> GetAllStandards();
        Standard GetStandardById(int id);
        void AddStandard(Standard standard);
        void UpdateStandard(Standard standard);
        void RemoveStandard(Standard standard);

        IList<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);
    }
}