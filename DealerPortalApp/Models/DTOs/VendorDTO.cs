namespace DealerPortalApp.Models.DTOs
{
    public class VendorDTO
    {
        public int VendorId { get; set; }

        public string VendorName { get; set; } = null!;

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public int? Year { get; set; }

        public string? Model { get; set; }

        public string? Make { get; set; }

        public int? LoanId { get; set; }

        public int? ApplicantId { get; set; }

        public virtual ApplicantDTO? Applicant { get; set; }

        public virtual LoanDTO? Loan { get; set; }
    }
}
