using InventoryService.Models;

namespace InventoryService.Database
{
    public static class ProductsDb
    {
        public static List<Product> GetProducts { get =>new List<Product>
        {
            new Product{ProductId=1,Quantity=100},
            new Product{ProductId=2,Quantity=50},
            new Product{ProductId=3,Quantity=300},
            new Product{ProductId=4,Quantity=10},
            new Product{ProductId=5,Quantity=900},
            new Product{ProductId=6,Quantity=50},
            new Product{ProductId=7,Quantity=800},
            new Product{ProductId=8,Quantity=30},
            new Product{ProductId=9,Quantity=0},
            new Product{ProductId=10,Quantity=90},
            new Product{ProductId=11,Quantity=25}
        }; }
    }
}
