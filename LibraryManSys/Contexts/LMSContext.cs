using LibraryManSys.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManSys.Contexts
{
    internal class LMSContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberLoans> MemberLoans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(b =>
            {
                b.Property(b => b.Title).HasMaxLength(50);
                b.Property(b => b.Price).HasColumnType("decimal(6,2)");
                b.ToTable(t => t.HasCheckConstraint("CK_Book_PublicationYear", "PublicationYear BETWEEN 1950 AND 2025"));
                b.ToTable(t => t.HasCheckConstraint("CK_Book_Copies", "AvailableCopies <= TotalCopies AND AvailableCopies >= 0 AND TotalCopies >= 0"));
            });

            modelBuilder.Entity<Category>().Property(b => b.Title).HasMaxLength(50);
            modelBuilder.Entity<Category>().Property(b => b.Description).HasMaxLength(100);

            modelBuilder.Entity<Author>().Property(b => b.FirstName).HasMaxLength(20);
            modelBuilder.Entity<Author>().Property(b => b.LastName).HasMaxLength(20);

            modelBuilder.Entity<Member>(m =>
            {
                m.Property(b => b.Name).HasMaxLength(50);
                m.Property(b => b.Email).HasMaxLength(100);
                m.Property(b => b.PhoneNumber).HasMaxLength(11);
                m.Property(b => b.Address).HasMaxLength(100);
                m.Property(b => b.MembershipDate).HasDefaultValueSql("SYSUTCDATETIME()");
                m.Property(m => m.Status).HasColumnType("varchar(20)")
                          .HasMaxLength(20)
                          .HasConversion<string>()
                          .HasDefaultValue(MemberStatus.Active);
            });

            modelBuilder.Entity<Loan>().Property(b => b.LoanDate).HasDefaultValueSql("SYSUTCDATETIME()");
            modelBuilder.Entity<Loan>().Property(l => l.Status).HasColumnType("varchar(20)")
                      .HasMaxLength(20)
                      .HasConversion<string>();

            modelBuilder.Entity<Fine>(f =>
            {
                f.Property(b => b.IssuedDate).HasDefaultValueSql("SYSUTCDATETIME()");
                f.Property(b => b.Amount).HasColumnType("decimal(6,2)");
                f.Property(l => l.Status).HasColumnType("varchar(20)")
                      .HasMaxLength(20)
                      .HasConversion<string>();
            });


            modelBuilder.Entity<MemberLoans>().HasKey(ml => new
                                                {
                                                    ml.LoanId,
                                                    ml.MemberId,
                                                    ml.BookId
                                                });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RAHMA\\SQLEXPRESS; Database=LMS; Trusted_Connection=True; TrustServerCertificate=True");
        }
    }
}
