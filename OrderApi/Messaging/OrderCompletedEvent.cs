namespace Common.Messaging
{
    public class OrderCompletedEvent
    {
        public string BuyerId { get; set; }
        public OrderCompletedEvent(string buyerId)
        {
            BuyerId = buyerId;
        }
    }
}
