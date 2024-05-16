using PaymentService.Models;

namespace PaymentService.Database
{
    public static class AccountsDb
    {
        public static List<Account> GetAccounts
        {
            get => new List<Account>
        {
            new Account{UserId=1,Balance=0m},
            new Account{UserId=2,Balance=68791m},
            new Account{UserId=3,Balance=164654.35m},
            new Account{UserId=4,Balance=15798},
            new Account{UserId=5,Balance=10m},
            new Account{UserId=7,Balance=3579m},
            new Account{UserId=8,Balance=5000m},
            new Account{UserId=9,Balance=3254m},
            new Account{UserId=10,Balance=2220m},
            new Account{UserId=11,Balance=450m},
        };
        }
    }
}
