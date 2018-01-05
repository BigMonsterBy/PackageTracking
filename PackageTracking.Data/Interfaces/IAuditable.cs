﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
