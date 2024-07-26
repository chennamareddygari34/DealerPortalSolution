using DealerPortalApp.Interfaces;
using DealerPortalApp.Models;
using DealerPortalApp.Models.DTOs;
using DealerPortalApp.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace DealerPortalApp.Services
{
    public class VendorService : IVendorService
    {
        private readonly IRepository<int, Vendor> _vendorRepository;
        private readonly IRepository<int, Applicant> _applicantRepository;
        private readonly IRepository<int, Loan> _loanRepository;

        public VendorService(IRepository<int, Vendor> vendorRepository,
                             IRepository<int, Applicant> applicantRepository,
                             IRepository<int, Loan> loanRepository)
        {
            _vendorRepository = vendorRepository;
            _applicantRepository = applicantRepository;
            _loanRepository = loanRepository;
        }

        public VendorDTO AddVendor(VendorDTO vendorDTO)
        {
            var vendor = new Vendor
            {
                VendorName = vendorDTO.VendorName,
                Address = vendorDTO.Address,
                Phone = vendorDTO.Phone,
                Year = vendorDTO.Year,
                Model = vendorDTO.Model,
                Make = vendorDTO.Make,
                ApplicantId = vendorDTO.ApplicantId,
                LoanId = vendorDTO.LoanId
            };

            _vendorRepository.Add(vendor);

            return MapToVendorDTO(vendor);
        }

        public VendorDTO DeleteVendorById(int vendorId)
        {
            var vendor = _vendorRepository.Get(vendorId);

            if (vendor == null)
            {
                return null;
            }

            _vendorRepository.Delete(vendorId);

            return MapToVendorDTO(vendor);
        }

        public List<VendorDTO> GetAllVendors()
        {
            return _vendorRepository.GetAll()
                .Select(MapToVendorDTO)
                .ToList();
        }

        public VendorDTO GetVendorById(int vendorId)
        {
            var vendor = _vendorRepository.Get(vendorId);

            if (vendor == null)
            {
                return null;
            }

            return MapToVendorDTO(vendor);
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
            vendor.ApplicantId = vendorDTO.ApplicantId;
            vendor.LoanId = vendorDTO.LoanId;

            _vendorRepository.Update(vendor);

            return MapToVendorDTO(vendor);
        }
    
        private VendorDTO MapToVendorDTO(Vendor vendor)
        {
            if (vendor == null) return null;

            var applicantDTO = GetApplicantDTO(vendor.ApplicantId);
            var loanDTO = GetLoanDTO(vendor.LoanId);

            return new VendorDTO
            {
                VendorId = vendor.VendorId,
                VendorName = vendor.VendorName,
                Address = vendor.Address,
                Phone = vendor.Phone,
                Year = vendor.Year,
                Model = vendor.Model,
                Make = vendor.Make,
                ApplicantId = vendor.ApplicantId,
                LoanId = vendor.LoanId,
                Applicant = applicantDTO,
                Loan = loanDTO
            };
        }

        private ApplicantDTO GetApplicantDTO(int? applicantId)
        {
            if (applicantId == null) return null;

            var applicant = _applicantRepository.Get(applicantId.Value);
            if (applicant == null) return null;

            return new ApplicantDTO
            {
                ApplicantId = applicant.ApplicantId,
                ApplicantName = applicant.ApplicantName,
                Email = applicant.Email,
                Phone = applicant.Phone
            };
        }

        private LoanDTO GetLoanDTO(int? loanId)
        {
            if (loanId == null) return null;

            var loan = _loanRepository.Get(loanId.Value);
            if (loan == null) return null;

            return new LoanDTO
            {
                LoanId = loan.LoanId,
                ApplicantId = loan.ApplicantId,
                LoanAmount = loan.LoanAmount,
                ApplicationDate = loan.ApplicationDate,
                Status = loan.Status,
                LastUpdate = loan.LastUpdate,
                //Applicant = GetApplicantDTO(loan.ApplicantId)
            };
        }

        public VendorDetailsDTO GetVendorDetails(int vendorId)
        {
            var vendor = _vendorRepository.Get(vendorId);
            if (vendor == null)
            {
                return null;
            }

            var loan = _loanRepository.GetAll().FirstOrDefault(l => l.ApplicantId == vendor.VendorId);
            var applicant = loan != null ? _applicantRepository.Get(loan.ApplicantId) : null;

            return new VendorDetailsDTO
            {
                ApplicantId = applicant?.ApplicantId,
                Applicant = applicant?.ApplicantName,
                ApplicantDate = loan?.ApplicationDate,
                VendorName = vendor?.VendorName,
                Year = vendor.Year,
                Make = vendor.Make,
                Model = vendor.Model,
                Status = loan?.Status,
                LastUpdate = loan?.LastUpdate
            };
        }
        public List<VendorDetailsDTO> GetVendorDetailsAll()
        {
            var vendors = _vendorRepository.GetAll();
            var loans = _loanRepository.GetAll().ToList();
            var applicants = _applicantRepository.GetAll().ToList();

            var vendorDetailsList = vendors.Select(vendor =>
            {
                var loan = loans.FirstOrDefault(l => l.ApplicantId == vendor.VendorId);
                var applicant = loan != null ? applicants.FirstOrDefault(a => a.ApplicantId == loan.ApplicantId) : null;

                return new VendorDetailsDTO
                {
                    ApplicantId = applicant?.ApplicantId,
                    Applicant = applicant?.ApplicantName,
                    ApplicantDate = loan?.ApplicationDate,
                    VendorName = vendor?.VendorName,
                    Year = vendor.Year,
                    Make = vendor.Make,
                    Model = vendor.Model,
                    Status = loan?.Status,
                    LastUpdate = loan?.LastUpdate
                };
            }).ToList();

            return vendorDetailsList;
        }
    }



}


