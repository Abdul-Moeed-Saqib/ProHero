using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProHeroWeb.Models
{
    public class Address
    {
        private long id;
        private string streetName;
        private string postalCode;
        private string city;
        private string province;
        private string country;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get => id; set => id = value; }
        [Required]
        [DisplayName("Street Name")]
        public string StreetName { get => streetName; set => streetName = value; }
        [Required]
        [DisplayName("Postal Code")]
        public string PostalCode { get => postalCode; set => postalCode = value; }
        [Required]
        public string City { get => city; set => city = value; }
        [Required]
        [DisplayName("Province/State")]
        public string Province { get => province; set => province = value; }
        [Required]
        public string Country { get => country; set => country = value; }
    }
}
