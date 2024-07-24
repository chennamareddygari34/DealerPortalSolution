namespace DealerPortalApp.Models.DTOs
{
    public class ApplicantDTO
    {
        public int ApplicantId { get; set; }

        public string ApplicantName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }
        


    }
}
