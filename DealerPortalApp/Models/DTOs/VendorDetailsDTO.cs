namespace DealerPortalApp.Models.DTOs
{
    public class VendorDetailsDTO
    {
        public int? ApplicantId { get; set; }
        public string? Applicant { get; set; }
        public DateTime? ApplicantDate { get; set; }
        public string? VendorName { get; set; }
        public int? Year { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Status { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
