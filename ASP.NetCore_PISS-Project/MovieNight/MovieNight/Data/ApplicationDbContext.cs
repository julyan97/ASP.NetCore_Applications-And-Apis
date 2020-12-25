using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieNight.Models;

namespace MovieNight.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserChatRooms>()
                .HasKey(bc => new { bc.UserId, bc.ChatRoomId });

            modelBuilder.Entity<UserChatRooms>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserChatRooms)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<UserChatRooms>()
                .HasOne(bc => bc.ChatRoom)
                .WithMany(c => c.UserChatRooms)
                .HasForeignKey(bc => bc.ChatRoomId);


        }
    }
}
