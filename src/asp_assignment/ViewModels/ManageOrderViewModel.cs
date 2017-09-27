using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_assignment.Models.BagStore;
using asp_assignment.Models.Identity;

namespace asp_assignment.ViewModels
{
    public class ManageOrderViewModel
    {
        public Order Order { get; set; }
        public OrderState OrderState { get; set; }
    }
}
