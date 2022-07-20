namespace ProHeroWeb.Models
{
    public class CharityItem
    {
        private Charity charity;
        private float donated;
        private List<float> donatedStack = new List<float>();
        
        public Charity Charity { get => charity; set => charity = value; }
        public float Donated { get => donated; set => donated = value; }
        public List<float> DonatedStack { get => donatedStack; set => donatedStack = value; }
    }
}
