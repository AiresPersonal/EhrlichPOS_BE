using EhrlichPOS_BE.Dto;
using EhrlichPOS_BE.Models;

namespace EhrlichPOS_BE.Interfaces
{
    public interface IPizzaType
    {
        Task<IEnumerable<dynamic>> GetPizzaTypes();

        Task<dynamic> GetPizzaType(string pizzaTypeId);

        Task<dynamic> PostPizzaType(PizzaType pizzaType);

        Task<dynamic> PutPizzaType(PizzaType pizzaType);
    }
}
