using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blegu_Larisa_lab2.Models;

namespace Blegu_Larisa_lab2.Data
{
    public class Blegu_Larisa_lab2Context : DbContext
    {
        public Blegu_Larisa_lab2Context (DbContextOptions<Blegu_Larisa_lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Blegu_Larisa_lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Blegu_Larisa_lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Blegu_Larisa_lab2.Models.Author>? Author { get; set; }

        public DbSet<Blegu_Larisa_lab2.Models.Category>? Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(e => e.Borrowing)
            .WithOne(e => e.Book)
                .HasForeignKey<Borrowing>("BookID");
        }

        public DbSet<Blegu_Larisa_lab2.Models.Member>? Member { get; set; }

        public DbSet<Blegu_Larisa_lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}
