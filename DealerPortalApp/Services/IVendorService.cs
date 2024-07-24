using DealerPortalApp.Models.DTOs;

namespace DealerPortalApp.Services
{
    public interface IVendorService
    {
        public VendorDetailsDTO GetVendorDetails(int vendorId);
        public List<VendorDTO> GetAllVendors();
        public VendorDTO GetVendorById(int vendorId);
        public VendorDTO AddVendor(VendorDTO vendorDTO);
        public VendorDTO UpdateVendor(VendorDTO vendorDTO);
        public VendorDTO DeleteVendorById(int vendorId);

    }
}
