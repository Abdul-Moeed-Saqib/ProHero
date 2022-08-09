namespace ProHeroWeb.Models
{
    public struct CreditCard
    {
        private string cardNumber;
        private string cardName;
        private string expiryMonth;
        private string expiryYear;
        private string cvv;

        public string CardNumber { get => cardNumber; set => cardNumber = value; }
        public string CardName { get => cardName; set => cardName = value; }
        public string ExpiryMonth { get => expiryMonth; set => expiryMonth = value; }
        public string ExpiryYear { get => expiryYear; set => expiryYear = value; }
        public string Cvv { get => cvv; set => cvv = value; }
    }
}