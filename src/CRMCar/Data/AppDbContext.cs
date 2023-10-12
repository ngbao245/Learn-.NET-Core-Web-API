using CRMCar.Entity;
using Microsoft.EntityFrameworkCore;

namespace CRMCar.Data
{
    public class AppDbContext : DbContext
    {
        IConfiguration _configuration;
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectString = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.Development.json")
                    .Build();
            optionsBuilder.UseSqlServer(connectString.GetConnectionString("DefaultConnectStrings"));
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity("CRMCar.Car", b =>
        //    {
        //        b.Property<int>("Id")
        //            .ValueGeneratedOnAdd()
        //            .HasColumnType("int");

        //        SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

        //        b.Property<string>("Brand")
        //            .IsRequired()
        //            .HasColumnType("nvarchar(max)");

        //        b.Property<string>("Email")
        //            .IsRequired()
        //            .HasColumnType("nvarchar(max)");

        //        b.Property<DateTime?>("ExpireDate")
        //            .HasColumnType("datetime2")
        //            .HasColumnName("date");

        //        b.Property<bool?>("IsActive")
        //            .HasColumnType("bit");

        //        b.Property<string>("Name")
        //            .IsRequired()
        //            .HasColumnType("nvarchar(50)");

        //        b.Property<decimal?>("Price")
        //            .HasColumnType("decimal(18,2)")
        //            .HasColumnName("decimal(18,7)");

        //        b.Property<int>("UserId")
        //            .HasColumnType("int");

        //        b.HasKey("Id");

        //        b.HasIndex("UserId");

        //        b.ToTable("Car");
        //    });

        //    modelBuilder.Entity("CRMCar.Car", b =>
        //    {
        //        b.HasOne("CRMCar.User", "User")
        //            .WithMany()
        //            .HasForeignKey("UserId")
        //            .OnDelete(DeleteBehavior.Cascade)
        //            .IsRequired();

        //        b.Navigation("User");
        //    });

        //    modelBuilder.Entity("CRMCar.User", b =>
        //    {
        //        b.Property<int>("Id")
        //            .ValueGeneratedOnAdd()
        //            .HasColumnType("int");

        //        SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

        //        b.Property<bool?>("IsActive")
        //            .HasColumnType("bit");

        //        b.Property<string>("Name")
        //            .IsRequired()
        //            .HasColumnType("nvarchar(max)");

        //        b.HasKey("Id");

        //        b.ToTable("User");
        //    });
        //}
    }
}
