using DealerPortalApp.Interfaces;
using DealerPortalApp.Models;
using DealerPortalApp.Models.DTOs;

namespace DealerPortalApp.Services
{
    public class LoanService : ILoanService
    {
        private readonly IRepository<int, Loan> _loanRepository;
        public LoanService(IRepository<int, Loan> loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public LoanDTO AddLoan(LoanDTO loanDTO)
        {
            var loan = new Loan
            {
                LoanId = loanDTO.LoanId,
                VendorId = loanDTO.VendorId,
                ApplicantId = loanDTO.ApplicantId,
                LoanAmount =(Decimal) loanDTO.LoanAmount,
                ApplicationDate = (DateTime) loanDTO.ApplicationDate,
                Status = loanDTO.Status,
                LastUpdate = loanDTO.LastUpdate
            };
            _loanRepository.Add(loan);
            return new LoanDTO
            {
                LoanId = loan.LoanId,
                VendorId = loan.VendorId,
                ApplicantId = loan.ApplicantId,
                LoanAmount = loan.LoanAmount,
                ApplicationDate = loan.ApplicationDate,
                Status = loan.Status,
                LastUpdate = loan.LastUpdate,
                
            };
        }

        public LoanDTO DeleteLoanById(int loanId)
        {
            var loan = _loanRepository.Get(loanId);

            if (loan == null)
            {
                return null;
            }

            _loanRepository.Delete(loanId);
            return new LoanDTO
            {
                LoanId = loan.LoanId,
                VendorId = loan.VendorId,
                ApplicantId = loan.ApplicantId,
                LoanAmount = loan.LoanAmount,
                ApplicationDate = loan.ApplicationDate,
                Status = loan.Status,
                LastUpdate = loan.LastUpdate,
               
            };
        }

        public List<LoanDTO> GetAllLoans()
        {
            var loans = _loanRepository.GetAll()
                                       .Select(loan => new LoanDTO
                                       {
                                           LoanId = loan.LoanId,
                                           VendorId = loan.VendorId,
                                           ApplicantId = loan.ApplicantId,
                                           LoanAmount = loan.LoanAmount,
                                           ApplicationDate = loan.ApplicationDate,
                                           Status = loan.Status,
                                           LastUpdate = loan.LastUpdate,
                                          
                                       }).ToList();

            return loans;
        }

        public LoanDTO GetLoanById(int loanId)
        {
            var loan = _loanRepository.Get(loanId);

            if (loan == null)
            {
                return null;
            }

            return new LoanDTO
            {
                LoanId = loan.LoanId,
                VendorId = loan.VendorId,
                ApplicantId = loan.ApplicantId,
                LoanAmount = loan.LoanAmount,
                ApplicationDate = loan.ApplicationDate,
                Status = loan.Status,
                LastUpdate = loan.LastUpdate,
               
            };
        }

        public LoanDTO UpdateLoan(LoanDTO loanDTO)
        {
            var loan = _loanRepository.Get(loanDTO.LoanId);

            if (loan == null)
            {
                return null;
            }

            loan.VendorId = loanDTO.VendorId;
            loan.ApplicantId = loanDTO.ApplicantId;
            loan.LoanAmount = (decimal)loanDTO.LoanAmount;
            loan.ApplicationDate = (DateTime)loanDTO.ApplicationDate;
            loan.Status = loanDTO.Status;
            loan.LastUpdate = loanDTO.LastUpdate;

            _loanRepository.Update(loan);

            return new LoanDTO
            {
                LoanId = loan.LoanId,
                VendorId = loan.VendorId,
                ApplicantId = loan.ApplicantId,
                LoanAmount = loan.LoanAmount,
                ApplicationDate = loan.ApplicationDate,
                Status = loan.Status,
                LastUpdate = loan.LastUpdate,
                
            };
        }
    }
}
