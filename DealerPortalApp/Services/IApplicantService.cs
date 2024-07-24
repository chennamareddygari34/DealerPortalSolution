using DealerPortalApp.Models.DTOs;

namespace DealerPortalApp.Services
{
    public interface IApplicantService
    {
        public List<ApplicantDTO> GetAllApplicants();
        public ApplicantDTO GetApplicantById(int ApplicantId);
         public ApplicantDTO AddApplicant(ApplicantDTO applicantDTO);
        public ApplicantDTO UpdateApplicant(ApplicantDTO applicantDTO);
        public ApplicantDTO DeleteApplicantById(int ApplicantId);
    }
}
