using System.ComponentModel.DataAnnotations;

namespace CoreJwt.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
         public bool IsActive { get; set; }
    }
}