namespace PlexCommerce
{
    public class OrderItem
    {
        public virtual int Id { get; private set; }

        public virtual Order Order { get; set; }

        public virtual ProductVariant ProductVariant { get; set; }

        public virtual int Quantity { get; set; }
    }
}