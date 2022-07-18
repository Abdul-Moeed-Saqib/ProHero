namespace ProHeroWeb.Models
{
    public class CharityItem
    {
        private Charity charity;
        private float donated;
        
        public Charity Charity { get => charity; set => charity = value; }
        public float Donated { get => donated; set => donated = value; }
    }
}
