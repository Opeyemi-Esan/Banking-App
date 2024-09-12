using System.ComponentModel.DataAnnotations;

namespace BankingAppWebApi.Models
{
    public class AccountOpeningDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [MaxLength(11, ErrorMessage ="Phone number must not be more than 11 digits")]
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string NextOfKin { get; set; }
        public string NextOfKinPhone { get; set; }
        public AccountType AccountType { get; set; }

    }

    public enum AccountType
    {
        Savings,
        Current,
    }
}
