namespace ML.WorkShop.DAL.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MemberDbContext : DbContext
    {
        public MemberDbContext()
            : base("name=MemberDbContext")
        {
        }

        public MemberDbContext(string contextString)
            : base(contextString)
        {
        }

        public virtual DbSet<CompanyConfing> CompanyConfing { get; set; }
        public virtual DbSet<Identity> Identity { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MemberActivity> MemberActivity { get; set; }
        public virtual DbSet<MemberLog> MemberLog { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyConfing>()
                .HasMany(e => e.Member)
                .WithRequired(e => e.CompanyConfing)
                .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Identity>()
                .HasOptional(e => e.Role)
                .WithRequired(e => e.Identity)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Member>()
                .HasOptional(e => e.Identity)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MemberActivity)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.Member_Id);
        }
    }
}
