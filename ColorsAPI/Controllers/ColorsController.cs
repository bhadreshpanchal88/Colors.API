using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Colors.BAL;
using Colors.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ColorsAPI.Controllers
{
    [Route("api/colors")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorsRepository _repository;

        public ColorsController(IColorsRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Get All Colors List
        /// </summary>
        /// <returns>List of Colors</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorsModel>>> GetAllColors()
        {
            var colors = await _repository.GetAll();
            if (colors != null)
            {
                return Ok(colors);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Get Colors by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Single Color</returns>
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<ColorsModel>>> GetColorByName(string name)
        {
            var color = await _repository.GetColorByName(name);
            if (color != null)
            {
                return Ok(color);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Save New Color in file
        /// </summary>
        /// <param name="colorsModel"></param>
        /// <returns>Single Color</returns>
        [HttpPost]
        public async Task<ActionResult<ColorsModel>> AddNewColor(ColorsModel colorsModel)
        {
            var color = await _repository.AddColor(colorsModel);
            if (color)
            {
                return Ok(color);
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}
