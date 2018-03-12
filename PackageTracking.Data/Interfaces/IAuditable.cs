using System;

namespace PackageTracking.Data.Interfaces
{
    interface IAuditable
    {
        DateTime CreatedOn { get; set; }
        int CreatedBy { get; set; }
        DateTime ModifiedOn { get; set; }
        int ModifiedBy { get; set; }
    }
}
