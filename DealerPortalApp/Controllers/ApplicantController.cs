using DealerPortalApp.Interfaces;
using DealerPortalApp.Models.DTOs;
using DealerPortalApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DealerPortalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpPost]
        public ActionResult<ApplicantDTO> AddApplicant([FromBody] ApplicantDTO applicantDTO)
        {
            if (applicantDTO == null)
            {
                return BadRequest("Applicant data is null.");
            }

            var createdApplicant = _applicantService.AddApplicant(applicantDTO);
            return CreatedAtAction(nameof(GetApplicantById), new { id = createdApplicant.ApplicantId }, createdApplicant);
        }

        [HttpDelete("{id}")]
        public ActionResult<ApplicantDTO> DeleteApplicantById(int id)
        {
            var applicantDTO = _applicantService.DeleteApplicantById(id);
            if (applicantDTO == null)
            {
                return NotFound($"Applicant with ID {id} not found.");
            }

            return Ok(applicantDTO);
        }

        [HttpGet("GetAll")]
        public ActionResult<List<ApplicantDTO>> GetAllApplicants()
        {
            var applicants = _applicantService.GetAllApplicants();
            return Ok(applicants);
        }

        [HttpGet("{id}")]
        public ActionResult<ApplicantDTO> GetApplicantById(int id)
        {
            var applicantDTO = _applicantService.GetApplicantById(id);
            if (applicantDTO == null)
            {
                return NotFound($"Applicant with ID {id} not found.");
            }

            return Ok(applicantDTO);
        }

        [HttpPut("{id}")]
        public ActionResult<ApplicantDTO> UpdateApplicant(int id, [FromBody] ApplicantDTO applicantDTO)
        {
            if (applicantDTO == null || applicantDTO.ApplicantId != id)
            {
                return BadRequest("Applicant data is null or ID mismatch.");
            }

            var updatedApplicant = _applicantService.UpdateApplicant(applicantDTO);
            if (updatedApplicant == null)
            {
                return NotFound($"Applicant with ID {id} not found.");
            }

            return Ok(updatedApplicant);
        }
    }
}
