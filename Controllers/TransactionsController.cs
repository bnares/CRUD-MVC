using BankTransactions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankTransactions.Controllers
{
    
    public class TransactionsController : Controller
    {
        private readonly TransactionsDbContext _context;
        public TransactionsController(TransactionsDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var test = await _context.Transactions.ToListAsync();
            return View(await _context.Transactions.ToListAsync());
        }

        public IActionResult AddOrEdit(int id=0)
        {
            if(id==0)
                return View(new Transactions());
            else
                return View(_context.Transactions.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(Transactions transactions)
        {
           if(ModelState.IsValid)
            {
                if(transactions.TransactionId == 0)
                {
                    transactions.Date = DateTime.Now;
                    _context.Add(transactions);
                }
                else
                {
                    _context.Update(transactions);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           return View(transactions);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
