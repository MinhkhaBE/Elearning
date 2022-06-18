using Microsoft.EntityFrameworkCore;

namespace E_Learning.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classdetail> Classdetails { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Scorelearning> Scorelearnings { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(e =>
            {
                e.ToTable("Admin");
                e.HasKey(ad => ad.Idadmin);
                e.Property(ad => ad.Nameadmin)
                 .IsRequired();
                e.Property(ad => ad.Phone)
                 .HasMaxLength(10);

                e.HasOne(ad => ad.Account)
                .WithOne(ad => ad.Admin)
                .HasForeignKey<Admin>(ad => ad.Idaccount)
                .HasConstraintName("fk_admin_account");
            });

            modelBuilder.Entity<Account>(e =>
            {
                e.ToTable("Account");
                e.HasKey(ac => ac.Idaccount);
                e.Property(ac => ac.User)
                 .IsRequired()
                 .HasMaxLength(15);
                e.Property(ac => ac.Password)
                 .IsRequired()
                 .HasMaxLength(15);
                e.Property(ac => ac.Gmail)
                 .IsRequired();
                e.Property(ac => ac.Phone)
                 .IsRequired()
                 .HasMaxLength(10);
                e.Property(ac => ac.Createdate)
                 .HasDefaultValueSql("getutcdate()");

            });

            modelBuilder.Entity<Class>(e =>
            {
                e.ToTable("Class");
                e.HasKey(cl => cl.Idclass);
                e.Property(cl => cl.Nameclass)
                 .IsRequired();
                e.Property(cl => cl.Semester)
                .IsRequired();

                

                e.HasOne(su => su.Subject)
                .WithMany(cl => cl.Classes)
                .HasForeignKey(cl => cl.Idsubject)
                .HasConstraintName("FK_Class_Subject");

            });

            modelBuilder.Entity<Student>(e =>
            {

                e.ToTable("Student");
                e.HasKey(st => st.Idstudent);
                e.Property(st => st.Namestudent)
                 .IsRequired()
                 .HasMaxLength(15);
                e.Property(st => st.Gmail)
                 .IsRequired();
                e.Property(st => st.Phone)
                 .IsRequired()
                 .HasMaxLength(10);

                e.HasOne(ad => ad.Account)
                .WithOne(st => st.Student)
                .HasForeignKey<Student>(ad => ad.Idaccount)
                .HasConstraintName("FK_Student_account");



            });

            modelBuilder.Entity<Teacher>(e =>
            {
                e.ToTable("Teacher");
                e.HasKey(te => te.Idteacher);
                e.Property(te => te.Nameteacher)
                 .IsRequired();
                e.Property(te => te.Gmail)
                .IsRequired();
                e.Property(te => te.Phone)
                 .IsRequired()
                 .HasMaxLength(10);

                e.HasOne(ac => ac.Account)
                .WithOne(te => te.Teacher)
                .HasForeignKey<Teacher>(te => te.Idaccount)
                .HasConstraintName("FK_Teacher_Account");

            });

            modelBuilder.Entity<Classdetail>(e =>
            {
                e.ToTable("ClassDetail");
                e.HasKey(cd => cd.Idclassdetail);
                e.Property(cd => cd.Passwordclass)
                 .IsRequired()
                 .HasMaxLength(10);
                e.Property(cd => cd.Teacher)
                .IsRequired();
                e.Property(cd => cd.Lesson)
                .IsRequired();

                e.HasOne(cl => cl.Class)
                .WithOne(cd => cd.Classdetail)
                .HasForeignKey<Classdetail>(cl => cl.Idclass)
                .HasConstraintName("FK_Class_Classdetail");
            });

            modelBuilder.Entity<Subject>(e =>
            {
                e.ToTable("Subject");
                e.HasKey(cd => cd.Idsubject);
                e.Property(cd => cd.Namesubject)
                 .IsRequired();
            });

            modelBuilder.Entity<Test>(e =>
            {
                e.ToTable("Test");
                e.HasKey(te => te.Idtest);
                e.Property(te => te.Nametest)
                .IsRequired();
                e.Property(te => te.Createdate)
                 .HasDefaultValueSql("getutcdate()");

                e.HasOne(su => su.Subject)
               .WithMany(cl => cl.Tests)
               .HasForeignKey(cl => cl.Idsubject)
               .HasConstraintName("FK_Test_Subject");

            });

            modelBuilder.Entity<Scorelearning>(e =>
            {
                e.ToTable("Scorelearning");
                e.HasKey(sc => sc.Idscore);
                e.Property(sc => sc.Updatedate)
                 .HasDefaultValueSql("getutcdate()");

                e.HasOne(st => st.Student)
                .WithOne(sc => sc.Scorelearning)
                .HasForeignKey<Scorelearning>(sc => sc.Idstudent)
                .HasConstraintName("FK_Score_Student");

                e.HasOne<Subject>(su => su.Subject)
              .WithMany(cs => cs.Scorelearnings)
              .HasForeignKey(cl => cl.Idsubject)
              .HasConstraintName("FK_Score_Subject");

            });
        }
    }
}
