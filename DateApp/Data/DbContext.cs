﻿
namespace App.Db
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserLike> UserLikes { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<UserProfile>().HasKey(k => k.Id);
            builder.Entity<UserLike>().HasKey(K => K.Id);
            builder.Entity<UserMessage>().HasKey(k => k.Id);

            builder.Entity<UserLike>()
                .HasOne(userBy => userBy.ByUser)
                .WithMany(userTo => userTo.SendedLikes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserLike>()
               .HasOne(userBy => userBy.ToUser)
               .WithMany(userTo => userTo.ReceivedLikes)
               .OnDelete(DeleteBehavior.Restrict);

            //one user  send many messages to another user 
            builder.Entity<UserMessage>()
                .HasOne(userBy => userBy.ByUser)
                .WithMany(userTo => userTo.SendedMessages)
                .OnDelete(DeleteBehavior.Restrict);

            //one user received many messages from another user
            builder.Entity<UserMessage>()
                .HasOne(userBy => userBy.ToUser)
                .WithMany(userTo => userTo.ReceivedMessages)
                .OnDelete(DeleteBehavior.Restrict);
            

        }



    }
}

