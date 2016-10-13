using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Restoran
{
    public class RestoranContext : DbContext
    {       
        public DbSet<Product> Product { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductOrdered> ProductOrdered { get; set; }
        public DbSet<ProductRecipe> ProductRecipe { get; set; }
        public DbSet<ProductSupplier> ProviderProduct { get; set; }
        public DbSet<ProductStorage> ProductStorage { get; set; }      
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Recipe> Recipe { get; set; }             
        public DbSet<Order> Order { get; set; }
        public DbSet<Market> Market { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Market>().HasKey(m => m.MarketId);
         /*   modelBuilder.Entity<Market>().Property(m => m.Name).IsRequired();

           modelBuilder.Entity<Location>().HasKey(l => l.ID);
            modelBuilder.Entity<Location>().Property(l => l.Name); */
            modelBuilder.Entity<Location>().HasRequired(l => l.Market).WithMany().HasForeignKey(l => l.MarketId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>().HasKey(s => s.SupplierId);
            modelBuilder.Entity<Supplier>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<Supplier>().HasMany(s => s.Products).WithRequired(p => p.Supplier).WillCascadeOnDelete(true);
            modelBuilder.Entity<Supplier>().HasMany(s => s.Markets).WithMany(m => m.Suppliers);


            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Product>().HasRequired(p => p.Unit).WithMany(u => u.Products).WillCascadeOnDelete(false);
            modelBuilder.Entity<Product>().HasRequired(p => p.ProductCategory).WithMany(c => c.Products).WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>().HasKey(p => p.ProductCategoryId);
            modelBuilder.Entity<ProductCategory>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<Unit>().HasKey(m => m.UnitId);
            modelBuilder.Entity<Unit>().Property(m =>  m.Name).IsRequired();
            modelBuilder.Entity<Unit>().Property(m => m.Symbol).IsRequired();

            modelBuilder.Entity<ProductOrdered>().HasKey(p => p.ProductOrderedId);
            modelBuilder.Entity<ProductOrdered>().Property(p => p.Value).IsRequired();
            modelBuilder.Entity<ProductOrdered>().HasRequired(p => p.Product).WithMany(pr => pr.ProductOrdered).WillCascadeOnDelete(true);
            modelBuilder.Entity<ProductOrdered>().HasRequired(p => p.Order).WithMany(o => o.Products).WillCascadeOnDelete(true);

            modelBuilder.Entity<ProductSupplier>().HasKey(p => p.ProductSupplierId);
            modelBuilder.Entity<ProductSupplier>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<ProductSupplier>().HasRequired(p => p.Product).WithMany(pr => pr.ProductSupplier).WillCascadeOnDelete(true);
            modelBuilder.Entity<ProductSupplier>().HasRequired(p => p.Supplier).WithMany(s => s.Products).WillCascadeOnDelete(true);

            modelBuilder.Entity<ProductStorage>().HasKey(p => p.ProductStorageId);
            modelBuilder.Entity<ProductStorage>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<ProductStorage>().Property(p => p.Value).IsRequired();
            modelBuilder.Entity<ProductStorage>().HasRequired(p => p.Product).WithMany(pr => pr.ProductStorage).WillCascadeOnDelete(true);

            modelBuilder.Entity<ProductRecipe>().HasKey(p => p.ProductRecipeId);
            modelBuilder.Entity<ProductRecipe>().Property(p => p.Value).IsRequired();
            modelBuilder.Entity<ProductRecipe>().HasRequired(p => p.Product).WithMany().HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<ProductRecipe>().HasRequired(p => p.Recipe).WithMany(r => r.Products).HasForeignKey(p=>p.RecipeId).WillCascadeOnDelete(true);           

            modelBuilder.Entity<Order>().HasKey(o => o.OrderID);
            modelBuilder.Entity<Order>().Property(o => o.Accept).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.OrderDate).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.AcceptDate).IsOptional();
            modelBuilder.Entity<Order>().HasMany(o => o.Products).WithRequired(p => p.Order).WillCascadeOnDelete(true);
            modelBuilder.Entity<Order>().HasRequired(o => o.Supplier).WithMany(s => s.Orders).WillCascadeOnDelete(true);
            modelBuilder.Entity<Order>().HasRequired(o => o.Location).WithMany(l => l.Orders).WillCascadeOnDelete(true);

            modelBuilder.Entity<Recipe>().HasKey(r => r.RecipeId);
            modelBuilder.Entity<Recipe>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<Recipe>().HasMany(r => r.Products).WithRequired().HasForeignKey(p=>p.RecipeId).WillCascadeOnDelete(true);


        }
    }
}
