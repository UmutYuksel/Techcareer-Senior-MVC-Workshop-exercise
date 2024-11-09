using System.ComponentModel.DataAnnotations;

namespace MvcMastery.Models
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Adress is required")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Birth date is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Natinotal id is required")]
        public string? NationalId { get; set; }


    }
}