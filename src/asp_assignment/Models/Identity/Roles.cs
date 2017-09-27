﻿using System.Collections.Generic;

namespace asp_assignment.Models.Identity
{
    public static class Roles
    {
        private static readonly string[] roles = { "Admin" };

        public static string Admin { get { return roles[0]; } }

        public static IEnumerable<string> All { get { return roles; } }
    }
}
