using MakeAccount.Models;
using MakeAccount.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MakeAccount.Services
{
    public class AccountBookService : Repository<AccountBook>
    {
        public AccountBookService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<AccountBookViewModels> ListAll()
        {
            return this.LookupAll().Select(m => new AccountBookViewModels
            {
                Id = m.Id,
                AccountType = m.Categoryyy == 0 ? EnumAccountType.Expense : EnumAccountType.Revenue,
                KeepDate = m.Dateee,
                Amount = m.Amounttt,
                Memo = m.Remarkkk
            });
        }

        public void Add(AccountBookViewModels accountBook)
        {
            this.Create(new AccountBook
            {
                Id = accountBook.Id,
                Categoryyy = accountBook.AccountType == EnumAccountType.Expense ? 0 : 1,
                Dateee = accountBook.KeepDate,
                Amounttt = decimal.ToInt32(accountBook.Amount),
                Remarkkk = accountBook.Memo
            });
        }
    }
}
