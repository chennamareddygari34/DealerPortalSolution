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
        [HttpGet("Details/{vendorId}")]
        public ActionResult<VendorDetailsDTO> GetVendorDetails(int vendorId)
        {
            var vendorDetails = _vendorService.GetVendorDetails(vendorId);
            if (vendorDetails == null)
            {
                return NotFound($"Vendor with ID {vendorId} not found.");
            }
            return Ok(vendorDetails);
        }

        [HttpGet]
        public ActionResult<List<VendorDTO>> GetAllVendors()
        {
            var vendors = _vendorService.GetAllVendors();
            if (vendors == null || vendors.Count == 0)
            {
                return NotFound("No vendors found.");
            }
            return Ok(vendors);
        }

        [HttpGet("{vendorId}")]
        public ActionResult<VendorDTO> GetVendorById(int vendorId)
        {
            var vendor = _vendorService.GetVendorById(vendorId);
            if (vendor == null)
            {
                return NotFound($"Vendor with ID {vendorId} not found.");
            }
            return Ok(vendor);
        }

        [HttpPost]
        public ActionResult<VendorDTO> AddVendor([FromBody] VendorDTO vendorDTO)
        {
            if (vendorDTO == null)
            {
                return BadRequest("Vendor data is null.");
            }
            var addedVendor = _vendorService.AddVendor(vendorDTO);
            return CreatedAtAction(nameof(GetVendorById), new { vendorId = addedVendor.VendorId }, addedVendor);
        }

        [HttpPut("{vendorId}")]
        public ActionResult<VendorDTO> UpdateVendor(int vendorId, [FromBody] VendorDTO vendorDTO)
        {
            if (vendorDTO == null)
            {
                return BadRequest("Vendor data is null.");
            }
            var updatedVendor = _vendorService.UpdateVendor(vendorDTO);
            if (updatedVendor == null)
            {
                return NotFound($"Vendor with ID {vendorId} not found.");
            }
            return Ok(updatedVendor);
        }

        [HttpDelete("{vendorId}")]
        public ActionResult<VendorDTO> DeleteVendor(int vendorId)
        {
            var deletedVendor = _vendorService.DeleteVendorById(vendorId);
            if (deletedVendor == null)
            {
                return NotFound($"Vendor with ID {vendorId} not found.");
            }
            return Ok(deletedVendor);
        }
    }
}
