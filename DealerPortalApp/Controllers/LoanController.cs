using DealerPortalApp.Interfaces;
using DealerPortalApp.Models.DTOs;
using DealerPortalApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DealerPortalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet("{id}")]
        public ActionResult<LoanDTO> GetLoanById(int id)
        {
            var loanDTO = _loanService.GetLoanById(id);
            if (loanDTO == null)
            {
                return NotFound($"Loan with ID {id} not found.");
            }

            return Ok(loanDTO);
        }

        [HttpPost]
        public ActionResult<LoanDTO> AddLoan([FromBody] LoanDTO loanDTO)
        {
            if (loanDTO == null)
            {
                return BadRequest("Loan data is null.");
            }

            var createdLoan = _loanService.AddLoan(loanDTO);
            return CreatedAtAction(nameof(GetLoanById), new { id = createdLoan.LoanId }, createdLoan);
        }

        [HttpDelete("{id}")]
        public ActionResult<LoanDTO> DeleteLoanById(int id)
        {
            var loanDTO = _loanService.DeleteLoanById(id);
            if (loanDTO == null)
            {
                return NotFound($"Loan with ID {id} not found.");
            }

            return Ok(loanDTO);
        }

        [HttpGet("GetAll")]
        public ActionResult<List<LoanDTO>> GetAllLoans()
        {
            var loans = _loanService.GetAllLoans();
            return Ok(loans);
        }

        [HttpPut("{id}")]
        public ActionResult<LoanDTO> UpdateLoan(int id, [FromBody] LoanDTO loanDTO)
        {
            if (loanDTO == null || loanDTO.LoanId != id)
            {
                return BadRequest("Loan data is null or ID mismatch.");
            }

            var updatedLoan = _loanService.UpdateLoan(loanDTO);
            if (updatedLoan == null)
            {
                return NotFound($"Loan with ID {id} not found.");
            }

            return Ok(updatedLoan);
        }
    }
}
