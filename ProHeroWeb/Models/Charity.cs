using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProHeroWeb.Models
{
    [Index(nameof(Country), nameof(Name), IsUnique = true)]
    public class Charity
    {
        private long charityId;
        private string name;
        private string organizer;
        private string country;
        private string location;
        private string smallDescription;
        private string largeDescription;
        private float donationPlan;
        private float donated;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CharityId { get => charityId; set => charityId = value; }
        [Required]
        public string Name { get => name; set => name = value; }
        [Required]
        public string Organizer { get => organizer; set => organizer = value; }
        [Required]
        public string Country { get => country; set => country = value; }
        [Required]
        public string Location { get => location; set => location = value; }
        [Required]
        [DisplayName("Description")]
        public string SmallDescription { get => smallDescription; set => smallDescription = value; }
        [Required]
        [DisplayName("Give details about your chairty")]
        public string LargeDescription { get => largeDescription; set => largeDescription = value; }
        [Required]
        [DisplayName("How much would you like to raise?")]
        public float DonationPlan { get => donationPlan; set => donationPlan = value; }
        public float Donated { get => donated; set => donated = value; }
    }
}
