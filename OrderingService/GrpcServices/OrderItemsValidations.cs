using Grpc.Core;
using Grpc.Net.Client;
using OrderingService.Models;
using OrderingService.Protos;
using static OrderingService.protos.ProductController;

namespace OrderingService.GrpcServices
{
    public class OrderItemsValidations : ProductControllerClient
    {
        private ProductControllerClient _client;
        private ProductControllerClient Client
        {
            get
            {
                if( _client == null)
                {
                    var channel = GrpcChannel.ForAddress("https://localhost:7258");
                    _client = new ProductControllerClient(channel);
                }
                return _client;
            }
        }

        public async Task<bool> CheckValidItems(ICollection<Item> items)
        {
            var products = new Products();
            foreach (var item in items)
            {
                products.Products_.Add(new ProductMsg
                {
                    ProductId=item.ItemId,
                    Quantity=item.Quantity
                });
            }

            var result = await Client.CheckValidItemsAsync(products);

            return result.Success?true:false;
        }
    }
}
