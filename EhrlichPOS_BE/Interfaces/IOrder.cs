using EhrlichPOS_BE.Dto;
using EhrlichPOS_BE.Models;

namespace EhrlichPOS_BE.Interfaces
{
    public interface IOrder
    {
        Task<IEnumerable<dynamic>> GetOrders();

        Task<dynamic> GetOrder(int orderId);

        Task<IEnumerable<dynamic>> GetOrderDetails();
        Task<dynamic> GetOrderDetailsById(int orderDetailsId);

        Task<IEnumerable<dynamic>> PostOrder(IEnumerable<PostOrder> order);

        Task<dynamic> DeleteOrderDetails(OrderDetail orderDetails);
        Task<dynamic> DeleteOrder(Order order);

    }
}
