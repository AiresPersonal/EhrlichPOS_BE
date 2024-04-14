using AutoMapper;
using EhrlichPOS_BE.Dto;
using EhrlichPOS_BE.Interfaces;
using EhrlichPOS_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EhrlichPOS_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IOrder _order;

        public OrderController(IMapper mapper, IOrder order)
        {
            _mapper = mapper;
            _order = order;
        }

        [ProducesResponseType(typeof(IEnumerable<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("getOrders")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var query = await _order.GetOrders();
                return Ok(query.Select(e => _mapper.Map<OrderDto>(e)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse
                {
                    Code = "error",
                    Message = ex.ToString()
                });
            }
        }

        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                var query = await _order.GetOrder(id);
                if (query is null)
                {
                    return NotFound(new ErrorResponse
                    {
                        Code = "warning",
                        Message = "Item not found"
                    });
                }
                return Ok(_mapper.Map<OrderDto>(query));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse
                {
                    Code = "error",
                    Message = ex.ToString()
                });
            }
        }

        [ProducesResponseType(typeof(IEnumerable<PostOrderDetailsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("getOrderDetails")]
        public async Task<IActionResult> GetOrderDetails()
        {
            try
            {
                var query = await _order.GetOrderDetails();
                return Ok(query.Select(e => _mapper.Map<PostOrderDetailsDto>(e)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse
                {
                    Code = "error",
                    Message = ex.ToString()
                });
            }
        }

        [ProducesResponseType(typeof(PostOrderDetailsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("getOrderDetails/{id}")]
        public async Task<IActionResult> GetOrderDetailsById(int id)
        {
            try
            {
                var query = await _order.GetOrderDetailsById(id);
                return Ok(_mapper.Map<PostOrderDetailsDto>(query));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse
                {
                    Code = "error",
                    Message = ex.ToString()
                });
            }
        }

        [ProducesResponseType(typeof(IEnumerable<PostOrderDetailsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [HttpPost]
        public async Task<IActionResult> PostOrder(IEnumerable<PostOrder> order)
        {
            try
            {
                var query = await _order.PostOrder(order);
                return Ok(query.Select(e => _mapper.Map<PostOrderDetailsDto>(e)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse
                {
                    Code = "error",
                    Message = ex.ToString()
                });
            }
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [HttpDelete("OrderDetails/{id}")]
        public async Task<IActionResult> DeleteOrderDetails(int id)
        {
            try
            {
                var query = await _order.GetOrderDetailsById(id);
                if (query is null)
                {
                    return NotFound(new ErrorResponse
                    {
                        Code = "warning",
                        Message = "Order details not found"
                    });
                }

                var deleteResult = await _order.DeleteOrderDetails(query);
                return Ok(deleteResult);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse
                {
                    Code = "error",
                    Message = ex.ToString()
                });
            }
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var query = await _order.GetOrder(id);
                if (query is null)
                {
                    return NotFound(new ErrorResponse
                    {
                        Code = "warning",
                        Message = "Order not found"
                    });
                }

                var deleteResult = await _order.DeleteOrder(query);
                return Ok(deleteResult);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse
                {
                    Code = "error",
                    Message = ex.ToString()
                });
            }
        }

    }
}
