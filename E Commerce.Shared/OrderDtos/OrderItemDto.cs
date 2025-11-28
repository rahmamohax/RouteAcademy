namespace E_Commerce.Shared.OrderDtos
{
    public record OrderItemDto(string ProductName, string PictureUrl, decimal Price, int Quantity);
    
}