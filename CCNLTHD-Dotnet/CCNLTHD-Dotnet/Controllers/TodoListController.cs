using CCNLTHD_Dotnet.Data;
using CCNLTHD_Dotnet.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCNLTHD_Dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TodoListController : ControllerBase
    {
        private readonly DbContextApp _dbContextApp;
        public TodoListController(DbContextApp dbContextApp)
        {
            _dbContextApp = dbContextApp;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todoList = await _dbContextApp.TodoList.ToListAsync();
            return Ok(todoList);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoList newTodoList)
        {

            _dbContextApp.TodoList.Add(newTodoList);
            await _dbContextApp.SaveChangesAsync();
            return Ok(newTodoList);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Del(int id)
        {
            var TodoToDel = await _dbContextApp.TodoList.FindAsync(id);
            if(TodoToDel == null)
            {
                return NotFound();
            }

            _dbContextApp.TodoList.Remove(TodoToDel);
            await _dbContextApp.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var TodoById = await _dbContextApp.TodoList.Where(u => u.Id == id).FirstOrDefaultAsync();
            return Ok(TodoById);

        }

        [HttpPut]
        public async Task<IActionResult> Put(TodoList todoToEdit)
        {
            _dbContextApp.TodoList.Update(todoToEdit);
            await _dbContextApp.SaveChangesAsync();
            return Ok(todoToEdit);

        }
    }
}
