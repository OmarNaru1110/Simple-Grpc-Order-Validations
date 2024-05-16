using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingService.GrpcServices;
using OrderingService.Models;
using OrderingService.Services;

namespace OrderingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderItemsValidations _orderValidations;
        private OrderPaymentValidations _orderPaymentValidations;
        public OrderController()
        {
            _orderValidations = new OrderItemsValidations();
            _orderPaymentValidations = new OrderPaymentValidations();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOrder(Order order)
        {
            var inventoryValidationResult = await _orderValidations.CheckValidItems(order.Items);
            if(inventoryValidationResult==false)
                return NotFound("one or more of your order items were not found!");

            var orderservices = new OrderServices();
            var paymentValidationResult = await _orderPaymentValidations.ValidatePayment(orderservices.GetPaymentDetails(order));
            if (paymentValidationResult == false)
                return NotFound("either u don't have account or ur balance isn't enough!");

            return Ok("Your Order Validations Has Been Completed Successfully!");
        }
    }
}
