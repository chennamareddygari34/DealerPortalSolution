using System;
using System.Collections.Generic;

namespace DealerPortalApp.Models;

public partial class Applicant
{
    public int ApplicantId { get; set; }

    public string ApplicantName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
