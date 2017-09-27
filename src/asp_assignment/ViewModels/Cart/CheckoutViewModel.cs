using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using asp_assignment.Models.Identity;
using asp_assignment.Models.BagStore;

namespace asp_assignment.ViewModels.Cart
{
    public class CheckoutViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<UserAddress> UserAddresses { get; set; }

        [Display(Name ="Remember Address")]
        public bool RememberAddress { get; set; }
    }
}