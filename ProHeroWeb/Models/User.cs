using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProHeroWeb.Models
{
    public class User
    {
        private long userId;
        private string firstName;
        private string lastName;
        private string email;
        private Address address;
        private CreditCard card;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get => userId; set => userId = value; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid First Name")]
        [DisplayName("First Name")]
        public string FirstName { get => firstName; set => firstName = value; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Last Name")]
        [DisplayName("Last Name")]
        public string LastName { get => lastName; set => lastName = value; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email")]
        public string Email { get => email; set => email = value; }
        [Required]
        public Address Address { get => address; set => address = value; }
        [Required]
        [NotMapped]
        public CreditCard Card { get => card; set => card = value; }
    }
}
