namespace Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext()
            : base("name=RestaurantDbContext")
        {
        }

        public virtual DbSet<DesignCategory> DesignCategories { get; set; }
        public virtual DbSet<Design> Designs { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<FoodCategory> FoodCategories { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DesignCategory>()
                .HasMany(e => e.Designs)
                .WithRequired(e => e.DesignCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FoodCategory>()
                .HasMany(e => e.Foods)
                .WithRequired(e => e.FoodCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Food>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus)
                .WithRequired(e => e.Food)
                .HasForeignKey(e => e.FoodId1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus1)
                .WithRequired(e => e.Food1)
                .HasForeignKey(e => e.FoodId2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus2)
                .WithRequired(e => e.Food2)
                .HasForeignKey(e => e.FoodId3)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus3)
                .WithRequired(e => e.Food3)
                .HasForeignKey(e => e.FoodId4)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus4)
                .WithRequired(e => e.Food4)
                .HasForeignKey(e => e.FoodId5)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus5)
                .WithRequired(e => e.Food5)
                .HasForeignKey(e => e.FoodId6)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus6)
                .WithRequired(e => e.Food6)
                .HasForeignKey(e => e.FoodId7)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus7)
                .WithRequired(e => e.Food7)
                .HasForeignKey(e => e.FoodId8)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));
        }
    }
}
