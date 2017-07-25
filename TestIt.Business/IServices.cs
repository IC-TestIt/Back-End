﻿using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Model.Entities;

namespace TestIt.Business
{
    public interface IUserService
    {
        bool ValidLogin(string email, string pswd);
        IEnumerable<User> Get();

        User GetSingle(int id);

        void Save(User u);

        void Delete(int id);

        bool Update(int id, User u);

        int Exists(string email);
    }

    public interface ITeacherService 
    {
        IEnumerable<Teacher> Get();

        Teacher GetSingle(int id);

        void Save(Teacher t);

        void Delete(int id);

        void Update(int id, Teacher teacher);

        Teacher GetByUser(int id);
    }

    public interface IClassService
    {
        void Save(Class c);

        IEnumerable<User> ClassUsers(int id);
        Class GetSingle(int id);
        IEnumerable<Class> Get();
    }

    public interface IStudentService
    {
        IEnumerable<Student> Get();

        Student GetSingle(int id);

        void Save(Student s);

        void Delete(int id);

        void Update(int id, Student student);
        Student GetByUser(int id);
        void SendSignUp(User user, int studentId);
        void SendInvite(User user, Class clas);
    }

    public interface IClassStudentsService
    {
        void Save(ClassStudents cs);
    }
}
