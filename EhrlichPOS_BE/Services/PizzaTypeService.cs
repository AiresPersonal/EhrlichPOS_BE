using AutoMapper;
using EhrlichPOS_BE.Dto;
using EhrlichPOS_BE.Interfaces;
using EhrlichPOS_BE.Models;
using System;

namespace EhrlichPOS_BE.Services
{
    public class PizzaTypeService: IPizzaType
    {
        private readonly EhrlichPosContext _context;

        public PizzaTypeService(EhrlichPosContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Get list of pizza types
        /// </summary>
        /// <returns>list of PizzaType </returns>
        public async Task<IEnumerable<dynamic>> GetPizzaTypes() {
            try
            {
                var query = _context.PizzaTypes.OrderBy(e => e.Name);
                return await Task.FromResult(query);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get specific pizza type
        /// </summary>
        /// <param name="pizzaTypeId"></param>
        /// <returns>PizzaType</returns>
        public async Task<dynamic> GetPizzaType(string pizzaTypeId)
        {
            try
            {
                var query = _context.PizzaTypes.FirstOrDefault(e => e.PizzaTypeId == pizzaTypeId);
                return await Task.FromResult(query!);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Create new pizza type
        /// </summary>
        /// <param name="pizzaType"></param>
        /// <returns>pizzaType object</returns>
        public async Task<dynamic> PostPizzaType(PizzaType pizzaType)
        { 
            try{
                _context.PizzaTypes.Add(pizzaType);
                await _context.SaveChangesAsync();
                return await Task.FromResult(pizzaType);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update specific pizza type
        /// </summary>
        /// <param name="pizzaType"></param>
        /// <returns>string</returns>
        public async Task<dynamic> PutPizzaType(PizzaType pizzaType) 
        {
            try
            {
                _context.PizzaTypes.Update(pizzaType);
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
