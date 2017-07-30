using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TestIt.Data;

namespace TestIt.API.Migrations
{
    [DbContext(typeof(TestItContext))]
    [Migration("20170712161914_Add-OrganizationId")]
    partial class AddOrganizationId
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
                        .HasDefaultValue(new DateTime(2017, 7, 12, 13, 19, 14, 483, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int?>("StudentId");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local));

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

            modelBuilder.Entity("TestIt.Model.Entities.SocialIdentifier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 13, 19, 14, 482, DateTimeKind.Local));

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("SocialIds");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClassId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 13, 19, 14, 481, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 13, 19, 14, 477, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 13, 19, 14, 477, DateTimeKind.Local));

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
                        .HasDefaultValue(new DateTime(2017, 7, 12, 13, 19, 14, 460, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 7, 12, 13, 19, 14, 468, DateTimeKind.Local));

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
                    b.HasOne("TestIt.Model.Entities.Student")
                        .WithMany("Classes")
                        .HasForeignKey("StudentId");

                    b.HasOne("TestIt.Model.Entities.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("TestIt.Model.Entities.Student", b =>
                {
                    b.HasOne("TestIt.Model.Entities.Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId");

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
