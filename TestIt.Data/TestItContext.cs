﻿using System;
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
                .Property(u => u.DateCreated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<User>()
                .Property(u => u.DateUpdated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(120);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(25);   
            
            modelBuilder.Entity<User>()
                .Property(u => u.Phone)
                .HasMaxLength(12);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Organization)
                .WithMany(u => u.Users);

            modelBuilder.Entity<User>()
                .Property(u => u.Birthday);
            
            modelBuilder.Entity<User>()
                .Property(u => u.Active)
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
                .Property(t => t.DateCreated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Teacher>()
                .Property(t => t.DateUpdated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Teacher>()
                .Property(t => t.UserId)
                .IsRequired();

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Classes)
                .WithOne(t => t.Teacher);
            #endregion

            #region Student
            modelBuilder.Entity<Student>()
                .ToTable("Students");

            modelBuilder.Entity<Student>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Student>()
                .Property(s => s.DateCreated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Student>()
                .Property(s => s.DateUpdated);

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
                .Property(o => o.DateCreated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Organization>()
                .Property(o => o.DateUpdated)
                .HasDefaultValue(DateTime.Now);

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
                .Property(c => c.DateCreated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Class>()
                .Property(c => c.DateUpdated);

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
        }
    }
}
