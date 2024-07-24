namespace DealerPortalApp.Models.DTOs
{
    public class VendorDTO
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? Year { get; set; }
        public string? Model { get; set; }
        public string? Make { get; set; }
        public ICollection<LoanDTO> Loans { get; set; } = new List<LoanDTO>();
    }
}
