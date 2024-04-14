using AutoMapper;
using EhrlichPOS_BE.Dto;
using EhrlichPOS_BE.Interfaces;
using EhrlichPOS_BE.Models;
using EhrlichPOS_BE.Services;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EhrlichPOS_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPizzaType _pizzaType;
        public PizzaTypeController(IMapper mapper, IPizzaType pizzaType) 
        {
            _mapper = mapper;
            _pizzaType = pizzaType;
        }

        [ProducesResponseType(typeof(IEnumerable<PizzaTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("getPizzaTypes")]
        public async Task<IActionResult> GetPizzaTypes()
        {
            try
            {
                var query = await _pizzaType.GetPizzaTypes();
                return Ok(query.Select(e => _mapper.Map<PizzaTypeDto>(e)));
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

        [ProducesResponseType(typeof(PizzaTypeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPizzaType(string id)
        {
            try
            {
                var query = await _pizzaType.GetPizzaType(id);
                if (query is null)
                {
                    return NotFound(new ErrorResponse
                    {
                        Code = "warning",
                        Message = "Item not found"
                    });
                }
                return Ok(_mapper.Map<PizzaTypeDto>(query));
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

        [ProducesResponseType(typeof(PizzaTypeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [HttpPost]
        public async Task<IActionResult> PostPizzaType(PizzaTypeDto pizzaType)
        {
            try
            {
                var check = await _pizzaType.GetPizzaType(pizzaType.PizzaTypeId);
                if (check is not null)
                {
                    return Conflict(new ErrorResponse
                    {
                        Code = "warning",
                        Message = $"{pizzaType.PizzaTypeId} is already exist."
                    });
                }
                var dataMap = _mapper.Map<PizzaType>(pizzaType);
                var query = await _pizzaType.PostPizzaType(dataMap);
                return Ok(_mapper.Map<PizzaTypeDto>(query));
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
        public async Task<IActionResult> PutPizzaType(string id, PutPizzaTypeDto pizzaTypeDto)
        {
            try
            {
                var query = await _pizzaType.GetPizzaType(id);
                query.Name = pizzaTypeDto.Name;
                query.Category = pizzaTypeDto.Category;
                query.Ingredients = pizzaTypeDto.Ingredients;
                var getReturn = await _pizzaType.PutPizzaType(query);
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
