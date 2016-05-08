using MakeAccount.Models;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Web.Mvc;

namespace MakeAccount.Controllers
{
    public class AccountEntryController : Controller
    {
        protected static readonly ConcurrentQueue<AccountEntryModels> fakeAccounts = new ConcurrentQueue<AccountEntryModels>(
            new[] {
                new AccountEntryModels {
                    Sn = 1,
                    AccountType = EnumAccountType.Expense,
                    Amount = 300m,
                    KeepDate = new DateTime(2016, 1, 1),
                    Memo = "電話費"
                },
                new AccountEntryModels {
                    Sn = 2,
                    AccountType = EnumAccountType.Expense,
                    Amount = 1600m,
                    KeepDate = new DateTime(2016, 1, 2),
                    Memo = "早餐"
                },
                new AccountEntryModels {
                     Sn = 3,
                     AccountType = EnumAccountType.Expense,
                     Amount = 800m,
                     KeepDate = new DateTime(2016, 1, 3),
                     Memo = "午餐"
                 }
             });

        // GET: AccountEntry
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var accountEntries = fakeAccounts;
            return View(accountEntries);
        }

        [HttpPost]
        public RedirectResult Add(AccountEntryModels newAccountEntry)
        {
            newAccountEntry.Sn = fakeAccounts.Max(x => x.Sn) + 1;
            fakeAccounts.Enqueue(newAccountEntry);
            return new RedirectResult("~/AccountEntry/Index");
        }
    }
}