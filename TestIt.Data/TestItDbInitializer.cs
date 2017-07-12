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
            if (!context.SocialIds.Any())
            {
                SocialId socialid_01 = new SocialId
                {
                    Description = "CPF"
                };

                SocialId socialid_02 = new SocialId
                {
                    Description = "RG"
                };

                context.SocialIds.Add(socialid_01);
                context.SocialIds.Add(socialid_02);

            }

            if (!context.Users.Any())
            {
                User user_01 = new User
                {
                    Name = "Dimas",
                    Email = "dimas@gmail.com",
                    Birthday = DateTime.Today,
                    Active = true,
                    IdentifyerType = 1,
                    Password = "abc123",
                    Organization =  new Organization {Id = 1},
                    Phone = "33445566",
                    Identifyer = "444.555.666-9",
                    SocialId = new SocialId() { Id = 1 },

                };
                User user_02 = new User
                {
                    Name = "Luiz",
                    Email = "luiz@gmail.com",
                    Birthday = DateTime.Today,
                    Active = true,
                    IdentifyerType = 2,
                    Password = "123abc",
                    Organization = new Organization { Id = 1},
                    Phone = "45678909",
                    Identifyer = "56.789.678-x",
                    SocialId = new SocialId() { Id = 2 },

                };

                User user_03 = new User
                {
                    Name = "Vitor",
                    Email = "vitor@gmail.com",
                    Birthday = DateTime.Today,
                    Active = true,
                    IdentifyerType = 1,
                    Password = "123abc",
                    Organization = new Organization { Id = 1 },
                    Phone = "12356798",
                    Identifyer = "455.666.777-0",
                    SocialId = new SocialId() { Id = 1 },

                };
                context.Users.Add(user_01);
                context.Users.Add(user_02);
                context.Users.Add(user_03);

            }

            if (!context.Organizations.Any())
            {
                Organization organization_1 = new Organization
                {
                    Name = "Fatec",
                    Description = "Faculdade de tecnologia",
                    Users = new List<User>
                    {
                        new User(){Id = 1},
                        new User(){Id = 2},
                        new User(){Id = 3}
                    }
                };
                context.Organizations.Add(organization_1);
            }

            if (!context.Students.Any())
            {
                Student student_1 = new Student
                {
                    IdUser = 2,
                    User = new User() { Id = 2 },
                    Classes = new List<Class>
                    {
                        new Class(){Id = 1}
                    }

                };
                Student student_2 = new Student
                {
                    IdUser = 3,
                    User = new User() { Id = 3 },
                    Classes = new List<Class>
                    {
                        new Class(){Id = 1}
                    }

                };
                context.Students.Add(student_1);
                context.Students.Add(student_2);
            }

            if (!context.Teachers.Any())
            {
                Teacher teacher_1 = new Teacher
                {
                    IdUser = 1,
                    User = new User() { Id = 1 },
                    Classes = new List<Class>
                    {
                        new Class(){Id = 1}
                    }

                };
                context.Teachers.Add(teacher_1);
            }

            if (!context.Classes.Any())
            {
                Class class_1 = new Class
                {
                    Description = "ADS",
                    Teacher = new Teacher() { Id = 1 },
                    Students = new List<Student>
                    {
                        new Student(){Id = 2},
                        new Student(){Id = 3}
                    }

                };
                context.Classes.Add(class_1);
            }
            context.SaveChanges();
        }
    }
}
