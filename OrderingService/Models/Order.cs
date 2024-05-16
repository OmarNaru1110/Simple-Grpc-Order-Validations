namespace OrderingService.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
