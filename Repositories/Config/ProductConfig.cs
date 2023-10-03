using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product() { ProductId = 1, ProductName = "Yeryüzünde Bir An İçin Muhteşemiz", Price = 110,ImageUrl="/images/2.jpeg", CategoryId = 1,ShowCase=false },
                new Product() { ProductId = 2, ProductName = "Computer", Price = 40000,ImageUrl="/images/3.jpeg", CategoryId = 2,ShowCase=true},
                new Product() { ProductId = 3, ProductName = "Kindle", Price = 3000,ImageUrl="/images/1.jpeg", CategoryId = 2,ShowCase=false}
            );
        }
    }

}