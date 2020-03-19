using Microsoft.EntityFrameworkCore;
using Web.API.Repository;

namespace Web.API.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<Output> Outputs { get; set; }
        //public DbSet<InputInfo> InputsInfo { get; set; }
        //public DbSet<OutputInfo> OutputsInfo { get; set; }
        //public DbSet<User> Users { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Inventory>().ToTable("Inventories");
            builder.Entity<Inventory>().HasKey(p => p.Makho);
            builder.Entity<Inventory>().Property(p => p.Makho).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Inventory>().Property(p => p.Tenkho).IsRequired().HasMaxLength(30);
            builder.Entity<Inventory>().HasMany(p => p.Stocks).WithOne(p => p.Inventory).HasForeignKey(p => p.InventoryId);
            //builder.Entity<Inventory>().HasMany(p => p.Inputs).WithOne(p => p.Inventory).HasForeignKey(p => p.InvenId);
            //builder.Entity<Inventory>().HasMany(p => p.Outputs).WithOne(p => p.Inventory).HasForeignKey(p => p.InvenId);

            //builder.Entity<Inventory>().HasData
            //(
            //    new Inventory { Id = 100, Name = "Loa" }, // Id set manually due to in-memory provider
            //    new Inventory { Id = 101, Name = "Tủ lạnh" }
            //);



            builder.Entity<Stock>().ToTable("Stocks");
            builder.Entity<Stock>().HasKey(p => p.Mavt);
            builder.Entity<Stock>().Property(p => p.Mavt).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Stock>().Property(p => p.Tenvt).IsRequired().HasMaxLength(50);
            builder.Entity<Stock>().Property(p => p.Soluong).IsRequired().HasMaxLength(30);
            builder.Entity<Stock>().Property(p => p.Noisx).IsRequired().HasMaxLength(30);
            builder.Entity<Stock>().HasMany(p => p.Inputs).WithOne(p => p.Stocks).HasForeignKey(p => p.StockId);
            builder.Entity<Stock>().HasMany(p => p.Outputs).WithOne(p => p.Stocks).HasForeignKey(p => p.IdStock);




            builder.Entity<Unit>().ToTable("Units");
            builder.Entity<Unit>().HasKey(p => p.Madv);
            builder.Entity<Unit>().Property(p => p.Madv).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Unit>().Property(p => p.Tendv).IsRequired().HasMaxLength(30);
            builder.Entity<Unit>().Property(p => p.Description).IsRequired().HasMaxLength(30);
            builder.Entity<Unit>().HasMany(p => p.Stocks).WithOne(p => p.Unit).HasForeignKey(p => p.UnitId);


            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<Customer>().HasKey(p => p.Makh);
            builder.Entity<Customer>().Property(p => p.Makh).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Customer>().Property(p => p.Tenkh).IsRequired().HasMaxLength(30);
            builder.Entity<Customer>().Property(p => p.Diachi).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(p => p.Sdt).IsRequired().HasMaxLength(30);
            builder.Entity<Customer>().HasMany(p => p.Output).WithOne(p => p.Customer).HasForeignKey(p => p.CustomerId);

            builder.Entity<Supplier>().ToTable("Suppliers");
            builder.Entity<Supplier>().HasKey(p => p.Mancc);
            builder.Entity<Supplier>().Property(p => p.Mancc).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Supplier>().Property(p => p.Tenncc).IsRequired().HasMaxLength(30);
            builder.Entity<Supplier>().HasMany(p => p.Stocks).WithOne(p => p.Supplier).HasForeignKey(p => p.SupplierId);
            //builder.Entity<Supplier>().HasMany(p => p.Inputs).WithOne(p => p.Supplier).HasForeignKey(p => p.SupplierId);



            builder.Entity<Input>().ToTable("Input");
            builder.Entity<Input>().HasKey(p => p.Mapn);
            builder.Entity<Input>().Property(p => p.Mapn).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Input>().Property(p => p.Tenpn).IsRequired().HasMaxLength(30);
            builder.Entity<Input>().Property(p => p.Ngaynhap).IsRequired().HasMaxLength(30);
            builder.Entity<Input>().Property(p => p.Dongianhap).IsRequired().HasMaxLength(30);
            builder.Entity<Input>().Property(p => p.Soluongnhap).IsRequired().HasMaxLength(30);
            



            builder.Entity<Output>().ToTable("Output");
            builder.Entity<Output>().HasKey(p => p.Mapx);
            builder.Entity<Output>().Property(p => p.Mapx).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Output>().Property(p => p.Tenpx).IsRequired().HasMaxLength(30);
            builder.Entity<Output>().Property(p => p.Ngayxuat).IsRequired().HasMaxLength(30);
            builder.Entity<Output>().Property(p => p.Soluongxuat).IsRequired().HasMaxLength(30);
            builder.Entity<Output>().Property(p => p.Dongiaxuat).IsRequired().HasMaxLength(30);
            builder.Entity<Output>().Property(p => p.Tinhtrangxuat).IsRequired().HasMaxLength(30);
            builder.Entity<Output>().Property(p => p.Thanhtien).IsRequired().HasMaxLength(30);


            //builder.Entity<InputInfo>().ToTable("InputInfo");
            //builder.Entity<InputInfo>().HasKey(p => p.Mapninfo);
            //builder.Entity<InputInfo>().Property(p => p.Mapninfo).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<InputInfo>().Property(p => p.Soluong).IsRequired().HasMaxLength(30);
            //builder.Entity<InputInfo>().Property(p => p.Giavao).IsRequired().HasMaxLength(30);
            //builder.Entity<InputInfo>().Property(p => p.Giaban).IsRequired().HasMaxLength(30);

            //builder.Entity<OutputInfo>().ToTable("OutputInfo");
            //builder.Entity<OutputInfo>().HasKey(p => p.Mapxinfo);
            //builder.Entity<OutputInfo>().Property(p => p.Mapxinfo).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<OutputInfo>().Property(p => p.Soluong).IsRequired().HasMaxLength(30);
            //builder.Entity<OutputInfo>().Property(p => p.Trangthai).IsRequired().HasMaxLength(30);

         












        }
    }
}
