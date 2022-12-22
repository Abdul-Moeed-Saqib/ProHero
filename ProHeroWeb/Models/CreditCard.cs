using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProHeroWeb.Models
{
    public class CreditCard
    {
        private string cardNumber;
        private string cardName;
        private string expiry;
        private string cvv;

        [Required]
        [DisplayName("Card Number")]
        public string CardNumber { get => cardNumber; set => cardNumber = value; }
        [Required]
        [DisplayName("Card Name")]
        public string CardName { get => cardName; set => cardName = value; }
        [Required]
        [DisplayName("Expiry")]
        public string Expiry { get => expiry; set => expiry = value; }
        [Required]
        [DisplayName("CVV")]
        public string Cvv { get => cvv; set => cvv = value; }
    }
}