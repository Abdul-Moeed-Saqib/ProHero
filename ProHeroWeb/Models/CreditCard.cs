using System.ComponentModel;

namespace ProHeroWeb.Models
{
    public struct CreditCard
    {
        private string cardNumber;
        private string cardName;
        private string expiry;
        private string cvv;

        [DisplayName("Card Number")]
        public string CardNumber { get => cardNumber; set => cardNumber = value; }
        [DisplayName("Card Name")]
        public string CardName { get => cardName; set => cardName = value; }
        [DisplayName("Expiry")]
        public string Expiry { get => expiry; set => expiry = value; }
        [DisplayName("CVV")]
        public string Cvv { get => cvv; set => cvv = value; }
    }
}