using System.ComponentModel.DataAnnotations;

namespace asp_assignment.Models.BagStore
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        [Required]
        public string Name { get; set; }
        public int HomePhone { get; set; }
        [Required]
        public int WorkPhone { get; set; }
        public int MobilePhone { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
    }
}
