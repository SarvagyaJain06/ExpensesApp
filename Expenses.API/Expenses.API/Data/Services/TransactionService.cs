using Expenses.API.Dtos;
using Expenses.API.Models;

namespace Expenses.API.Data.Services
{
    public interface ITransactionService
    {
        List<Transaction> GetAll();
        Transaction? GetById(int id);
        Transaction Add(PostTransactionDto transaction);
        Transaction? Update(int id, PutTransactionDto transaction);
        void Delete(int id);
    }
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;
        public TransactionService(AppDbContext context)
        {
            _context = context;
        }
        public Transaction Add(PostTransactionDto transaction)
        {
            var newTransaction = new Transaction()
            {
                Amount = transaction.Amount,
                Type = transaction.Type,
                Category = transaction.Category,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            _context.Transactions.Add(newTransaction);
            _context.SaveChanges();
            return newTransaction;
        }

        public void Delete(int id)
        {
            var transaction = _context.Transactions.FirstOrDefault(x => x.Id == id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                _context.SaveChanges();
            }
        }

        public List<Transaction> GetAll()
        {
            var allTransactions = _context.Transactions.ToList();
            return allTransactions;
        }

        public Transaction? GetById(int id)
        {
            var transaction = _context.Transactions.FirstOrDefault(x => x.Id == id);
            return transaction;
        }

        public Transaction? Update(int id, PutTransactionDto transaction)
        {
            var transactionDb = _context.Transactions.FirstOrDefault(x => x.Id == id);
            if (transactionDb != null)
            {
                transactionDb.Type = transaction.Type;
                transactionDb.Amount = transaction.Amount;
                transactionDb.Category = transaction.Category;
                transactionDb.UpdatedAt = DateTime.UtcNow;
                _context.Transactions.Update(transactionDb);
                _context.SaveChanges();
            }
            return transactionDb;
        }
    }
}
