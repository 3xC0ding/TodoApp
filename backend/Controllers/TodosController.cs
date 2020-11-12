using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoApp.Database;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        #region Fields
        // Logger
        private readonly ILogger<TodosController> _logger;
        
        // Database Context
        private readonly TodoContext _context;
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public TodosController(ILogger<TodosController> logger,
                              TodoContext context)
        {
            _logger = logger;
            _context = context;
        }
        #endregion

        [HttpGet]
        public async Task<IEnumerable<Todo>> Get()
        {
            return await _context.Todos.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            if(id <= 0)
                return BadRequest($"Id inválido: {nameof(id)}");
            
            var todo = await _context.Todos.AsNoTracking().ToListAsync();
            
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            
            return Ok(todo);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            if(id <= 0)
                return BadRequest($"Id inválido: {nameof(id)}");
            
            var todo = await _context.Todos.FindAsync(id);

            if(todo == null)
                return NotFound($"Não encontrado: {nameof(id)}");        

            _context.Todos.Remove(todo);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
