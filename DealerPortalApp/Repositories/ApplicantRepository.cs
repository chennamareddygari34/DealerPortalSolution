using DealerPortalApp.Data;
using DealerPortalApp.Interfaces;
using DealerPortalApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DealerPortalApp.Repositories
{
    public class ApplicantRepository : IRepository<int, Applicant>
    {
        private readonly DealerPortalContext _context;
        public ApplicantRepository(DealerPortalContext context) 
        {
            _context = context;
        }

        public Applicant Add(Applicant item)
        {
            _context.Applicants.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Applicant Delete(int key)
        {
            var Applicant = Get(key);
            if (Applicant != null)
            {
                _context.Applicants.Remove(Applicant);
                _context.SaveChanges();
                return Applicant;
            }
            return null;
        }

        public Applicant Get(int key)
        {
            var Applicants = _context.Applicants.FirstOrDefault(app => app.ApplicantId == key);
            return Applicants;
        }

        public List<Applicant> GetAll()
        {
            return _context.Applicants.ToList();
        }

        public Applicant Update(Applicant item)
        {
            _context.Entry<Applicant>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
