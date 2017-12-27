using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commentifier.Models
{
    public class CommentifierContext : DbContext
    {
        public CommentifierContext(DbContextOptions<CommentifierContext> options)
            : base(options) { }
        public CommentifierContext() { }
        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invitation>().ToTable("Invitations");
        }
    }
}
