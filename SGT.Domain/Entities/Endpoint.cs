﻿using SGT.Domain.Entities.Common;
using SGT.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGT.Domain.Entities
{
    public class Endpoint : BaseEntity
    {
        public Endpoint()
        {
            Roles = new HashSet<AppRole>();
        }
        public string ActionType { get; set; }
        public string HttpType { get; set; }
        public string Definition { get; set; }
        public string Code { get; set; }

        public Menu Menu { get; set; }
        public ICollection<AppRole> Roles { get; set; }
    }
}


//{ "actionType":"Updating","httpType":"PUT","definition":"Update Role","code":"PUT.Updating.UpdateRole"}


