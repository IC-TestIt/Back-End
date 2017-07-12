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
        public DbSet<SocialId> SocialIds {get; set;}
        public DbSet<Organization> Organizations {get; set;}
        public DbSet<Class> Classes {get; set;}
        
        public TestItContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(u => u.DateCreated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<User>()
                .Property(u => u.DateUpdated);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(120);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();   

            modelBuilder.Entity<User>()
                .Property(u => u.SocialId)
                .IsRequired(); 
            
            modelBuilder.Entity<User>()
                .Property(u => u.Phone)
                .IsRequired()
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
                .Property(u => u.Identifyer)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<User>()
                .Property(u => u.IdentifyerType)
                .IsRequired();

            modelBuilder.Entity<Teacher>()
                .ToTable("Teachers");

            modelBuilder.Entity<Teacher>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd(); 

            modelBuilder.Entity<Teacher>()
                .Property(t => t.DateCreated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Teacher>()
                .Property(t => t.DateUpdated);

            modelBuilder.Entity<Teacher>()
                .Property(t => t.User)
                .IsRequired();

            modelBuilder.Entity<Teacher>()
                .Property(t => t.IdUser)
                .IsRequired();

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Classes)
                .WithOne(t => t.Teacher);

            modelBuilder.Entity<Student>()
                .ToTable("Students");

            modelBuilder.Entity<Student>()
                .Property(s => s.DateCreated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Student>()
                .Property(s => s.DateUpdated);

            modelBuilder.Entity<Student>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();  

            modelBuilder.Entity<Student>()
                .Property(s => s.User)
                .IsRequired();     

            modelBuilder.Entity<Student>()
                .Property(s => s.IdUser)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Classes);

            modelBuilder.Entity<SocialId>()
                .ToTable("SocialIds");  

            modelBuilder.Entity<SocialId>()
                .Property(s => s.DateCreated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<SocialId>()
                .Property(s => s.DateUpdated);

            modelBuilder.Entity<SocialId>()
                .Property(s => s.Description)
                .IsRequired();
            
            modelBuilder.Entity<Organization>()
                .ToTable("Organizations");

            modelBuilder.Entity<Organization>()
                .Property(o => o.DateCreated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Organization>()
                .Property(o => o.DateUpdated);

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
                .Property(c => c.Teacher)
                .IsRequired();   

            modelBuilder.Entity<Class>()
                .Property(c => c.Description)
                .HasMaxLength(250)
                .IsRequired();  

            modelBuilder.Entity<Class>()
                .HasMany(c => c.Students);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Teacher)
                .WithMany(c => c.Classes);
        }
    }
}
