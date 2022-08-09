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
        [DisplayName("First Name")]
        public string FirstName { get => firstName; set => firstName = value; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get => lastName; set => lastName = value; }
        [Required]
        public string Email { get => email; set => email = value; }
        [Required]
        public Address Address { get => address; set => address = value; }
        [NotMapped]
        public CreditCard Card { get => card; set => card = value; }
    }
}
