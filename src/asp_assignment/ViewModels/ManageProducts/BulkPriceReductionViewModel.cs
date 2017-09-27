using System.ComponentModel.DataAnnotations;

namespace asp_assignment.ViewModels.ManageProducts
{
    public class BulkPriceReductionViewModel
    {
        [Display(Name ="Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Percentage off Actual Price")]
        public int PercentageOffMSRP { get; set; }
    }
}
