﻿' <auto-generated />
Imports System
Imports DataAccess
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Infrastructure
Imports Microsoft.EntityFrameworkCore.Metadata
Imports Microsoft.EntityFrameworkCore.Migrations

Namespace Global.DataAccess.Migrations
    <DbContext(GetType(LibraryContext))>
    <Migration("20240112075704_mig13")>
    Partial Class mig13
        ''' <inheritdoc />
        Protected Overrides Sub BuildTargetModel(modelBuilder As ModelBuilder)
            modelBuilder.
                HasAnnotation("ProductVersion", "7.0.15").
                HasAnnotation("Relational:MaxIdentifierLength", 128)

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder)

            modelBuilder.Entity("Models.Book",
                Sub(b)
                    b.Property(Of Integer)("Id").
                        ValueGeneratedOnAdd().
                        HasColumnType("int")

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property(Of Integer)("Id"))

                    b.Property(Of String)("AuthorName").
                        HasColumnType("nvarchar(max)")

                    b.Property(Of Long)("CreatedBy").
                        HasColumnType("bigint")

                    b.Property(Of Date)("CreatedDate").
                        HasColumnType("datetime2")

                    b.Property(Of Long)("DeletedBy").
                        HasColumnType("bigint")

                    b.Property(Of Date)("DeletedDate").
                        HasColumnType("datetime2")

                    b.Property(Of Boolean)("IsDeleted").
                        HasColumnType("bit")

                    b.Property(Of String)("Name").
                        HasColumnType("nvarchar(max)")

                    b.Property(Of String)("Type").
                        HasColumnType("nvarchar(max)")

                    b.Property(Of Long)("UpdatedBy").
                        HasColumnType("bigint")

                    b.Property(Of Date)("UpdatedDate").
                        HasColumnType("datetime2")

                    b.Property(Of Long?)("UserId").
                        HasColumnType("bigint")

                    b.HasKey("Id")

                    b.HasIndex("UserId")

                    b.ToTable("Books")
                End Sub)

            modelBuilder.Entity("Models.User",
                Sub(b)
                    b.Property(Of Long)("Id").
                        ValueGeneratedOnAdd().
                        HasColumnType("bigint")

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property(Of Long)("Id"))

                    b.Property(Of Long)("CreatedBy").
                        HasColumnType("bigint")

                    b.Property(Of Date)("CreatedDate").
                        HasColumnType("datetime2")

                    b.Property(Of Long)("DeletedBy").
                        HasColumnType("bigint")

                    b.Property(Of Date)("DeletedDate").
                        HasColumnType("datetime2")

                    b.Property(Of String)("EMail").
                        HasColumnType("nvarchar(max)")

                    b.Property(Of String)("IdNumber").
                        HasColumnType("nvarchar(max)")

                    b.Property(Of Boolean)("IsDeleted").
                        HasColumnType("bit")

                    b.Property(Of String)("LastName").
                        HasColumnType("nvarchar(max)")

                    b.Property(Of String)("Name").
                        HasColumnType("nvarchar(max)")

                    b.Property(Of String)("Password").
                        HasColumnType("nvarchar(max)")

                    b.Property(Of String)("PhoneNumber").
                        HasColumnType("nvarchar(max)")

                    b.Property(Of String)("Photo").
                        HasColumnType("nvarchar(max)")

                    b.Property(Of Long)("UpdatedBy").
                        HasColumnType("bigint")

                    b.Property(Of Date)("UpdatedDate").
                        HasColumnType("datetime2")

                    b.HasKey("Id")

                    b.ToTable("Users")
                End Sub)

            modelBuilder.Entity("Models.UserBook",
                Sub(b)
                    b.Property(Of Long)("Id").
                        ValueGeneratedOnAdd().
                        HasColumnType("bigint")

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property(Of Long)("Id"))

                    b.Property(Of Integer)("BookId").
                        HasColumnType("int")

                    b.Property(Of Long)("CreatedBy").
                        HasColumnType("bigint")

                    b.Property(Of Date)("CreatedDate").
                        HasColumnType("datetime2")

                    b.Property(Of Long)("DeletedBy").
                        HasColumnType("bigint")

                    b.Property(Of Date)("DeletedDate").
                        HasColumnType("datetime2")

                    b.Property(Of Boolean)("IsDeleted").
                        HasColumnType("bit")

                    b.Property(Of Long)("UpdatedBy").
                        HasColumnType("bigint")

                    b.Property(Of Date)("UpdatedDate").
                        HasColumnType("datetime2")

                    b.Property(Of Long)("UserId").
                        HasColumnType("bigint")

                    b.HasKey("Id")

                    b.HasIndex("BookId")

                    b.HasIndex("UserId")

                    b.ToTable("UserBooks")
                End Sub)

            modelBuilder.Entity("Models.Book",
                Sub(b)
                    b.HasOne("Models.User", Nothing).
                        WithMany("Books").
                        HasForeignKey("UserId")
                End Sub)

            modelBuilder.Entity("Models.UserBook",
                Sub(b)
                    b.HasOne("Models.Book", "Book").
                        WithMany().
                        HasForeignKey("BookId").
                        OnDelete(DeleteBehavior.Cascade).
                        IsRequired()

                    b.HasOne("Models.User", "User").
                        WithMany().
                        HasForeignKey("UserId").
                        OnDelete(DeleteBehavior.Cascade).
                        IsRequired()
                    b.Navigation("Book")

                    b.Navigation("User")
                End Sub)

            modelBuilder.Entity("Models.User",
                Sub(b)
                    b.Navigation("Books")
                End Sub)
        End Sub
    End Class
End Namespace
