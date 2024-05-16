using Grpc.Core;
using InventoryService.Database;
using InventoryService.Protos;
using static InventoryService.protos.ProductController;

namespace InventoryService.Services
{
    public class ProductServices: ProductControllerBase
    {
        public override Task<Protos.Status> CheckValidItems(Products request, ServerCallContext context)
        {
            foreach (var item in request.Products_)
            {
                if (ProductsDb.GetProducts.Any(x => x.ProductId == item.ProductId && x.Quantity >= item.Quantity) == false)
                    return Task.FromResult(new Protos.Status { Success = false });
            }
            return Task.FromResult(new Protos.Status { Success = true });
        }
    }
}
