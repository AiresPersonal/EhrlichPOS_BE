namespace EhrlichPOS_BE.Dto
{
    public class PizzaTypeDto
    {
        public string PizzaTypeId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Ingredients { get; set; } = null!;
    }

    public class PutPizzaTypeDto
    {
        public string Name { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Ingredients { get; set; } = null!;
    }
}
