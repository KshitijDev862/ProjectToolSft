using System.ComponentModel.DataAnnotations;

namespace CoreJwt.Models {
    public class Employees {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } 
        [Required]
        public string LastName { get; set; } 
        [Required]
        public string Phone { get; set; }

        [Required]
        public System.DateTime DOB { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsLocked { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        [Required]
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}