using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestIt.Model;
using TestIt.Model.Entities;

namespace TestIt.Data
{
    public class TestItContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Teacher> Teachers {get; set;}
        public DbSet<Student> Students {get; set;}
        public DbSet<Organization> Organizations {get; set;}
        public DbSet<Class> Classes {get; set;}
        public DbSet<ClassStudents> ClassStudents { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<EssayQuestion> EssayQuestions { get; set; }
        public DbSet<AlternativeQuestion> AlternativeQuestions { get; set; }
        public DbSet<ClassTests> ClassTests { get; set; }

        public TestItContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region User
            modelBuilder.Entity<User>()
                .ToTable("Users");
            
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(120);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(100);   
            
            modelBuilder.Entity<User>()
                .Property(u => u.Phone)
                .HasMaxLength(12);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Organization)
                .WithMany(u => u.Users);

            modelBuilder.Entity<User>()
                .Property(u => u.Birthday);
            
            modelBuilder.Entity<User>()
                .Property(u => u.IsActive)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Identifier)
                .IsRequired()
                .HasMaxLength(20);
            
            #endregion

            #region Teacher
            modelBuilder.Entity<Teacher>()
                .ToTable("Teachers");

            modelBuilder.Entity<Teacher>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Teacher>()
                .Property(t => t.UserId)
                .IsRequired();

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Classes)
                .WithOne(t => t.Teacher);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Tests)
                .WithOne(t => t.Teacher);
            #endregion

            #region Student
            modelBuilder.Entity<Student>()
                .ToTable("Students");

            modelBuilder.Entity<Student>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Student>()
                .Property(s => s.UserId); 
            
            modelBuilder.Entity<Student>()
                .Property(s => s.UserId)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .HasMany(s => s.ClassStudents);
            #endregion
            
            #region Organization
            modelBuilder.Entity<Organization>()
                .ToTable("Organizations");

            modelBuilder.Entity<Organization>()
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Organization>()
                .Property(o => o.Name)
                .HasMaxLength(120)
                .IsRequired();

            modelBuilder.Entity<Organization>()
                .Property(o => o.Description)
                .HasMaxLength(250)
                .IsRequired();
            
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.Users)
                .WithOne(o => o.Organization);
            #endregion

            #region Class
            modelBuilder.Entity<Class>()
                .ToTable("Classes");
            
            modelBuilder.Entity<Class>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Class>()
                .Property(c => c.TeacherId)
                .IsRequired();   

            modelBuilder.Entity<Class>()
                .Property(c => c.Description)
                .HasMaxLength(250)
                .IsRequired();  

            modelBuilder.Entity<Class>()
                .HasMany(c => c.ClassStudents);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Teacher)
                .WithMany(c => c.Classes);

            modelBuilder.Entity<Class>()
                .HasMany(c => c.ClassTests);
            #endregion

            #region ClassStudents
            modelBuilder.Entity<ClassStudents>()
                .ToTable("ClassStudents");

            modelBuilder.Entity<ClassStudents>()
                .HasOne(x => x.Class)
                .WithMany(x => x.ClassStudents)
                .HasForeignKey(x => x.ClassId);

            modelBuilder.Entity<ClassStudents>()
                .HasOne(x => x.Student)
                .WithMany(x => x.ClassStudents)
                .HasForeignKey(x => x.StudentId);
            #endregion

            #region ClassTests
            modelBuilder.Entity<ClassTests>()
                .ToTable("ClassTests");

            modelBuilder.Entity<ClassTests>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ClassTests>()
                .HasOne(x => x.Class)
                .WithMany(x => x.ClassTests)
                .HasForeignKey(x => x.ClassId);

            modelBuilder.Entity<ClassTests>()
                .HasOne(x => x.Test)
                .WithMany(x => x.ClassTests)
                .HasForeignKey(x => x.TestId);
            #endregion

            #region Test
            modelBuilder.Entity<Test>()
                .ToTable("Tests");

            modelBuilder.Entity<Test>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Test>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.Tests)
                .HasForeignKey(x => x.TeacherId);

            modelBuilder.Entity<Test>()
                .HasMany(x => x.Questions)
                .WithOne(x => x.Test);

            modelBuilder.Entity<Test>()
                .HasMany(x => x.ClassTests);
            #endregion

            #region Question
            modelBuilder.Entity<Question>()
                .ToTable("Questions");

            modelBuilder.Entity<Question>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Test)
                .WithMany(q => q.Questions)
                .HasForeignKey(q => q.TestId);
            #endregion

            #region EssayQuestions
            modelBuilder.Entity<EssayQuestion>()
                .ToTable("EssayQuestions");

            modelBuilder.Entity<EssayQuestion>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<EssayQuestion>()
                .Property(t => t.QuestionId)
                .IsRequired();
            #endregion

            #region AlternativeQuestions
            modelBuilder.Entity<AlternativeQuestion>()
                .ToTable("AlternativeQuestions");

            modelBuilder.Entity<AlternativeQuestion>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<AlternativeQuestion>()
                .Property(t => t.QuestionId)
                .IsRequired();

            modelBuilder.Entity<AlternativeQuestion>()
                .HasMany(t => t.Alternatives)
                .WithOne(t => t.AlternativeQuestion);
            
            #endregion

            #region Alternatives
            modelBuilder.Entity<Alternative>()
                .ToTable("Alternatives");

            modelBuilder.Entity<Alternative>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Alternative>()
                .Property(t => t.AlternativeQuestionId)
                .IsRequired();

            modelBuilder.Entity<Alternative>()
                .HasOne(t => t.AlternativeQuestion)
                .WithMany(t => t.Alternatives);
            #endregion

        }
    }
}
