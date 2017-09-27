using System;
using System.Collections.Generic;
using asp_assignment.Models.BagStore;

namespace asp_assignment.ViewModels.Orders
{
    public class DetailsViewModel
    {
        public Order Order { get; set; }
        public bool ShowConfirmation { get; set; }
    }
}