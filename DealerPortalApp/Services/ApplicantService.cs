using DealerPortalApp.Interfaces;
using DealerPortalApp.Models;
using DealerPortalApp.Models.DTOs;

namespace DealerPortalApp.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IRepository<int, Applicant> _applicantRepository;
        public ApplicantService(IRepository<int, Applicant> applicantRepository) 
        {
            _applicantRepository = applicantRepository;
        }

        public ApplicantDTO AddApplicant(ApplicantDTO applicantDTO)
        {
            var applicant = new Applicant
            {
                ApplicantId = applicantDTO.ApplicantId,
                ApplicantName = applicantDTO.ApplicantName,
                Email = applicantDTO.Email,
                Phone = applicantDTO.Phone
            };
            _applicantRepository.Add(applicant);
            return new ApplicantDTO
            {
                ApplicantId = applicant.ApplicantId,
                ApplicantName = applicant.ApplicantName,
                Email = applicant.Email,
                Phone = applicant.Phone
            };
        }

        public ApplicantDTO DeleteApplicantById(int applicantId)
        {
            var applicant = _applicantRepository.Get(applicantId);

            if (applicant == null)
            {
                // Handle the case where the applicant is not found, e.g., return null or throw an exception
                return null; // or throw new KeyNotFoundException("Applicant not found");
            }

            _applicantRepository.Delete(applicantId);
            var applicantDTO = new ApplicantDTO
            {
                ApplicantId = applicant.ApplicantId,
                ApplicantName = applicant.ApplicantName,
                Email = applicant.Email,
                Phone = applicant.Phone
            };

            return applicantDTO;
        }


        public List<ApplicantDTO> GetAllApplicants()
        {
            var applicants = _applicantRepository.GetAll()
                                                 .Select(applicant => new ApplicantDTO
                                                 {
                                                     ApplicantId = applicant.ApplicantId,
                                                     ApplicantName = applicant.ApplicantName,
                                                     Email = applicant.Email,
                                                     Phone = applicant.Phone
                                                 }).ToList();

            return applicants;
        }


        public ApplicantDTO GetApplicantById(int applicantId)
        {
            var applicant = _applicantRepository.Get(applicantId);

            if (applicant == null)
            {
                return null; 
            }

            var applicantDTO = new ApplicantDTO
            {
                ApplicantId = applicant.ApplicantId,
                ApplicantName = applicant.ApplicantName,
                Email = applicant.Email,
                Phone = applicant.Phone
            };

            return applicantDTO;
        }


        public ApplicantDTO UpdateApplicant(ApplicantDTO applicantDTO)
        {
            var applicant = _applicantRepository.Get(applicantDTO.ApplicantId);

            if (applicant == null)
            {
                return null; 
            }

            applicant.ApplicantName = applicantDTO.ApplicantName;
            applicant.Email = applicantDTO.Email;
            applicant.Phone = applicantDTO.Phone;

            _applicantRepository.Update(applicant);

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
