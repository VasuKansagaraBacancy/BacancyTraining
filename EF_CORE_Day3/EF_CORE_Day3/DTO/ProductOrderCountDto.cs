namespace EF_CORE_Day3.DTO
{
    public class ProductOrderCountDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int TotalOrders { get; set; }
    }
}
