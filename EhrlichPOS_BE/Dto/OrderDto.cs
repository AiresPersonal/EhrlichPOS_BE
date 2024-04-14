namespace EhrlichPOS_BE.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public DateTime Date { get; set; }
    }

    public class PostOrder
    {

        public string PizzaId { get; set; } = null!;

        public int Quantity { get; set; }
    }

    public class PostOrderDetailsDto
    {

        public int OrderDetailsId { get; set; }

        public int OrderId { get; set; }

        public string PizzaId { get; set; } = null!;

        public int Quantity { get; set; }
    }

    public class OrderDetailDto
    {
        public int Order_Id { get; set; }

        public string PizzaId { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
