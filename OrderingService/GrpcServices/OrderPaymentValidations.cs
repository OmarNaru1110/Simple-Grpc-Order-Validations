using Grpc.Net.Client;
using OrderingService.Models;
using OrderingService.Protos;
using static OrderingService.protos.ProductController;
using static OrderingService.Protos.PaymentController;

namespace OrderingService.GrpcServices
{
    public class OrderPaymentValidations: PaymentControllerClient
    {
        private PaymentControllerClient _client;
        private PaymentControllerClient Client
        {
            get
            {
                if (_client == null)
                {
                    var channel = GrpcChannel.ForAddress("https://localhost:7016");
                    _client = new PaymentControllerClient(channel);
                }
                return _client;
            }
        }
        public async Task<bool> ValidatePayment(PaymentDetails paymentDetails)
        {
            var result = await Client.CheckValidPaymentAsync(paymentDetails);
            return result.Success;
        }
    }
}
