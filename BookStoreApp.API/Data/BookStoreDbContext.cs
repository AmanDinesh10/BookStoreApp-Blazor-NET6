using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStoreApp.API.Data
{
    public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
    {
        public BookStoreDbContext()
        {
        }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Bio).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EAD8B53372")
                    .IsUnique();

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Summary).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_ToTable");
            });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "a15fff9b-0e00-4f7d-bee0-6b74a4e14339"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Id = "be92ca08-6b57-4eee-bc95-1b51015e8e2c"
                }
            );

            var hasher = new PasswordHasher<ApiUser>();
            modelBuilder.Entity<ApiUser>().HasData(
                new ApiUser
                {
                    Id = "414dcdef-280d-45f8-a6c9-98d7ad09a2e4",
                    Email = "admin@bookstore.com",
                    NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                    UserName = "admin@bookstore.com",
                    NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                },
                new ApiUser
                {
                    Id = "ebc02af4-5bf0-4ade-9829-501c89a1a55a",
                    Email = "user@bookstore.com",
                    NormalizedEmail = "USER@BOOKSTORE.COM",
                    UserName = "user@bookstore.com",
                    NormalizedUserName = "USER@BOOKSTORE.COM",
                    FirstName = "System",
                    LastName = "user",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "a15fff9b-0e00-4f7d-bee0-6b74a4e14339",
                    UserId = "ebc02af4-5bf0-4ade-9829-501c89a1a55a"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "be92ca08-6b57-4eee-bc95-1b51015e8e2c",
                    UserId = "414dcdef-280d-45f8-a6c9-98d7ad09a2e4"
                }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
