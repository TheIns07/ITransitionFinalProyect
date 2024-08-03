﻿// <auto-generated />
using System;
using ITransitionFinalAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITransitionFinalAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ITransitionFinalAPI.Models.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("CustomBoolean1")
                        .HasColumnType("bit");

                    b.Property<bool?>("CustomBoolean2")
                        .HasColumnType("bit");

                    b.Property<bool?>("CustomBoolean3")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CustomDate1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CustomDate2")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CustomDate3")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomInt1")
                        .HasColumnType("int");

                    b.Property<int?>("CustomInt2")
                        .HasColumnType("int");

                    b.Property<int?>("CustomInt3")
                        .HasColumnType("int");

                    b.Property<string>("CustomMultilineText1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomMultilineText2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomMultilineText3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomString1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomString2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomString3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateSigned")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserCollectorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserCollectorId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("ITransitionFinalAPI.Models.CollectionComments", b =>
                {
                    b.Property<int>("IdCollection")
                        .HasColumnType("int");

                    b.Property<int>("IdComment")
                        .HasColumnType("int");

                    b.Property<int>("IdCollectorUser")
                        .HasColumnType("int");

                    b.Property<int>("UserCollectorId")
                        .HasColumnType("int");

                    b.HasKey("IdCollection", "IdComment");

                    b.HasIndex("IdComment");

                    b.HasIndex("UserCollectorId");

                    b.ToTable("CommentsInCollections");
                });

            modelBuilder.Entity("ITransitionFinalAPI.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ITransitionFinalAPI.Models.LikedCollection", b =>
                {
                    b.Property<int>("IdCollection")
                        .HasColumnType("int");

                    b.Property<int>("IdUserCollector")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistred")
                        .HasColumnType("datetime2");

                    b.HasKey("IdCollection", "IdUserCollector");

                    b.HasIndex("IdUserCollector");

                    b.ToTable("LikedCollections");
                });

            modelBuilder.Entity("ITransitionFinalAPI.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CollectionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ITransitionFinalAPI.Models.UserCollector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateSigned")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserCollectors");
                });

            modelBuilder.Entity("ITransitionFinalAPI.Models.Collection", b =>
                {
                    b.HasOne("ITransitionFinalAPI.Models.UserCollector", null)
                        .WithMany("Collections")
                        .HasForeignKey("UserCollectorId");
                });

            modelBuilder.Entity("ITransitionFinalAPI.Models.CollectionComments", b =>
                {
                    b.HasOne("ITransitionFinalAPI.Models.Collection", "Collection")
                        .WithMany("Comments")
                        .HasForeignKey("IdCollection")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITransitionFinalAPI.Models.Comment", "Comment")
                        .WithMany("CollectionComments")
                        .HasForeignKey("IdComment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITransitionFinalAPI.Models.UserCollector", "UserCollector")
                        .WithMany("Comments")
                        .HasForeignKey("UserCollectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("Comment");

                    b.Navigation("UserCollector");
                });

            modelBuilder.Entity("ITransitionFinalAPI.Models.LikedCollection", b =>
                {
                    b.HasOne("ITransitionFinalAPI.Models.Collection", "Collection")
                        .WithMany("LikedCollections")
                        .HasForeignKey("IdCollection")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITransitionFinalAPI.Models.UserCollector", "UserCollector")
                        .WithMany("LikedCollections")
                        .HasForeignKey("IdUserCollector")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("UserCollector");
                });

            modelBuilder.Entity("ITransitionFinalAPI.Models.Tag", b =>
                {
                    b.HasOne("ITransitionFinalAPI.Models.Collection", null)
                        .WithMany("Tags")
                        .HasForeignKey("CollectionId");
                });

            modelBuilder.Entity("ITransitionFinalAPI.Models.Collection", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("LikedCollections");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("ITransitionFinalAPI.Models.Comment", b =>
                {
                    b.Navigation("CollectionComments");
                });

            modelBuilder.Entity("ITransitionFinalAPI.Models.UserCollector", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("Comments");

                    b.Navigation("LikedCollections");
                });
#pragma warning restore 612, 618
        }
    }
}