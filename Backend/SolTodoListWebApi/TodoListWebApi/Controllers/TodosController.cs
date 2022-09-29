﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoListWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoContext _context;
        public TodosController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/<TodosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            return await _context.Todos.ToListAsync();
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if(todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        // POST api/<TodosController>
        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodo(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTodo", new { id = todo.Id }, todo);
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> PutTodo(int id, Todo todo)
        {
            if (id != todo.Id) 
            {
                return BadRequest();
            }

            _context.Entry(todo).State = EntityState.Modified;

            try 
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            { 
                if (!TodoExists(id)) 
                {
                    return NotFound();
                }
                else 
                {
                    throw;
                }
            }
            return todo;
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Todo>> DeleteTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null) 
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoExists(int id) 
        { 
            return _context.Todos.Any(e => e.Id == id);
        }
    }
}
