namespace EF_CORE_Day3.DTO
{
    public class OrderWithCustomerDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public CustomerDto Customer { get; set; } = null!;
    }
}
