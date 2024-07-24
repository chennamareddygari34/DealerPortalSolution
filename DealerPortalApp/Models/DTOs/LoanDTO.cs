namespace DealerPortalApp.Models.DTOs
{
    public class LoanDTO
    {
        public int LoanId { get; set; }
        public int VendorId { get; set; }
        public int ApplicantId { get; set; }
        public decimal? LoanAmount { get; set; }
        public DateTime? LoanDate { get; set; }
        public string? Status { get; set; }
        public DateTime? LastUpdate { get; set; }
        public ApplicantDTO Applicant { get; set; } 
    }
}
