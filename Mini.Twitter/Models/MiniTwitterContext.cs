using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Mini.Twitter.Models
{
    public partial class MiniTwitterContext : DbContext
    {
        public MiniTwitterContext()
        {
        }

        public MiniTwitterContext(DbContextOptions<MiniTwitterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Follower> Followers { get; set; }
        public virtual DbSet<Following> Followings { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Retweet> Retweets { get; set; }
        public virtual DbSet<Twitt> Twitts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=mini-twitter.postgres.database.azure.com;Database=Mini-Twitter;Username=siumauricio@mini-twitter;Password=Mamitabella1;SslMode=Require");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_buffercache")
                .HasPostgresExtension("pg_stat_statements");

            modelBuilder.Entity<Follower>(entity =>
            {
                entity.HasKey(e => e.IdFollower)
                    .HasName("Followers_pkey");

                entity.Property(e => e.IdFollower)
                    .HasColumnName("id_follower")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 99999L, null, null);

                entity.Property(e => e.FromUser).HasColumnName("from_user");

                entity.Property(e => e.ToUser).HasColumnName("to_user");

                entity.HasOne(d => d.ToUserNavigation)
                    .WithMany(p => p.FollowersNavigation)
                    .HasForeignKey(d => d.ToUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Followers_to_user_fkey");
            });

            modelBuilder.Entity<Following>(entity =>
            {
                entity.HasKey(e => e.IdFollowing)
                    .HasName("Following_pkey");

                entity.ToTable("Following");

                entity.Property(e => e.IdFollowing)
                    .HasColumnName("id_following")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 99999L, null, null);

                entity.Property(e => e.FromUser).HasColumnName("from_user");

                entity.Property(e => e.ToUser).HasColumnName("to_user");

                entity.HasOne(d => d.FromUserNavigation)
                    .WithMany(p => p.Followings)
                    .HasForeignKey(d => d.FromUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Following_from_user_fkey");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(e => e.IdLike)
                    .HasName("Likes_pkey");

                entity.Property(e => e.IdLike)
                    .HasColumnName("id_like")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 99999L, null, null);

                entity.Property(e => e.IdTweetLike).HasColumnName("id_tweet_like");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdTweetLikeNavigation)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.IdTweetLike)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Likes_id_tweet_like_fkey");
            });

            modelBuilder.Entity<Retweet>(entity =>
            {
                entity.HasKey(e => e.IdRetweet)
                    .HasName("Retweets_pkey");

                entity.Property(e => e.IdRetweet)
                    .HasColumnName("id_retweet")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 99999L, null, null);

                entity.Property(e => e.IdTweetRetweet).HasColumnName("id_tweet_retweet");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdTweetRetweetNavigation)
                    .WithMany(p => p.Retweets)
                    .HasForeignKey(d => d.IdTweetRetweet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Retweets_id_tweet_retweet_fkey");
            });

            modelBuilder.Entity<Twitt>(entity =>
            {
                entity.HasKey(e => e.IdTweet)
                    .HasName("Twitts_pkey");

                entity.Property(e => e.IdTweet)
                    .HasColumnName("id_tweet")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 9999L, null, null);

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.twitt)
                    .IsRequired()
                    .HasMaxLength(280)
                    .HasColumnName("twitt");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Twitts)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Twitts_id_user_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("Users_pkey");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 999999L, null, null);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("email");

                entity.Property(e => e.Followers).HasColumnName("followers");

                entity.Property(e => e.Following).HasColumnName("following");

                entity.Property(e => e.JoinDate)
                    .HasColumnType("date")
                    .HasColumnName("join_date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
