using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using asp_assignment.Models.BagStore;

namespace asp_assignment.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20170501065522_InitialSchema")]
    partial class InitialSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("asp_assignment.Models.BagStore.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdated");

                    b.Property<DateTime>("PriceCalculated");

                    b.Property<decimal>("PricePerUnit");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<string>("UserId");

                    b.HasKey("CartItemId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("asp_assignment.Models.BagStore.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName");

                    b.Property<int?>("ParentCategoryId");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("asp_assignment.Models.BagStore.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CheckoutBegan");

                    b.Property<DateTime?>("OrderPlaced");

                    b.Property<int>("State");

                    b.Property<decimal>("Total");

                    b.Property<string>("UserId");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("asp_assignment.Models.BagStore.OrderLine", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<decimal>("PricePerUnit");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("asp_assignment.Models.BagStore.OrderShippingDetails", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<string>("Addressee")
                        .IsRequired();

                    b.Property<string>("CityOrTown")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("LineOne")
                        .IsRequired();

                    b.Property<string>("LineTwo");

                    b.Property<string>("StateOrProvince")
                        .IsRequired();

                    b.Property<string>("ZipOrPostalCode")
                        .IsRequired();

                    b.HasKey("OrderId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("OrderShippingDetails");
                });

            modelBuilder.Entity("asp_assignment.Models.BagStore.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<decimal>("CurrentPrice");

                    b.Property<string>("Description");

                    b.Property<string>("DisplayName")
                        .IsRequired();

                    b.Property<string>("ImageUrl");

                    b.Property<decimal>("MSRP");

                    b.Property<string>("SKU")
                        .IsRequired();

                    b.Property<int>("SupplierId");

                    b.HasKey("ProductId");

                    b.HasAlternateKey("SKU");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("asp_assignment.Models.BagStore.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("HomePhone");

                    b.Property<int>("MobilePhone");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("WorkPhone");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("asp_assignment.Models.BagStore.WebsiteAd", b =>
                {
                    b.Property<int>("WebsiteAdId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Details");

                    b.Property<DateTime?>("End");

                    b.Property<string>("ImageUrl");

                    b.Property<DateTime?>("Start");

                    b.Property<string>("TagLine");

                    b.Property<string>("Url");

                    b.HasKey("WebsiteAdId");

                    b.ToTable("WebsiteAds");
                });

            modelBuilder.Entity("asp_assignment.Models.BagStore.CartItem", b =>
                {
                    b.HasOne("asp_assignment.Models.BagStore.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("asp_assignment.Models.BagStore.Category", b =>
                {
                    b.HasOne("asp_assignment.Models.BagStore.Category", "ParentCategory")
                        .WithMany("Children")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("asp_assignment.Models.BagStore.OrderLine", b =>
                {
                    b.HasOne("asp_assignment.Models.BagStore.Order", "Order")
                        .WithMany("Lines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("asp_assignment.Models.BagStore.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("asp_assignment.Models.BagStore.OrderShippingDetails", b =>
                {
                    b.HasOne("asp_assignment.Models.BagStore.Order")
                        .WithOne("ShippingDetails")
                        .HasForeignKey("asp_assignment.Models.BagStore.OrderShippingDetails", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("asp_assignment.Models.BagStore.Product", b =>
                {
                    b.HasOne("asp_assignment.Models.BagStore.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("asp_assignment.Models.BagStore.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
