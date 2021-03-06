// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace criptomonedas.Migrations
{
    [DbContext(typeof(CriptomonedasContext))]
    partial class CriptomonedasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Criptomonedas.Models.Criptomoneda", b =>
                {
                    b.Property<string>("moneda")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("lastValor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("maxValor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("moneda");

                    b.ToTable("Criptomoneda");
                });
#pragma warning restore 612, 618
        }
    }
}
