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

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
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
                .WithOptional(e => e.Food)
                .HasForeignKey(e => e.FoodId2);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus1)
                .WithOptional(e => e.Food1)
                .HasForeignKey(e => e.FoodId3);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus2)
                .WithOptional(e => e.Food2)
                .HasForeignKey(e => e.FoodId4);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus3)
                .WithOptional(e => e.Food3)
                .HasForeignKey(e => e.FoodId5);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus4)
                .WithOptional(e => e.Food4)
                .HasForeignKey(e => e.FoodId6);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus5)
                .WithOptional(e => e.Food5)
                .HasForeignKey(e => e.FoodId7);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus6)
                .WithOptional(e => e.Food6)
                .HasForeignKey(e => e.FoodId8);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Menus7)
                .WithOptional(e => e.Food7)
                .HasForeignKey(e => e.FoodId1);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));
        }
    }
}
