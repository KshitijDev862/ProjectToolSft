using System.ComponentModel.DataAnnotations;

namespace CoreJwt.Models {
    public class Memberships {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
         [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Otp { get; set; } 
        public string token { get; set; }
        public Employees Emp { get; set; }

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