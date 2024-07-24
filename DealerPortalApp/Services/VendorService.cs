using DealerPortalApp.Interfaces;
using DealerPortalApp.Models;
using DealerPortalApp.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DealerPortalApp.Services
{
    public class VendorService : IVendorService
    {
        private readonly IRepository<int, Vendor> _vendorRepository;

        public VendorService(IRepository<int, Vendor> vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public VendorDTO AddVendor(VendorDTO vendorDTO)
        {
            var vendor = new Vendor
            {
                VendorId = vendorDTO.VendorId,
                VendorName = vendorDTO.VendorName,
                Address = vendorDTO.Address,
                Phone = vendorDTO.Phone,
                Year = vendorDTO.Year,
                Model = vendorDTO.Model,
                Make = vendorDTO.Make
            };
            _vendorRepository.Add(vendor);
            return new VendorDTO
            {
                VendorId = vendor.VendorId,
                VendorName = vendor.VendorName,
                Address = vendor.Address,
                Phone = vendor.Phone,
                Year = vendor.Year,
                Model = vendor.Model,
                Make = vendor.Make
            };
        }

        public VendorDTO DeleteVendorById(int vendorId)
        {
            var vendor = _vendorRepository.Get(vendorId);

            if (vendor == null)
            {
                return null; 
            }

            _vendorRepository.Delete(vendorId);
            var vendorDTO = new VendorDTO
            {
                VendorId = vendor.VendorId,
                VendorName = vendor.VendorName,
                Address = vendor.Address,
                Phone = vendor.Phone,
                Year = vendor.Year,
                Model = vendor.Model,
                Make = vendor.Make
            };

            return vendorDTO;
        }

        public List<VendorDTO> GetAllVendors()
        {
            var vendors = _vendorRepository.GetAll()
                .Select(vendor => new VendorDTO
                {
                    VendorId = vendor.VendorId,
                    VendorName = vendor.VendorName,
                    Address = vendor.Address,
                    Phone = vendor.Phone,
                    Year = vendor.Year,
                    Model = vendor.Model,
                    Make = vendor.Make
                }).ToList();

            return vendors;
        }

        public VendorDTO GetVendorById(int vendorId)
        {
            var vendor = _vendorRepository.Get(vendorId);

            if (vendor == null)
            {
                return null; 
            }

            var vendorDTO = new VendorDTO
            {
                VendorId = vendor.VendorId,
                VendorName = vendor.VendorName,
                Address = vendor.Address,
                Phone = vendor.Phone,
                Year = vendor.Year,
                Model = vendor.Model,
                Make = vendor.Make
            };

            return vendorDTO;
        }

        public VendorDTO UpdateVendor(VendorDTO vendorDTO)
        {
            var vendor = _vendorRepository.Get(vendorDTO.VendorId);

            if (vendor == null)
            {
                return null; 
            }

            vendor.VendorName = vendorDTO.VendorName;
            vendor.Address = vendorDTO.Address;
            vendor.Phone = vendorDTO.Phone;
            vendor.Year = vendorDTO.Year;
            vendor.Model = vendorDTO.Model;
            vendor.Make = vendorDTO.Make;

            _vendorRepository.Update(vendor);

            return new VendorDTO
            {
                VendorId = vendor.VendorId,
                VendorName = vendor.VendorName,
                Address = vendor.Address,
                Phone = vendor.Phone,
                Year = vendor.Year,
                Model = vendor.Model,
                Make = vendor.Make
            };
        }
    }
}
