namespace EhrlichPOS_BE.Dto
{
    public class PizzaDto
    {
        public string PizzaId { get; set; } = null!;

        public string PizzaTypeId { get; set; } = null!;

        public string PizzaType { get; set; } = null!;

        public string Size { get; set; } = null!;

        public double Price { get; set; }
    }

    public class PostPizza
    {
        public string PizzaId { get; set; } = null!;

        public string PizzaTypeId { get; set; } = null!;

        public string Size { get; set; } = null!;

        public double Price { get; set; }
    }

    public class PutPizza
    {
        public string PizzaTypeId { get; set; } = null!;

        public string Size { get; set; } = null!;

        public double Price { get; set; }
    }

}
