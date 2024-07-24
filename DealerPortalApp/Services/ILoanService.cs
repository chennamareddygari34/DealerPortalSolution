using DealerPortalApp.Models.DTOs;

namespace DealerPortalApp.Services
{
    public interface ILoanService
    {
        public List<LoanDTO> GetAllLoans();
        public LoanDTO GetLoanById(int loanId);
        public LoanDTO AddLoan(LoanDTO loanDTO);
        public LoanDTO UpdateLoan(LoanDTO loanDTO);
        public LoanDTO DeleteLoanById(int loanId);
    }
}
