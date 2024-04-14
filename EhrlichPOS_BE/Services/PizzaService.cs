using EhrlichPOS_BE.Interfaces;
using EhrlichPOS_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace EhrlichPOS_BE.Services
{
    public class PizzaService: IPizza
    {
        private readonly EhrlichPosContext _context;

        public PizzaService(EhrlichPosContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get list of pizza
        /// </summary>
        /// <returns>list of Pizza</returns>
        public async Task<IEnumerable<dynamic>> GetPizzas()
        {
            try
            {
                var query = _context.Pizzas.OrderByDescending(e => e.PizzaId).Include(e => e.PizzaType);
                return await Task.FromResult(query);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get specific pizza
        /// </summary>
        /// <param name="pizzaId"></param>
        /// <returns>Pizza</returns>
        public async Task<dynamic> GetPizza(string pizzaId)
        {
            try
            {
                var query = _context.Pizzas.Include(e => e.PizzaType).FirstOrDefault(e => e.PizzaId == pizzaId);
                return await Task.FromResult(query!);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Create new pizza
        /// </summary>
        /// <param name="pizza"></param>
        /// <returns>Pizza</returns>
        public async Task<dynamic> PostPizza(Pizza pizza)
        {
            try
            {
                _context.Pizzas.Add(pizza);
                await _context.SaveChangesAsync();
                return await Task.FromResult(pizza);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update specific pizza
        /// </summary>
        /// <param name="pizza"></param>
        /// <returns>Pizza</returns>
        public async Task<dynamic> PutPizza(Pizza pizza)
        {
            try
            {
                _context.Pizzas.Update(pizza);
                await _context.SaveChangesAsync();
                return await Task.FromResult("Successfully updated");
            }
            catch
            {
                throw;
            }
        }
    }
}
