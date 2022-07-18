namespace ProHeroWeb.Models
{
    public class ShoppingCart
    {
        private CharityItem charity;
        private string message;
        private int quantity;

        public CharityItem Charity { get => charity; set => charity = value; }
        public string Message { get => message; set => message = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
