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
        public IEnumerable<Todo> Get()
        {
            return _context.Todos.AsNoTracking();
        }
    }
}
