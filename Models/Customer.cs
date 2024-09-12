using System.ComponentModel.DataAnnotations;

namespace BankingAppWebApi.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string NextOfKin { get; set; }
        public string NextOfKinPhone {  get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public ICollection<Account> Accounts {  get; set; }
    }
   
}
