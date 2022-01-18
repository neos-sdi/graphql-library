namespace Library.Infrastructure
{
    using Library.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
        {
        }
        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<Author> Authors { get; set; } = default!;
        public DbSet<Publisher> Publishers { get; set; } = default!;
        public DbSet<Language> Languages { get; set; } = default!;
        public DbSet<Serie> Series { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(e =>
            {
                e.ToTable("Book");  
                e.HasKey(b => b.Id);
                e.Property(b => b.Title).IsRequired().HasMaxLength(1024);
                e.HasMany(b => b.Authors).WithMany(a => a.WrittenBooks).UsingEntity<Dictionary<string, object>>(
                    "BookAuthor",
                    x=>x.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
                    x=>x.HasOne<Book>().WithMany().HasForeignKey("BookId")
                    ) ;
                e.HasOne(b=>b.Language).WithMany(l => l.Books);
                e.HasOne(b=>b.Publisher).WithMany(p => p.PublishedBooks);
                e.HasOne(b=>b.Serie).WithMany(s => s.SeriesBooks);
            });


            modelBuilder.Entity<Author>(e =>
            {
                e.ToTable("Author");
                e.HasKey(a => a.Id);
                e.Property(a => a.FirstName).HasMaxLength(255);
                e.Property(a => a.LastName).IsRequired().HasMaxLength(255);
                e.HasMany(a=>a.WrittenBooks).WithMany(b => b.Authors).UsingEntity<Dictionary<string, object>>(
                    "BookAuthor",
                    x => x.HasOne<Book>().WithMany().HasForeignKey("BookId"),
                    x => x.HasOne<Author>().WithMany().HasForeignKey("AuthorId")
                    );
            });


            modelBuilder.Entity<Language>(e => {
                e.ToTable("Language");
                e.HasKey(l => l.Id);
                e.Property(l =>l.Label).IsRequired().HasMaxLength(255);
                e.HasMany(l => l.Books).WithOne(b => b.Language);
            });

            modelBuilder.Entity<Publisher>(e =>
            {
                e.ToTable("Publisher");
                e.HasKey(p => p.Id);
                e.Property(p=>p.Name).IsRequired().HasMaxLength(255);
                e.HasMany(p => p.PublishedBooks).WithOne(b => b.Publisher);
            });

            modelBuilder.Entity<Serie>(e =>
            {
                e.ToTable("Serie");
                e.HasKey(s => s.Id);
                e.Property(s=>s.Name).IsRequired().HasMaxLength(255);
                e.HasMany(s=>s.SeriesBooks).WithOne(b => b.Serie);
            });
        }
    }
}
