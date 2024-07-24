using DealerPortalApp.Interfaces;
using DealerPortalApp.Models.DTOs;
using DealerPortalApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DealerPortalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpPost]
        public ActionResult<VendorDTO> AddVendor([FromBody] VendorDTO vendorDTO)
        {
            if (vendorDTO == null)
            {
                return BadRequest("Vendor data is null.");
            }

            var createdVendor = _vendorService.AddVendor(vendorDTO);
            return CreatedAtAction(nameof(GetVendorById), new { id = createdVendor.VendorId }, createdVendor);
        }

        [HttpDelete("{id}")]
        public ActionResult<VendorDTO> DeleteVendorById(int id)
        {
            var vendorDTO = _vendorService.DeleteVendorById(id);
            if (vendorDTO == null)
            {
                return NotFound($"Vendor with ID {id} not found.");
            }

            return Ok(vendorDTO);
        }

        [HttpGet("GetAll")]
        public ActionResult<List<VendorDTO>> GetAllVendors()
        {
            var vendors = _vendorService.GetAllVendors();
            return Ok(vendors);
        }

        [HttpGet("{id}")]
        public ActionResult<VendorDTO> GetVendorById(int id)
        {
            var vendorDTO = _vendorService.GetVendorById(id);
            if (vendorDTO == null)
            {
                return NotFound($"Vendor with ID {id} not found.");
            }

            return Ok(vendorDTO);
        }

        [HttpPut("{id}")]
        public ActionResult<VendorDTO> UpdateVendor(int id, [FromBody] VendorDTO vendorDTO)
        {
            if (vendorDTO == null || vendorDTO.VendorId != id)
            {
                return BadRequest("Vendor data is null or ID mismatch.");
            }

            var updatedVendor = _vendorService.UpdateVendor(vendorDTO);
            if (updatedVendor == null)
            {
                return NotFound($"Vendor with ID {id} not found.");
            }

            return Ok(updatedVendor);
        }
    }
}
