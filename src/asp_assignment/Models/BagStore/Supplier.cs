using System.ComponentModel.DataAnnotations;

namespace asp_assignment.Models.BagStore
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int HomePhone { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public int WorkPhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int MobilePhone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
