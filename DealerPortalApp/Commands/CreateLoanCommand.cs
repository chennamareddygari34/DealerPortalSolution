﻿using MediatR;

namespace DealerPortalAPI.Commands
{
    public class CreateLoanCommand : IRequest<bool>
    {
       // public int VendorId { get; set; }
        public int ApplicantId { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; } = null!;
    }

}
