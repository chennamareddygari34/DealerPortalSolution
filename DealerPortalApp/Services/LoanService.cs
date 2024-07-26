using DealerPortalApp.Interfaces;
using DealerPortalApp.Models;
using DealerPortalApp.Models.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace DealerPortalApp.Services
{
    public class LoanService : ILoanService
    {
        private readonly IRepository<int, Loan> _loanRepository;
        private readonly IRepository<int, Applicant> _applicantRepository;

        public LoanService(IRepository<int, Loan> loanRepository, IRepository<int, Applicant> applicantRepository)
        {
            _loanRepository = loanRepository;
            _applicantRepository = applicantRepository;
        }

        public LoanDTO AddLoan(LoanDTO loanDTO)
        {
            var loan = new Loan
            {
                ApplicantId = loanDTO.ApplicantId,
                LoanAmount = loanDTO.LoanAmount,
                ApplicationDate = loanDTO.ApplicationDate,
                Status = loanDTO.Status,
                LastUpdate = loanDTO.LastUpdate
            };

            _loanRepository.Add(loan);

            return new LoanDTO
            {
                LoanId = loan.LoanId,
                ApplicantId = loan.ApplicantId,
                LoanAmount = loan.LoanAmount,
                ApplicationDate = loan.ApplicationDate,
                Status = loan.Status,
                LastUpdate = loan.LastUpdate,
               // Applicant = GetApplicantDTO(loan.ApplicantId)
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
                ApplicantId = loan.ApplicantId,
                LoanAmount = loan.LoanAmount,
                ApplicationDate = loan.ApplicationDate,
                Status = loan.Status,
                LastUpdate = loan.LastUpdate,
              //  Applicant = GetApplicantDTO(loan.ApplicantId)
            };
        }

        public List<LoanDTO> GetAllLoans()
        {
            var loans = _loanRepository.GetAll()
                                       .Select(loan => new LoanDTO
                                       {
                                           LoanId = loan.LoanId,
                                           ApplicantId = loan.ApplicantId,
                                           LoanAmount = loan.LoanAmount,
                                           ApplicationDate = loan.ApplicationDate,
                                           Status = loan.Status,
                                           LastUpdate = loan.LastUpdate,
                                           Applicant = GetApplicantDTO(loan.ApplicantId)
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
                ApplicantId = loan.ApplicantId,
                LoanAmount = loan.LoanAmount,
                ApplicationDate = loan.ApplicationDate,
                Status = loan.Status,
                LastUpdate = loan.LastUpdate,
                Applicant = GetApplicantDTO(loan.ApplicantId)
            };
        }

        public LoanDTO UpdateLoan(LoanDTO loanDTO)
        {
            var loan = _loanRepository.Get(loanDTO.LoanId);

            if (loan == null)
            {
                return null;
            }

            loan.ApplicantId = loanDTO.ApplicantId;
            loan.LoanAmount = loanDTO.LoanAmount;
            loan.ApplicationDate = loanDTO.ApplicationDate;
            loan.Status = loanDTO.Status;
            loan.LastUpdate = loanDTO.LastUpdate;

            _loanRepository.Update(loan);

            return new LoanDTO
            {
                LoanId = loan.LoanId,
                ApplicantId = loan.ApplicantId,
                LoanAmount = loan.LoanAmount,
                ApplicationDate = loan.ApplicationDate,
                Status = loan.Status,
                LastUpdate = loan.LastUpdate,
              //  Applicant = GetApplicantDTO(loan.ApplicantId)
            };
        }

        private ApplicantDTO GetApplicantDTO(int applicantId)
        {
            var applicant = _applicantRepository.Get(applicantId);
            if (applicant == null) return null;

            return new ApplicantDTO
            {
                ApplicantId = applicant.ApplicantId,
                ApplicantName = applicant.ApplicantName,
                Email = applicant.Email,
                Phone = applicant.Phone
            };
        }
    }
}

