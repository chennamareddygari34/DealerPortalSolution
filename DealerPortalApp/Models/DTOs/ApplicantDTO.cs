namespace DealerPortalApp.Models.DTOs
{
    public class ApplicantDTO
    {
        public int ApplicantId { get; set; }
        public string? ApplicantName { get; set; } 
        public string? Email { get; set; } 
        public string? Phone { get; set; }
        public ICollection<LoanDTO> Loans { get; set; } = new List<LoanDTO>();
    }
}
