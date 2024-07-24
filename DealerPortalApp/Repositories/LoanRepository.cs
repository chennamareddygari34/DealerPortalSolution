using DealerPortalApp.Data;
using DealerPortalApp.Interfaces;
using DealerPortalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DealerPortalApp.Repositories
{
    public class LoanRepository : IRepository<int, Loan>
    {
        private readonly DealerPortalContext _context;
        public LoanRepository(DealerPortalContext context) 
        {
            _context = context;
        }

        public Loan Add(Loan item)
        {
            _context.Loans.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Loan Delete(int key)
        {
            var Loan = Get(key);
            if (Loan != null)
            {
                _context.Loans.Remove(Loan);
                _context.SaveChanges();
                return Loan;
            }
            return null;
        }

        public Loan Get(int key)
        {
            var Loans = _context.Loans.FirstOrDefault(loan => loan.LoanId == key);
            return Loans;
        }

        public List<Loan> GetAll()
        {
            return _context.Loans.ToList();
        }

        public Loan Update(Loan item)
        {
            _context.Entry<Loan>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
