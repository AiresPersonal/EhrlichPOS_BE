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
    public class PizzaController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IPizza _pizza;

        public PizzaController(IMapper mapper, IPizza pizza)
        {
            _mapper = mapper;
            _pizza = pizza;
        }

        [ProducesResponseType(typeof(IEnumerable<PizzaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("getPizzas")]
        public async Task<IActionResult> GetPizzas()
        {
            try
            {
                var query = await _pizza.GetPizzas();
                return Ok(query.Select(e => _mapper.Map<PizzaDto>(e)));
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

        [ProducesResponseType(typeof(PizzaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPizza(string id)
        {
            try
            {
                var query = await _pizza.GetPizza(id);
                if (query is null)
                {
                    return NotFound(new ErrorResponse
                    {
                        Code = "warning",
                        Message = "Item not found"
                    });
                }
                return Ok(_mapper.Map<PizzaDto>(query));
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

        [ProducesResponseType(typeof(PostPizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [HttpPost]
        public async Task<IActionResult> PostPizza(PostPizza pizza)
        {
            try
            {
                var check = await _pizza.GetPizza(pizza.PizzaId);
                if (check is not null)
                {
                    return Conflict(new ErrorResponse
                    {
                        Code = "warning",
                        Message = $"{pizza.PizzaId} is already exist."
                    });
                }
                var dataMap = _mapper.Map<Pizza>(pizza);
                var query = await _pizza.PostPizza(dataMap);
                return Ok(_mapper.Map<PostPizza>(query));
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
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaType(string id, PutPizza pizzaDto)
        {
            try
            {
                var query = await _pizza.GetPizza(id);
                query.PizzaTypeId = pizzaDto.PizzaTypeId;
                query.Size = pizzaDto.Size;
                query.Price = pizzaDto.Price;
                var getReturn = await _pizza.PutPizza(query);
                return Ok(getReturn);
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
