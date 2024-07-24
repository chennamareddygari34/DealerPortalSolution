using System;
using System.Collections.Generic;

namespace DealerPortalApp.Models;

public partial class Loan
{
    public int LoanId { get; set; }

    public int ApplicantId { get; set; }

    public decimal LoanAmount { get; set; }

    public DateTime ApplicationDate { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? LastUpdate { get; set; }

    public virtual Applicant Applicant { get; set; } = null!;

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
