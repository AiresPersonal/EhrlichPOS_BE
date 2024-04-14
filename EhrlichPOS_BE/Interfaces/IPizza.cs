using EhrlichPOS_BE.Models;

namespace EhrlichPOS_BE.Interfaces
{
    public interface IPizza
    {
        Task<IEnumerable<dynamic>> GetPizzas();

        Task<dynamic> GetPizza(string pizza);

        Task<dynamic> PostPizza(Pizza pizza);

        Task<dynamic> PutPizza(Pizza pizza);
    }
}
