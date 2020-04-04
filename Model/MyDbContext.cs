using System;
using Microsoft.EntityFrameworkCore;
using Common.Util;
namespace Model
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>().HasData(
            //    new User {Id=1, Username = "admin", Pswd = Security.Md5("123456") });
            //    modelBuilder
            //.Entity<Goods>()
            //.Property(e => e.Photos)
            //.HasConversion(
            //    v => string.Join("|", v), 
            //    v => v.Split(new char[] { '|' })
            //    );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //开启EF Core的延迟加载功能  使用延迟加载的最简单方式是安装 Microsoft.EntityFrameworkCore.Proxies 包，并通过调用 UseLazyLoadingProxies 来启用。
            optionsBuilder.UseLazyLoadingProxies();
        }
     
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<Classs> Classss { get; set; }
        public virtual DbSet<Company> Companys { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Interview> Interviews { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<OnlineResume> OnlineResumes { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsualScore> UsualScores { get; set; }
        public virtual DbSet<UsualScoreHistory> UsualScoreHistorys { get; set; }
        public virtual DbSet<UsualScoreItem> UsualScoreItems { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<CourseRes> Courseress { get; set; }
    }
}
