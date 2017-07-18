using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text;
using TestIt.Model.Entities;

namespace TestIt.Data
{
    public class TestItDbInitializer
    {
        private static TestItContext context;

        public static void Initialize (IServiceProvider serviceProvider)
        {
            context = (TestItContext)serviceProvider.GetService(typeof(TestItContext));

            InitializeTestIt();
        }

        private static void InitializeTestIt()
        {
            List<User> users = new List<User>();

            if (!context.Users.Any())
            {
                users.Add(new User
                {
                    Name = "Dimas",
                    Email = "dimas@gmail.com",
                    Birthday = DateTime.Today,
                    Active = true,
                    Password = "abc123",
                    Phone = "33445566",
                    Identifyer = "444.555.666-9"
                });

                users.Add(new User
                {
                    Name = "Luiz",
                    Email = "luiz@gmail.com",
                    Birthday = DateTime.Today,
                    Active = true,
                    Password = "123abc",
                    Phone = "45678909",
                    Identifyer = "56.789.678-x"
                });

                users.Add(new User
                {
                    Name = "Vitor",
                    Email = "vitor@gmail.com",
                    Birthday = DateTime.Today,
                    Active = true,
                    Password = "123abc",
                    Phone = "12356798",
                    Identifyer = "455.666.777-0"
                });
            }

            if (!context.Organizations.Any())
            {
                var organization_1 = new Organization
                {
                    Users = users,
                    Name = "Fatec",
                    Description = "Faculdade de tecnologia"
                };

                context.Organizations.Add(organization_1);
                context.SaveChanges();
            }

            List<Student> students = new List<Student>();
            List<ClassStudents> classStudents = new List<ClassStudents>();
            
            if (!context.Students.Any())
            {
                students.Add(new Student
                {
                    UserId = 15
                });

                students.Add(new Student
                {
                    UserId = 16
                });

                context.AddRange(students);
                context.SaveChanges();
            }

            List<Class> classes = new List<Class>();

            if (!context.Classes.Any())
            {
                classes.Add( new Class
                {
                    Description = "Alog",
                    ClassStudents = classStudents,
                    TeacherId = 5
                });

                context.Classes.AddRange(classes);
            }

            if (!context.Teachers.Any())
            {
                Teacher teacher_1 = new Teacher
                {
                    UserId = 14,
                    Classes = classes
                };

                context.Teachers.Add(teacher_1);

                context.SaveChanges();
            }

            if (!context.ClassStudents.Any())
            {
                classStudents.Add(new ClassStudents()
                {
                    ClassId = 4,
                    StudentId = 5
                });

                classStudents.Add(new ClassStudents()
                {
                    ClassId = 4,
                    StudentId = 6
                });

                context.ClassStudents.AddRange(classStudents);
                context.SaveChanges();
            }
        }
    }
}
