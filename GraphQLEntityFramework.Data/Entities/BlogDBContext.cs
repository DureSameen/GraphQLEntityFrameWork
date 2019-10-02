using Microsoft.EntityFrameworkCore;

namespace GraphQLEntityFramework.Data.Entities
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options)
              : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Blog
            modelBuilder.Entity<Blog>().HasData(new Blog() { BlogId = 1 , Title =" A beautiful day start", Content ="Today is the my day in the office", Type= BlogType.Story});
            modelBuilder.Entity<Blog>().HasData(new Blog() { BlogId  = 2 , Title ="Expo center visit", Content ="My visit to expo center was so good", Type = BlogType.Event });
            modelBuilder.Entity<Blog>().HasData(new Blog() { BlogId = 3 , Title = "Developer Conference 2019", Content = "It was so good and helpful in learning many new things", Type = BlogType.Event });

            //Reviews
            modelBuilder.Entity<Review>().HasData(new Review() { ReviewId = 1, BlogId = 2, Remarks = "I was there too, it was a really nice event" });
            modelBuilder.Entity<Review>().HasData(new Review() { ReviewId = 2, BlogId = 2, Remarks = "I missed it, better luck next time" });
            modelBuilder.Entity<Review>().HasData(new Review() { ReviewId = 3, BlogId = 3, Remarks = "Anyone can help me with schedule on next conference" });


            base.OnModelCreating(modelBuilder);
        }
    }
}
