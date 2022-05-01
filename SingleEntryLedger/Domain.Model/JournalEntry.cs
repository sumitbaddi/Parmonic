using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleEntryLedger.Domain.Model
{
    /// <summary>
    /// The Entity/Aggregate root
    /// </summary>
    public class JournalEntry
    {
        public List<JournalEntryItem> Items { get; set; }

        public static decimal Balance { get; set; }

        public JournalEntry(JournalEntryItem item, decimal balance)
        {
            Items = new List<JournalEntryItem>();
            Balance = balance;

            if(item.TransactionType== TransactionType.Credit)
            {
                Items.Add(item);
                Balance = Decimal.Add(Balance, item.Amount);
            }
            else if(item.TransactionType== TransactionType.Debit)
            {
                if (JournalEntry.isDebitPermitted(item))
                {
                    Items.Add(item);
                    Balance = Decimal.Subtract(Balance, item.Amount);
                }
                else
                {
                    throw new ArgumentException("Debit amount is higher than balance amount", "Debit Amount");
                }
            }
           
            
        }
        
        /// <summary>
        /// Validation for allowing debit entry
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool isDebitPermitted(JournalEntryItem item)
        {
            bool isDebitPermitted = false;
            if(item.TransactionType == TransactionType.Debit && Balance>0 && Balance>=item.Amount)
            {
                isDebitPermitted = true;
            }
            return isDebitPermitted;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JournalEntryItem
    {
        public Guid Id { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public string? Description { get; set; }
        public Decimal Amount { get; set; }
    }
}
