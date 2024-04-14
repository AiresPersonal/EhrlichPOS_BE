﻿// <auto-generated />
using System;
using EhrlichPOS_BE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EhrlichPOS_BE.Migrations
{
    [DbContext(typeof(EhrlichPosContext))]
    partial class EhrlichPosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EhrlichPOS_BE.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.HasKey("OrderId")
                        .HasName("PK_staging_order");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("EhrlichPOS_BE.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailsId")
                        .HasColumnType("int")
                        .HasColumnName("order_details_id");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<string>("PizzaId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("pizza_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("OrderDetailsId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("order_details", (string)null);
                });

            modelBuilder.Entity("EhrlichPOS_BE.Models.Pizza", b =>
                {
                    b.Property<string>("PizzaId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("pizza_id");

                    b.Property<string>("PizzaTypeId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("pizza_type_id");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("size");

                    b.HasKey("PizzaId");

                    b.HasIndex("PizzaTypeId");

                    b.ToTable("pizzas", (string)null);
                });

            modelBuilder.Entity("EhrlichPOS_BE.Models.PizzaType", b =>
                {
                    b.Property<string>("PizzaTypeId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("pizza_type_id");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("category");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ingredients");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("PizzaTypeId");

                    b.ToTable("pizza_types", (string)null);
                });

            modelBuilder.Entity("EhrlichPOS_BE.Models.OrderDetail", b =>
                {
                    b.HasOne("EhrlichPOS_BE.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_order_details_orders");

                    b.HasOne("EhrlichPOS_BE.Models.Pizza", "Pizza")
                        .WithMany("OrderDetails")
                        .HasForeignKey("PizzaId")
                        .IsRequired()
                        .HasConstraintName("FK_order_details_pizzas");

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("EhrlichPOS_BE.Models.Pizza", b =>
                {
                    b.HasOne("EhrlichPOS_BE.Models.PizzaType", "PizzaType")
                        .WithMany("Pizzas")
                        .HasForeignKey("PizzaTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_pizzas_pizza_types");

                    b.Navigation("PizzaType");
                });

            modelBuilder.Entity("EhrlichPOS_BE.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("EhrlichPOS_BE.Models.Pizza", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("EhrlichPOS_BE.Models.PizzaType", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
