using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace asp_assignment.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public bool Enabled { get; set; }

        public int HomePhone { get; set; }

        public int WorkPhone { get; set; }

        public int MobilePhone { get; set; }

        public List<UserAddress> Addresses { get; set; }
    }
}
