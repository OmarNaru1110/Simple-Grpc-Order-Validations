using Grpc.Core;
using PaymentService.Database;
using PaymentService.Protos;
using static PaymentService.Protos.PaymentController;

namespace PaymentService.Services
{
    public class PaymentServices:PaymentControllerBase
    {
        public override Task<Protos.Status> CheckValidPayment(PaymentDetails request, ServerCallContext context)
        {
            var account = AccountsDb.GetAccounts.FirstOrDefault(a=>a.UserId== request.UserId);
            if (account == null)
                return Task.FromResult(new Protos.Status { Success = false});

            return Task.FromResult(new Protos.Status { Success = account.Balance >= request.TotalPrice });
        }
    }
}
