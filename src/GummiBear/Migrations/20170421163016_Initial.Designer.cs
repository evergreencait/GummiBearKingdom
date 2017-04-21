using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GummiBear.Models;

namespace GummiBear.Migrations
{
    [DbContext(typeof(GummiBearDbContext))]
    [Migration("20170421163016_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GummiBear.Models.Bear", b =>
                {
                    b.Property<int>("BearId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cost");

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.HasKey("BearId");

                    b.ToTable("Bears");
                });
        }
    }
}
