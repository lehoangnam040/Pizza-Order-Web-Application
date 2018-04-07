namespace PizzaOrderWebApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PizzaExpressModel : DbContext
    {
        public PizzaExpressModel()
            : base("name=PizzaExpressModel")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.User)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Foods)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Dish>()
                .Property(e => e.FoodID)
                .IsUnicode(false);

            modelBuilder.Entity<Dish>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Dish)
                .HasForeignKey(e => new { e.FoodID, e.Size })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Food>()
                .Property(e => e.FoodID)
                .IsUnicode(false);

            modelBuilder.Entity<Food>()
                .Property(e => e.ImageString)
                .IsUnicode(false);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.Dishes)
                .WithRequired(e => e.Food)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.FoodID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);
        }
    }
}
