using AutoMapper;
using EhrlichPOS_BE.Dto;
using EhrlichPOS_BE.Interfaces;
using EhrlichPOS_BE.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EhrlichPOS_BE.Services
{
    public class OrderService : IOrder
    {
        private readonly EhrlichPosContext _context;
        private readonly IMapper _mapper;

        public OrderService(EhrlichPosContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<dynamic>> GetOrders() 
        {
            try
            {
                var query = _context.Orders.OrderByDescending(e => e.OrderId).Take(1000); // Get only the top 1000 for testing purposes
                return await Task.FromResult(query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<dynamic> GetOrder(int orderId)
        {
            try
            {
                var query = _context.Orders.FirstOrDefault(e => e.OrderId == orderId);
                return await Task.FromResult(query!);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<dynamic>> GetOrderDetails() 
        {
            var query = _context.OrderDetails.OrderByDescending(e => e.OrderDetailsId).Take(1000);  // Get only the top 1000 for testing purposes
            return await Task.FromResult(query);
        }

        public async Task<dynamic> GetOrderDetailsById(int orderDetailsId) 
        {
            try
            {
                var query = _context.OrderDetails.FirstOrDefault(e => e.OrderDetailsId == orderDetailsId);
                return await Task.FromResult(query!);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<dynamic>> PostOrder(IEnumerable<PostOrder> order) 
        {
            try
            {
                var setOrder = new Order();
                setOrder.Date = DateTime.Now;
                _context.Orders.Add(setOrder);
                await _context.SaveChangesAsync();
                var setJson = order.Select(e => new OrderDetailDto
                {
                    Order_Id = setOrder.OrderId,
                    PizzaId = e.PizzaId,
                    Quantity = e.Quantity
                }).ToList();
                var jsonData = JsonConvert.SerializeObject(setJson);
                await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"EXEC InsertPizzaOrderDetails @JsonData={jsonData}"
                );
                var returnData = _context.OrderDetails.Where(e => e.OrderId == setOrder.OrderId).AsNoTracking();
                return await Task.FromResult(returnData);
            }
            catch
            {
                throw;
            }
        }

        public async Task<dynamic> DeleteOrderDetails(OrderDetail orderDetails)
        {
            try
            {
                _context.OrderDetails.Remove(orderDetails);
                await _context.SaveChangesAsync();
                return await Task.FromResult("Successfully deleted.");
            }
            catch
            {
                throw;
            }
        }

        public async Task<dynamic> DeleteOrder(Order order) 
        {
            try
            {
                var dataDetails = _context.OrderDetails.Where(e => e.OrderId == order.OrderId);
                _context.OrderDetails.RemoveRange(dataDetails!);
                await _context.SaveChangesAsync();
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return await Task.FromResult("Successfully deleted.");
            }
            catch
            {
                throw;
            }

        }


    }
}
