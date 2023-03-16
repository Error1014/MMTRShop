﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthorizationMicroservice.Authorization.Repository.UserMigrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20230315114812_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MMTRShop.Repository.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("MMTRShop.Repository.Entities.Admin", b =>
                {
                    b.HasBaseType("MMTRShop.Repository.Entities.User");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("MMTRShop.Repository.Entities.Client", b =>
                {
                    b.HasBaseType("MMTRShop.Repository.Entities.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("MMTRShop.Repository.Entities.Operator", b =>
                {
                    b.HasBaseType("MMTRShop.Repository.Entities.User");

                    b.ToTable("Operator", (string)null);
                });

            modelBuilder.Entity("MMTRShop.Repository.Entities.Admin", b =>
                {
                    b.HasOne("MMTRShop.Repository.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("MMTRShop.Repository.Entities.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MMTRShop.Repository.Entities.Client", b =>
                {
                    b.HasOne("MMTRShop.Repository.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("MMTRShop.Repository.Entities.Client", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MMTRShop.Repository.Entities.Operator", b =>
                {
                    b.HasOne("MMTRShop.Repository.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("MMTRShop.Repository.Entities.Operator", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}