using OrderingService.Models;
using OrderingService.Protos;

namespace OrderingService.Services
{
    public class OrderServices
    {
        public OrderServices() { }

        public PaymentDetails GetPaymentDetails(Order order)
        {
            int userId = order.UserId;
            decimal totalPrice = 0;
            foreach (var item in order.Items)
            {
                totalPrice += item.Price;
            }
            return new PaymentDetails {UserId = userId, TotalPrice = totalPrice};
        }
    }
}
