namespace DressZone.Services.Contracts
{
    public interface IUserCartService
    {
        void AddItemToCart(string productId, string cartId);
    }
}
