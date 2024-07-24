namespace DealerPortalApp.Models.DTOs
{
    public class LoanDTO
    {
        public int LoanId { get; set; }

        public int ApplicantId { get; set; }

        public decimal LoanAmount { get; set; }

        public DateTime ApplicationDate { get; set; }

        public string Status { get; set; } = null!;

        public DateTime? LastUpdate { get; set; }
        public ApplicantDTO? Applicant { get; internal set; }
    }
}
