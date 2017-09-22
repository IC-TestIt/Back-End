using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TestIt.Data;

namespace TestIt.API.Migrations
{
    [DbContext(typeof(TestItContext))]
    [Migration("20170922213714_AddOrderQuestion")]
    partial class AddOrderQuestion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestIt.Model.Entities.Alternative", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlternativeQuestionId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<bool>("IsCorrect");

                    b.HasKey("Id");

                    b.HasIndex("AlternativeQuestionId");

                    b.ToTable("Alternatives");
                });

            modelBuilder.Entity("TestIt.Model.Entities.AlternativeQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.ToTable("AlternativeQuestions");
                });

            modelBuilder.Entity("TestIt.Model.Entities.AnsweredQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlternativeId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("EssayAnswer");

                    b.Property<int>("ExamId");

                    b.Property<double>("Grade");

                    b.Property<double>("PercentCorrect");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("AlternativeId");

                    b.HasIndex("ExamId");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnsweredQuestions");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

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

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("ClassStudents");
                });

            modelBuilder.Entity("TestIt.Model.Entities.ClassTests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BeginDate");

                    b.Property<int>("ClassId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("TestId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("TestId");

                    b.ToTable("ClassTests");
                });

            modelBuilder.Entity("TestIt.Model.Entities.EssayQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("KeyWords");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.ToTable("EssayQuestions");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BeginDate");

                    b.Property<int>("ClassTestsId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("Status");

                    b.Property<int>("StudentId");

                    b.Property<double>("TotalGrade");

                    b.HasKey("Id");

                    b.HasIndex("ClassTestsId");

                    b.HasIndex("StudentId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Class");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Message");

                    b.Property<string>("Method");

                    b.Property<string>("Source");

                    b.Property<string>("StackTrace");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<int>("Order");

                    b.Property<int>("TestId");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

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

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<int>("TeacherId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("TestIt.Model.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<int>("OrganizationId");

                    b.Property<string>("Password")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Alternative", b =>
                {
                    b.HasOne("TestIt.Model.Entities.AlternativeQuestion", "AlternativeQuestion")
                        .WithMany("Alternatives")
                        .HasForeignKey("AlternativeQuestionId");
                });

            modelBuilder.Entity("TestIt.Model.Entities.AlternativeQuestion", b =>
                {
                    b.HasOne("TestIt.Model.Entities.Question", "Question")
                        .WithOne("AlternativeQuestion")
                        .HasForeignKey("TestIt.Model.Entities.AlternativeQuestion", "QuestionId");
                });

            modelBuilder.Entity("TestIt.Model.Entities.AnsweredQuestion", b =>
                {
                    b.HasOne("TestIt.Model.Entities.Alternative", "Alternative")
                        .WithMany("AnsweredQuestions")
                        .HasForeignKey("AlternativeId");

                    b.HasOne("TestIt.Model.Entities.Exam", "Exam")
                        .WithMany("AnsweredQuestions")
                        .HasForeignKey("ExamId");

                    b.HasOne("TestIt.Model.Entities.Question", "Question")
                        .WithMany("AnsweredQuestions")
                        .HasForeignKey("QuestionId");
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

            modelBuilder.Entity("TestIt.Model.Entities.ClassTests", b =>
                {
                    b.HasOne("TestIt.Model.Entities.Class", "Class")
                        .WithMany("ClassTests")
                        .HasForeignKey("ClassId");

                    b.HasOne("TestIt.Model.Entities.Test", "Test")
                        .WithMany("ClassTests")
                        .HasForeignKey("TestId");
                });

            modelBuilder.Entity("TestIt.Model.Entities.EssayQuestion", b =>
                {
                    b.HasOne("TestIt.Model.Entities.Question", "Question")
                        .WithOne("EssayQuestion")
                        .HasForeignKey("TestIt.Model.Entities.EssayQuestion", "QuestionId");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Exam", b =>
                {
                    b.HasOne("TestIt.Model.Entities.ClassTests", "ClassTests")
                        .WithMany("Exams")
                        .HasForeignKey("ClassTestsId");

                    b.HasOne("TestIt.Model.Entities.Student", "Student")
                        .WithMany("Exams")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Question", b =>
                {
                    b.HasOne("TestIt.Model.Entities.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId");
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

            modelBuilder.Entity("TestIt.Model.Entities.Test", b =>
                {
                    b.HasOne("TestIt.Model.Entities.Teacher", "Teacher")
                        .WithMany("Tests")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("TestIt.Model.Entities.User", b =>
                {
                    b.HasOne("TestIt.Model.Entities.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId");
                });
        }
    }
}
