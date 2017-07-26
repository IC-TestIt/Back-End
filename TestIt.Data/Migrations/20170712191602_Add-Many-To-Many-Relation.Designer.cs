using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TestIt.Data;

namespace TestIt.Data.Migrations
{
    [DbContext(typeof(TestItContext))]
    [Migration("20170712191602_Add-Many-To-Many-Relation")]
    partial class AddManyToManyRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestIt.Model.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 16, 16, 1, 919, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("TestIt.Model.Entities.ClassStudents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassId");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("ClassStudents");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 16, 16, 1, 918, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 16, 16, 1, 918, DateTimeKind.Local));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("TestIt.Model.Entities.SocialIdentifier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 16, 16, 1, 917, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 16, 16, 1, 918, DateTimeKind.Local));

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("SocialIds");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 16, 16, 1, 917, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 16, 16, 1, 912, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 16, 16, 1, 912, DateTimeKind.Local));

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("TestIt.Model.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 16, 16, 1, 890, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 16, 16, 1, 901, DateTimeKind.Local));

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<int>("OrganizationId");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<int>("SocialIdentifierId");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("SocialIdentifierId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Class", b =>
                {
                    b.HasOne("TestIt.Model.Entities.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("TestIt.Model.Entities.ClassStudents", b =>
                {
                    b.HasOne("TestIt.Model.Entities.Class", "Class")
                        .WithMany("ClassStudents")
                        .HasForeignKey("ClassId");

                    b.HasOne("TestIt.Model.Entities.Student", "Student")
                        .WithMany("ClassStudents")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Student", b =>
                {
                    b.HasOne("TestIt.Model.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Teacher", b =>
                {
                    b.HasOne("TestIt.Model.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TestIt.Model.Entities.User", b =>
                {
                    b.HasOne("TestIt.Model.Entities.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId");

                    b.HasOne("TestIt.Model.Entities.SocialIdentifier", "SocialIdentifier")
                        .WithMany()
                        .HasForeignKey("SocialIdentifierId");
                });
        }
    }
}
