using System.Text.RegularExpressions;

namespace BankingSystem
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message){}
    }

    public class BankOperationException : Exception
    {
        public BankOperationException(string message, Exception ex): base(message, ex) {}
    }
    public class BankAccount
    {
        public string? AccountNumber{get; private set;}
        public decimal Balance{get; private set;}

        public BankAccount(string AccountNumber, decimal initialBalance)
        {
            if (string.IsNullOrWhiteSpace(AccountNumber))
                throw new ArgumentException("Account no. can't have space or null");
            
            if(initialBalance < 0)
                throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial balance cannot be negative.");

            this.AccountNumber = AccountNumber;
            this.Balance = initialBalance;
        }

        public void WithDraw(decimal amount)
        {
            try
            {
                if(amount <= 0)
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero");
                if(amount > Balance)
                    throw new InsufficientBalanceException("Amount can't be greater than zero");
                Balance -= amount;
                Console.WriteLine("Success");
            } 
            catch(InsufficientBalanceException ex)
            {
                LogException(ex);
                throw;
            }
            catch(Exception ex)
            {
                LogException(ex);
                throw new BankOperationException("Unexpected error occurred. Try again later", ex);
            }
        }

        private void LogException(Exception ex)
        {
            File.AppendAllText(
                "error.txt",
                DateTime.Now + " | " + AccountNumber + " | " + ex.GetType().Name + " | " + ex.Message + Environment.NewLine
            );
        }
    }
}

// ArgumentOutOfRangeException
// ArgumentException

// amt > balance
// |
// condition [ true ]
// |
// object Created
// |
// Constructor run [ msg stored inside Exception.Message ]
// |
// Matching catch inside withdraw
// |
// Main