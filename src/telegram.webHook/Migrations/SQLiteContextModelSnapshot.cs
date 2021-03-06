using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using telegram.webHook.Models.Context;

namespace telegram.webHook.Migrations
{
    [DbContext(typeof(SQLiteContext))]
    partial class SQLiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("telegram.webHook.Models.Entities.Dictionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<string>("Pattern");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Dictionary");
                });

            modelBuilder.Entity("telegram.webHook.Models.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChatId");

                    b.Property<string>("FromFirstname");

                    b.Property<int>("FromId");

                    b.Property<string>("FromLastname");

                    b.Property<string>("FromUsername")
                        .IsRequired();

                    b.Property<string>("LocationLatitude");

                    b.Property<string>("LocationLongitude");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Message");
                });
        }
    }
}
