using MakeAccount.Models;
using MakeAccount.Repositories;
using MakeAccount.Services;
using System.Web.Mvc;

namespace MakeAccount.Controllers
{
    public class AccountEntryController : Controller
    {
        private readonly AccountBookService _accountBookSvc = new AccountBookService(new EFUnitOfWork());

        // GET: AccountEntry
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var accountEntries = _accountBookSvc.ListAll();
            return View(accountEntries);
        }

        [HttpPost]
        public ActionResult Index(AccountBookViewModels newAccountEntry)
        {
            _accountBookSvc.Add(newAccountEntry);
            _accountBookSvc.Commit();
            return RedirectToAction("Index");
        }
    }
}