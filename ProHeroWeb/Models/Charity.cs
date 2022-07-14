using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProHeroWeb.Models
{
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
        public string Name { get => name; set => name = value; }
        public string Organizer { get => organizer; set => organizer = value; }
        public string Country { get => country; set => country = value; }
        public string Location { get => location; set => location = value; }
        public string SmallDescription { get => smallDescription; set => smallDescription = value; }
        public string LargeDescription { get => largeDescription; set => largeDescription = value; }
        public float DonationPlan { get => donationPlan; set => donationPlan = value; }
        public float Donated { get => donated; set => donated = value; }
    }
}
