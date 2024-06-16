﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SGT.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<string>
    {
        public ICollection<Endpoint> Endpoints { get; set; }
    }
}