using System;

namespace Data.Entities.Items
{
    public class Cart
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        public Guid UserId { get; set; }

        public Product Product { get; set; }

        public DateTime CreatedDate { get; set; }

        public AppUser AppUser { get; set; }

    }
}
